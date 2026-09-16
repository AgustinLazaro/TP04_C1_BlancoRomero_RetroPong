using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private GameSettings _settings;
    [SerializeField] private ObjectPool _hitSparksPool;

    [Header("Audio")]
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private AudioClip _hitSound;

    [Header("Angle Settings")]
    [SerializeField] private float _startAngleLimit = 0.7f;
    [SerializeField] private float _randomBounce = 0.20f;

    private Rigidbody2D _rb;
    private Vector2 _currentDirection;
    private float _forceMagnitude;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        LaunchBall();
    }

    public void LaunchBall()
    {
        _forceMagnitude = _settings.InitialBallSpeed;

        float directionX;
        if (Random.Range(0, 2) == 0)
        {
            directionX = -1f;
        }
        else
        {
            directionX = 1f;
        }

        float directionY = Random.Range(-_startAngleLimit, _startAngleLimit);

        _currentDirection = new Vector2(directionX, directionY).normalized;

        _rb.linearVelocity = Vector2.zero;
        _rb.angularVelocity = 0f;

        _rb.AddForce(_currentDirection * _forceMagnitude);
    }

    public void ResetBall()
    {
        _rb.linearVelocity = Vector2.zero;
        _rb.angularVelocity = 0f;
        transform.position = Vector3.zero;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Paletas
        if (collision.gameObject.TryGetComponent<Movement>(out Movement player))
        {
            _currentDirection.x = -_currentDirection.x;
            _currentDirection.y += Random.Range(-_randomBounce, _randomBounce);

            _forceMagnitude += _settings.SpeedPerHit;

            // Spawn Spark
            if (_hitSparksPool)
            {
                Vector2 contactPoint = collision.GetContact(0).point;
                _hitSparksPool.Get(contactPoint);
            }

            //SFX
            _audioManager.PlaySFX(_hitSound);
        }

        // shield 1
        if (collision.gameObject.name == "Shield_P1")
        {
            _currentDirection.x = -_currentDirection.x;
            _currentDirection.y += Random.Range(-_randomBounce, _randomBounce);
        }

        // shield 2
        if (collision.gameObject.name == "Shield_P2")
        {
            _currentDirection.x = -_currentDirection.x;
            _currentDirection.y += Random.Range(-_randomBounce, _randomBounce);
        }

        // Obstacle1
        if (collision.gameObject.name == "Obstacle1")
        {
            _currentDirection.x = -_currentDirection.x;
            _currentDirection.y += Random.Range(-_randomBounce, _randomBounce);
        }

        // Techo y piso
        if (collision.gameObject.TryGetComponent<Boundary>(out Boundary boundary))
        {
            _currentDirection.y = -_currentDirection.y;
            _currentDirection.x += Random.Range(-_randomBounce, _randomBounce);
        }

        _currentDirection = _currentDirection.normalized;

        _rb.linearVelocity = Vector2.zero;
        _rb.AddForce(_currentDirection * _forceMagnitude);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, 1f);

        if (Application.isPlaying)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + (Vector3)_currentDirection);
        }
    }
}











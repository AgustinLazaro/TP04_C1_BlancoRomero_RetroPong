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
        // Suggestion: acá llamás a LaunchBall y MatchManager.Start también lo hace a través de StartRound, así que la pelota se lanza dos veces al arrancar.
        // Como el orden entre los dos Start no está garantizado, dejá que la pelota la lance solo el MatchManager y borrá este Start.
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

            // Warning: _forceMagnitude crece en cada toque de paleta y no tiene tope. En un peloteo largo la pelota puede terminar moviéndose más rápido que el grosor de los colliders y atravesarlos.
            // Acotalo con Mathf.Min(_forceMagnitude + _settings.SpeedPerHit, maxForce) y serializá maxForce, o mejor todavía sumalo al GameSettings, que ya es el lugar donde viven estas constantes.
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
        // Warning: los escudos se detectan por el nombre del GameObject, con el string escrito a mano y repetido en la línea 91 y en PowerUpSpawner.cs:49.
        // Si alguien renombra el objeto en la escena, el rebote deja de funcionar y no hay ningún error que lo avise. Usá un componente marcador (como ya hacés con Boundary y Obstacle) y resolvelo con TryGetComponent.
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

        //Obstacle1
        if (collision.gameObject.TryGetComponent<Obstacle>(out Obstacle obstacle1))
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

    // Suggestion: este OnDrawGizmos dibuja una esfera amarilla de radio 1 sobre la pelota en todo momento, también con el juego parado.
    // Si lo querés conservar para depurar, pasalo a OnDrawGizmosSelected y bajale el radio.
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











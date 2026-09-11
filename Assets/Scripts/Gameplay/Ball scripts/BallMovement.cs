using UnityEngine;
public class BallMovement : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private GameSettings _settings;

    [Header("Components")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Angle Settings")]
    [SerializeField] private float startAngleLimit = 0.7f;
    [SerializeField] private float randomBounce = 0.20f;

    private Vector2 currentDirection;
    private float forceMagnitude;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        LaunchBall();
    }

    public void LaunchBall()
    {
        forceMagnitude = _settings.InitialBallSpeed;

        float directionX;
        if (Random.Range(0, 2) == 0)
        {
            directionX = -1f;
        }
        else
        {
            directionX = 1f;
        }

        float directionY = Random.Range(-startAngleLimit, startAngleLimit);

        currentDirection = new Vector2(directionX, directionY).normalized;

        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;

        rb.AddForce(currentDirection * forceMagnitude);
    }

    public void ResetBall()
    {
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;
        transform.position = Vector3.zero;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            currentDirection.x = currentDirection.x * -1f;
            currentDirection.y += Random.Range(-randomBounce, randomBounce);

            forceMagnitude += _settings.SpeedPerHit;
        }

        if (collision.gameObject.CompareTag("Boundaries"))
        {
            currentDirection.y = currentDirection.y * -1f;
            currentDirection.x += Random.Range(-randomBounce, randomBounce);
        }

        if (collision.gameObject.CompareTag("Boundaries2"))
        {
            currentDirection.x = currentDirection.x * -1f;
            currentDirection.y += Random.Range(-randomBounce, randomBounce);
        }

        currentDirection = currentDirection.normalized;

        rb.linearVelocity = Vector2.zero;
        rb.AddForce(currentDirection * forceMagnitude);
    }





    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, 1f);

        if (Application.isPlaying)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + (Vector3)currentDirection);
        }
    }
}












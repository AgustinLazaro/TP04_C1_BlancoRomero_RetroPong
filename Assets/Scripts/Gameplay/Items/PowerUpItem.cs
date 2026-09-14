using UnityEngine;

public class PowerUpItem : MonoBehaviour
{
    [SerializeField] private float respawnTime = 3f;

    private SpriteRenderer _spriteRenderer;
    private Collider2D _collider;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<Collider2D>();
    }

    private void Start()
    {
        SetRandomPosition();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Power up obtenido");

            _spriteRenderer.enabled = false;
            _collider.enabled = false;

            Invoke(nameof(Respawn), respawnTime);
        }
    }

    private void Respawn()
    {
        SetRandomPosition();
        _spriteRenderer.enabled = true;
        _collider.enabled = true;
    }

    private void SetRandomPosition()
    {
        float positionX;

        if (Random.Range(0, 2) == 0)
        {
            positionX = -2f;
        }
        else
        {
            positionX = 2f;
        }

        transform.position = new Vector2(positionX, transform.position.y);
    }
}
using UnityEngine;

public class PowerUpItem : MonoBehaviour
{
    [SerializeField] private float _respawnTime = 3f;
    [SerializeField] private GameObject _shieldP1;
    [SerializeField] private GameObject _shieldP2;
    [SerializeField] private float _shieldDuration = 5f;
    [SerializeField] private float _minY = -3f;
    [SerializeField] private float _maxY = 3f;

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
        if (other.TryGetComponent<Movement>(out Movement player))
        {
            Debug.Log("Power up agarrado");

            ActivateShield(other.gameObject.name);

            _spriteRenderer.enabled = false;
            _collider.enabled = false;

            Invoke(nameof(Respawn), _respawnTime);
        }
    }

    private void ActivateShield(string playerName)
    {
        if (playerName == "Player1")
        {
            CancelInvoke(nameof(DeactivateShieldP1));
            _shieldP1.SetActive(true);
            Invoke(nameof(DeactivateShieldP1), _shieldDuration);
        }
        else if (playerName == "Player2")
        {
            CancelInvoke(nameof(DeactivateShieldP2));
            _shieldP2.SetActive(true);
            Invoke(nameof(DeactivateShieldP2), _shieldDuration);
        }
    }

    private void DeactivateShieldP1()
    {
        _shieldP1.SetActive(false);
    }

    private void DeactivateShieldP2()
    {
        _shieldP2.SetActive(false);
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

        float positionY = Random.Range(_minY, _maxY);

        transform.position = new Vector2(positionX, positionY);
    }
}
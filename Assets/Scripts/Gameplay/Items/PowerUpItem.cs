using UnityEngine;

public class PowerUpItem : MonoBehaviour
{
    [SerializeField] private float _respawnTime = 5f;
    [SerializeField] private GameObject _shieldP1;
    [SerializeField] private GameObject _shieldP2;
    [SerializeField] private float _shieldDuration = 3f;

    [Header("Player 1 X Range")]
    [SerializeField] private float _minXP1 = -4f;
    [SerializeField] private float _maxXP1 = -2f;

    [Header("Player 2 X Range")]
    [SerializeField] private float _minXP2 = 2f;
    [SerializeField] private float _maxXP2 = 4f;

    [Header("Y Range")]
    [SerializeField] private float _minY = -2f;
    [SerializeField] private float _maxY = 2f;

    [SerializeField] private ObjectPool _hitSparksPool;

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
            Debug.Log("Power up agarrado por: " + other.gameObject.name);

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
            _hitSparksPool.Get(_shieldP1.transform.position);
            Invoke(nameof(DeactivateShieldP1), _shieldDuration);
        }
        else if (playerName == "Player2")
        {
            CancelInvoke(nameof(DeactivateShieldP2));
            _shieldP2.SetActive(true);
            _hitSparksPool.Get(_shieldP2.transform.position);
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
            positionX = Random.Range(_minXP1, _maxXP1);
        }
        else
        {
            positionX = Random.Range(_minXP2, _maxXP2);
        }

        float positionY = Random.Range(_minY, _maxY);

        transform.position = new Vector2(positionX, positionY);
    }
}
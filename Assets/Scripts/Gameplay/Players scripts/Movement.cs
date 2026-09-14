using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Player ID")]
    [SerializeField] private int _playerNumber = 1;

    [Header("Settings Data")]
    [SerializeField] private PlayerSettings _settingsData;

    [Header("Config Movement Vertical")]
    [SerializeField] private KeyCode _moveUp = KeyCode.W;
    [SerializeField] private KeyCode _moveDown = KeyCode.S;

    [Header("Config Movement Horizontal")]
    [SerializeField] private KeyCode _moveLeft = KeyCode.A;
    [SerializeField] private KeyCode _moveRight = KeyCode.D;

    [Header("Config Speed")]
    [SerializeField] private float _moveSpeed = 300f;

    private Rigidbody2D _rb;
    private SpriteRenderer _spriteRenderer;
    private Vector2 _moveDirection;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        ApplyInitialColor();
        ApplySpeedSettings();
    }

    private void Update()
    {
        float yDirection = 0f;
        float xDirection = 0f;

        if (Input.GetKey(_moveUp))
        {
            yDirection = 1f;
        }

        if (Input.GetKey(_moveDown))
        {
            yDirection = -1f;
        }

        if (Input.GetKey(_moveRight))
        {
            xDirection = 1f;
        }

        if (Input.GetKey(_moveLeft))
        {
            xDirection = -1f;
        }

        _moveDirection = new Vector2(xDirection, yDirection).normalized;
    }

    private void FixedUpdate()
    {
        _rb.AddForce(_moveDirection * _moveSpeed, ForceMode2D.Force);
    }

    private void ApplySpeedSettings()
    {
        if (_playerNumber == 1)
        {
            _moveSpeed = _settingsData.p1Speed;
        }
        else
        {
            _moveSpeed = _settingsData.p2Speed;
        }
    }

    private void ApplyInitialColor()
    { 
        if (_playerNumber == 1)
        {
            _spriteRenderer.color = _settingsData.p1Color;
        }
        else
        {
            _spriteRenderer.color = _settingsData.p2Color;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Boundaries"))
        {
            _spriteRenderer.color = Color.black;
        }

        if (collision.gameObject.CompareTag("Ball"))
        {
            _spriteRenderer.color = new Color(Random.value, Random.value, Random.value);
        }
    }
}



using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Player ID")]
    [SerializeField] private int playerNumber = 1;

    [Header("Settings Data")]
    [SerializeField] private PlayerSettings settingsData;

    [Header("Config Movement")]
    [SerializeField] private KeyCode MoveUp = KeyCode.W;
    [SerializeField] private KeyCode MoveDown = KeyCode.S;

    [Header("Config Speed")]
    public float moveSpeed = 300f;

    private Rigidbody2D rb;
    private SpriteRenderer _spriteRenderer;
    private Vector2 moveDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        ApplyInitialColor();
    }

    private void Update()
    {
        ApplySpeedSettings();

        float yDirection = 0f;

        if (Input.GetKey(MoveUp))
        {
            yDirection = 1f;
        }

        if (Input.GetKey(MoveDown))
        {
            yDirection = -1f;
        }

        moveDirection = new Vector2(0f, yDirection).normalized;
    }

    private void FixedUpdate()
    {
        rb.AddForce(moveDirection * moveSpeed, ForceMode2D.Force);
    }

    private void ApplySpeedSettings()
    {
        if (playerNumber == 1)
        {
            moveSpeed = settingsData.p1Speed;
        }
        else
        {
            moveSpeed = settingsData.p2Speed;
        }
    }

    private void ApplyInitialColor()
    {
        if (playerNumber == 1)
        { 
            _spriteRenderer.color = settingsData.p1Color;
        }
        else
        { 
            _spriteRenderer.color = settingsData.p2Color;
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




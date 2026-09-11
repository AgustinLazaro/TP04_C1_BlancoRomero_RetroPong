
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
    private Vector2 moveDirection;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
}


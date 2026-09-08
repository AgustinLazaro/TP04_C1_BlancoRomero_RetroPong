
using UnityEngine;

public class Movement : MonoBehaviour

{
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
}

using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float _activeDuration = 4f;
    [SerializeField] private float _respawnTime = 3f;
    [SerializeField] private float _fixedDistanceX = 4f;

    private SpriteRenderer _spriteRenderer;
    private Collider2D _collider;
    private float _currentX;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<Collider2D>();
    }

    private void Start()
    {
        SetInitialPosition();
        Invoke(nameof(HideObstacle), _activeDuration);
    }

    private void HideObstacle()
    {
        _spriteRenderer.enabled = false;
        _collider.enabled = false;

        Invoke(nameof(RespawnObstacle), _respawnTime);
    }

    private void RespawnObstacle()
    {
        AlternatePosition();

        _spriteRenderer.enabled = true;
        _collider.enabled = true;

        Invoke(nameof(HideObstacle), _activeDuration);
    }

    private void SetInitialPosition()
    {
        if (Random.Range(0, 2) == 0)
        {
            _currentX = -_fixedDistanceX;
        }
        else
        {
            _currentX = _fixedDistanceX;
        }

        transform.position = new Vector2(_currentX, 0f);
    }

    private void AlternatePosition()
    {
        _currentX = -_currentX;
        transform.position = new Vector2(_currentX, 0f);
    }
}
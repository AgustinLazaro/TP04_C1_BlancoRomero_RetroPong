using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField] private ObjectPool _powerUpPool;
    [SerializeField] private float _spawnInterval = 5f;

    [Header("Shield References")]
    [SerializeField] private GameObject _shieldP1;
    [SerializeField] private GameObject _shieldP2;
    [SerializeField] private float _shieldDuration = 3f;
    [SerializeField] private ObjectPool _hitSparksPool;

    [Header("Player 1 X Range")]
    [SerializeField] private float _minXP1 = -4f;
    [SerializeField] private float _maxXP1 = -2f;

    [Header("Player 2 X Range")]
    [SerializeField] private float _minXP2 = 2f;
    [SerializeField] private float _maxXP2 = 4f;

    [Header("Y Range")]
    [SerializeField] private float _minY = -2f;
    [SerializeField] private float _maxY = 2f;

    private void OnEnable()
    {
        PowerUpItem.OnPowerUpCollected += HandlePowerUpCollected;
    }

    private void OnDisable()
    {
        PowerUpItem.OnPowerUpCollected -= HandlePowerUpCollected;
    }

    private void Start()
    {
        InvokeRepeating(nameof(SpawnPowerUp), _spawnInterval, _spawnInterval);
    }

    private void SpawnPowerUp()
    {
        Vector2 spawnPosition = GetRandomPosition();
        _powerUpPool.Get(spawnPosition);
    }

    private void HandlePowerUpCollected(string playerName)
    {
        if (playerName == "Player1")
        {
            CancelInvoke(nameof(DeactivateShieldP1));
            if (_shieldP1) _shieldP1.SetActive(true);
            if (_hitSparksPool && _shieldP1) _hitSparksPool.Get(_shieldP1.transform.position);
            Invoke(nameof(DeactivateShieldP1), _shieldDuration);
        }
        else if (playerName == "Player2")
        {
            CancelInvoke(nameof(DeactivateShieldP2));
            if (_shieldP2) _shieldP2.SetActive(true);
            if (_hitSparksPool && _shieldP2) _hitSparksPool.Get(_shieldP2.transform.position);
            Invoke(nameof(DeactivateShieldP2), _shieldDuration);
        }
    }

    private void DeactivateShieldP1()
    {
        if (_shieldP1) _shieldP1.SetActive(false);
    }

    private void DeactivateShieldP2()
    {
        if (_shieldP2) _shieldP2.SetActive(false);
    }

    private Vector2 GetRandomPosition()
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

        return new Vector2(positionX, positionY);
    }
}
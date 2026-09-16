using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private ObjectPool _obstaclePool;
    [SerializeField] private float _spawnInterval = 8f;
    [SerializeField] private float _fixedDistanceX = 4f;

    [Header("Y Spawn Range")]
    [SerializeField] private float _minY = -2f;
    [SerializeField] private float _maxY = 2f;

    private float _currentX;

    private void Start()
    {
        SetInitialPositionX();
        InvokeRepeating(nameof(SpawnObstacle), 1f, _spawnInterval);
    }

    private void SpawnObstacle()
    {
        Vector2 spawnPosition = GetSpawnPosition();
        _obstaclePool.Get(spawnPosition);
    }

    private Vector2 GetSpawnPosition()
    {
        _currentX = -_currentX;
        float randomY = Random.Range(_minY, _maxY);
        return new Vector2(_currentX, randomY);
    }

    private void SetInitialPositionX()
    {
        _currentX = (Random.Range(0, 2) == 0) ? -_fixedDistanceX : _fixedDistanceX;
    }
}
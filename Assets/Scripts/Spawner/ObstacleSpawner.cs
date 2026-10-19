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
        // Suggestion: _currentX solo alterna entre -_fixedDistanceX y +_fixedDistanceX, así que de las dos coordenadas solo la Y es random.
        // Si querés que la posición sea random como pide la consigna, sorteá también la X con un Random.Range acotado al centro.
        // Warning: los obstáculos aparecen en x = -4 o x = 4, que es la mitad de cancha de cada jugador, y Obstacle1.prefab está en la layer Default, la misma con la que chocan las paletas.
        // O sea que la paleta puede quedar trabada contra un obstáculo. La consigna los pide "aproximadamente en el centro": achicá el rango de x o mandá los obstáculos a una layer que solo colisione con la pelota, como ya hiciste con PaddleBounds.
        _currentX = -_currentX;
        float randomY = Random.Range(_minY, _maxY);
        return new Vector2(_currentX, randomY);
    }

    private void SetInitialPositionX()
    {
        _currentX = (Random.Range(0, 2) == 0) ? -_fixedDistanceX : _fixedDistanceX;
    }
}
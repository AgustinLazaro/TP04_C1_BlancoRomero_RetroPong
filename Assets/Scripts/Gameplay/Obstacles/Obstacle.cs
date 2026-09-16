using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [Header("Despawn Settings")]
    [SerializeField] private float _minDuration = 3f;
    [SerializeField] private float _maxDuration = 7f;

    private ObjectPool _originPool;

    public void SetPool(ObjectPool pool)
    {
        _originPool = pool;
    }

    private void OnEnable()
    {
        float activeDuration = Random.Range(_minDuration, _maxDuration);
        Invoke(nameof(Despawn), activeDuration);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Despawn));
    }

    private void Despawn()
    {
        if (_originPool)
        {
            _originPool.ReturnToPool(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
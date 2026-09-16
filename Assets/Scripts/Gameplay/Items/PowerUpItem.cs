using UnityEngine;

public class PowerUpItem : MonoBehaviour
{
    [SerializeField] private GameObject _shieldP1;
    [SerializeField] private GameObject _shieldP2;
    [SerializeField] private float _shieldDuration = 3f;
    [SerializeField] private ObjectPool _hitSparksPool;

    private ObjectPool _originPool;

    public void SetPool(ObjectPool pool)
    {
        _originPool = pool;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Movement>(out Movement player))
        {
            Debug.Log("Power up agarrado");

            ActivateShield(other.gameObject.name);

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
}
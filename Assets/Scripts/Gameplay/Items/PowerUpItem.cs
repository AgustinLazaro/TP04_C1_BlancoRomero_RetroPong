using System;
using UnityEngine;

public class PowerUpItem : MonoBehaviour
{
    public static event Action<string> OnPowerUpCollected;

    private ObjectPool _originPool;

    public void SetPool(ObjectPool pool)
    {
        _originPool = pool;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Movement>(out Movement player))
        {
            Debug.Log("Power up agarrado por: " + other.gameObject.name);

            OnPowerUpCollected?.Invoke(other.gameObject.name);

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
}
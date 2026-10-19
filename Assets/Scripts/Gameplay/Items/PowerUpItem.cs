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
            // Suggestion: quedó un Debug.Log de depuración en la entrega. No inunda la consola porque solo suena al agarrar un power up, pero no va en la versión que se publica.
            // Borralo.
            Debug.Log("Power up agarrado por: " + other.gameObject.name);

            // Warning: el jugador se identifica mandando other.gameObject.name, y del otro lado PowerUpSpawner.cs:49 lo compara contra "Player1" y "Player2" escritos a mano.
            // Movement ya tiene un _playerNumber serializado: mandá ese int en el evento y te sacás de encima los dos strings.
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
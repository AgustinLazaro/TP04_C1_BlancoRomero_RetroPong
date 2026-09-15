using UnityEngine;

public class ReturnParticleToPool : MonoBehaviour
{
    private ObjectPool poolOwner;

    public void SetPool(ObjectPool pool)
    {
        poolOwner = pool;
    }

    private void OnParticleSystemStopped()
    {
        if (poolOwner)
        {
           // poolOwner.ReturnToPool(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
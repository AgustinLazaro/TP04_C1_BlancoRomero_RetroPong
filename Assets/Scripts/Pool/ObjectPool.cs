using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    // Suggestion: el [Header] quedó con el carácter roto ("Configuraci?n"), porque el archivo se guardó con una codificación distinta a UTF-8.
    // Reescribí la línea desde el editor y guardá el archivo en UTF-8, así no se propaga a los demás.
    [Header("Configuración del Pool")]
    [SerializeField] private GameObject prefab;
    [SerializeField] private int initialPoolSize = 5;

    private Queue<GameObject> poolQueue;

    private void Awake()
    {
        poolQueue = new Queue<GameObject>();
        InitializePool();
    }

    private void InitializePool()
    {
        int count = 0;
        while (count < initialPoolSize)
        {
            CreateNewInstance();
            count++;
        }
    }

    private GameObject CreateNewInstance()
    {
        GameObject newObject = Instantiate(prefab, transform);
        newObject.SetActive(false);

        ReturnParticleToPool returnScript = newObject.GetComponent<ReturnParticleToPool>();
        if (returnScript)
        {
            returnScript.SetPool(this);
        }

        PowerUpItem powerUpScript = newObject.GetComponent<PowerUpItem>();
        if (powerUpScript)
        {
            powerUpScript.SetPool(this);
        }

        Obstacle obstacleScript = newObject.GetComponent<Obstacle>();
        if (obstacleScript)
        {
            obstacleScript.SetPool(this);
        }

        poolQueue.Enqueue(newObject);
        return newObject;
    }

    public GameObject Get(Vector3 position)
    {
        GameObject objectToSpawn;

        if (poolQueue.Count > 0)
        {
            objectToSpawn = poolQueue.Dequeue();
        }
        else
        {
            // Suggestion: esta rama funciona, pero cuesta leerla: CreateNewInstance ya encola el objeto y después lo desencolás para devolverlo.
            // Es más claro sacar el Enqueue de CreateNewInstance y encolar solo desde InitializePool y desde ReturnToPool.
            objectToSpawn = CreateNewInstance();
            poolQueue.Dequeue();
        }

        objectToSpawn.transform.position = position;
        objectToSpawn.SetActive(true);

        return objectToSpawn;
    }

    public void ReturnToPool(GameObject objectToReturn)
    {
        objectToReturn.SetActive(false);
        poolQueue.Enqueue(objectToReturn);
    }
}
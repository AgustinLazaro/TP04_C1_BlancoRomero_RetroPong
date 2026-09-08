using UnityEngine;

public class CubeRotation : MonoBehaviour
{
    [SerializeField] private KeyCode RotateLeft = KeyCode.Q;
    [SerializeField] private KeyCode RotateRight = KeyCode.E;

    [SerializeField] private float rotationSpeed = 10f;

    private void Update()
    {
        if (Input.GetKeyDown(RotateLeft))
        {
            transform.Rotate(0, 0, rotationSpeed);
        }

        if (Input.GetKeyDown(RotateRight))
        {
            transform.Rotate(0, 0, -rotationSpeed);
        }

        //rotación mas fluida 
        //if (Input.GetKey(RotateLeft))
        //{
        //    transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        //}

        //if (Input.GetKey(RotateRight))
        //{
        //    transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
        //}
    }
}



using UnityEngine;

public class CubeRotation : MonoBehaviour
{
    [SerializeField] private KeyCode _rotateLeft = KeyCode.Q;
    [SerializeField] private KeyCode _rotateRight = KeyCode.E;

    [SerializeField] private float _rotationSpeed = 10f;

    private void Update()
    {
        if (Input.GetKeyDown(_rotateLeft))
        {
            transform.Rotate(0f, 0f, _rotationSpeed);
        }

        if (Input.GetKeyDown(_rotateRight))
        {
            transform.Rotate(0f, 0f, -_rotationSpeed);
        }

        // Suggestion: quedaron diez líneas comentadas con la alternativa de rotación suave.
        // Elegí una de las dos y borrá la otra: el historial de git ya guarda lo que descartaste.
        // Smoother rotation alternative
        //if (Input.GetKey(_rotateLeft))
        //{
        //    transform.Rotate(0f, 0f, _rotationSpeed * Time.deltaTime);
        //}

        //if (Input.GetKey(_rotateRight))
        //{
        //    transform.Rotate(0f, 0f, -_rotationSpeed * Time.deltaTime);
        //}
    }
}


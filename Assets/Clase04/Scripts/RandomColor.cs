using UnityEngine;

public class PlayerColor : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprite;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

 
    public void SetPlayerColor(Color newColor)
    {
        sprite.color = newColor;
    }
}
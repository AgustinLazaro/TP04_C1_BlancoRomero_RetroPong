using UnityEngine;

public class PlayerColor : MonoBehaviour
{
    [Header("Player ID")]
    [SerializeField] private int playerNumber = 1; 

    [Header("Settings Data")]
    [SerializeField] private PlayerSettings settingsData;

    [Header("Visual References")]
    [SerializeField] private SpriteRenderer sprite;

    private void Awake()
    {
        {
            sprite = GetComponent<SpriteRenderer>();
        }
    }

    private void Start()
    {
        ApplyInitialColor();
    }

    private void Update()
    {
        ApplyInitialColor();
    }

    public void ApplyInitialColor()
    {
        if (playerNumber == 1)
        {
            SetPlayerColor(settingsData.p1Color);
        }
        else
        {
            SetPlayerColor(settingsData.p2Color);
        }
    }

    public void SetPlayerColor(Color newColor)
    {
        {
            sprite.color = newColor;
        }
    }
}
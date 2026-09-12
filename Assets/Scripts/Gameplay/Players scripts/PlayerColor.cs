using UnityEngine;

public class PlayerColor : MonoBehaviour
{
    [Header("Player ID")]
    [SerializeField] private int playerNumber = 1;

    [Header("Settings Data")]
    [SerializeField] private PlayerSettings settingsData;

    [Header("Visual References")]
    [SerializeField] private SpriteRenderer sprite;

    private float _lastColorIndex = -1f;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
       InitialColor();
    }

    private void Update()
    {
        MenuColorChange();
    }

    private void MenuColorChange()
    {
        float currentIndex = 0f;

        if (playerNumber == 1)
        {
            currentIndex = settingsData.p1ColorIndex;
        }
        else
        {
            currentIndex = settingsData.p2ColorIndex;
        }

        if (currentIndex != _lastColorIndex)
        {
            InitialColor();
            _lastColorIndex = currentIndex;
        }
    }

    private void InitialColor()
    { 
        if (playerNumber == 1)
        {
            SetPlayerColor(settingsData.p1Color);
            _lastColorIndex = settingsData.p1ColorIndex;
        }
        else
        {
            SetPlayerColor(settingsData.p2Color);
            _lastColorIndex = settingsData.p2ColorIndex;
        }
    }

    private void SetPlayerColor(Color newColor)
    {
        sprite.color = newColor;
    }
}
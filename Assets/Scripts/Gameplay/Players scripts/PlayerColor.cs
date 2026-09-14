using UnityEngine;

public class PlayerColor : MonoBehaviour
{
    [Header("Player ID")]
    [SerializeField] private int _playerNumber = 1;

    [Header("Settings Data")]
    [SerializeField] private PlayerSettings _settingsData;

    private SpriteRenderer _spriteRenderer;
    private float _lastColorIndex = -1f;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        ApplyInitialColor();
    }

    private void Update()
    {
        CheckMenuColorChange();
    }

    private void CheckMenuColorChange()
    {
        float currentIndex = 0f;

        if (_playerNumber == 1)
        {
            currentIndex = _settingsData.p1ColorIndex;
        }
        else
        {
            currentIndex = _settingsData.p2ColorIndex;
        }

        if (currentIndex != _lastColorIndex)
        {
            ApplyInitialColor();
            _lastColorIndex = currentIndex;
        }
    }

    private void ApplyInitialColor()
    {
        if (_playerNumber == 1)
        {
            SetPlayerColor(_settingsData.p1Color);
            _lastColorIndex = _settingsData.p1ColorIndex;
        }
        else
        {
            SetPlayerColor(_settingsData.p2Color);
            _lastColorIndex = _settingsData.p2ColorIndex;
        }
    }

    private void SetPlayerColor(Color newColor)
    {
        _spriteRenderer.color = newColor;
    }
}
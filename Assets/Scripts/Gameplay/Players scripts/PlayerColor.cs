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

    // Suggestion: ApplyInitialColor está escrito dos veces, acá y en Movement.cs:83, y las dos versiones corren en el Start del mismo objeto.
    // Dejá el color en un solo script (este, que ya se ocupa del tema) y sacale a Movement la responsabilidad del color inicial.
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
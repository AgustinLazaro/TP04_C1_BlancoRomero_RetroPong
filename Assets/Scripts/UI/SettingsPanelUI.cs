using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsPanelUI : MonoBehaviour
{
    [Header("Data Sources")]
    [SerializeField] private PlayerSettings _settingsData;
    [SerializeField] private GameSettings _gameSettingsData;

    [Header("Config Player 1")]
    [SerializeField] private Slider _sliderPlayer01;
    [SerializeField] private TextMeshProUGUI _textPlayer01;
    [SerializeField] private Slider _colorSliderP1;
    [SerializeField] private TextMeshProUGUI _textColorP1;

    [Header("Config Player 2")]
    [SerializeField] private Slider _sliderPlayer02;
    [SerializeField] private TextMeshProUGUI _textPlayer02;
    [SerializeField] private Slider _colorSliderP2;
    [SerializeField] private TextMeshProUGUI _textColorP2;

    [Header("Config Match Rules")]
    [SerializeField] private Slider _sliderMatchPoints;
    [SerializeField] private TextMeshProUGUI _textMatchPoints;
    [SerializeField] private Slider _sliderShotClock;
    [SerializeField] private TextMeshProUGUI _textShotClock;

    private void Start()
    {
        _sliderPlayer01.value = _settingsData.p1Speed;
        _sliderPlayer02.value = _settingsData.p2Speed;
        _colorSliderP1.value = _settingsData.p1ColorIndex;
        _colorSliderP2.value = _settingsData.p2ColorIndex;

        _sliderMatchPoints.value = _gameSettingsData.pointsToWin;
        _sliderShotClock.value = _gameSettingsData.shotClockDuration;

        UpdateSpeedPlayer1(_sliderPlayer01.value);
        UpdateSpeedPlayer2(_sliderPlayer02.value);
        UpdateColorPlayer1(_colorSliderP1.value);
        UpdateColorPlayer2(_colorSliderP2.value);

        UpdateMatchPoints(_sliderMatchPoints.value);
        UpdateShotClock(_sliderShotClock.value);

        _sliderPlayer01.onValueChanged.AddListener(UpdateSpeedPlayer1);
        _sliderPlayer02.onValueChanged.AddListener(UpdateSpeedPlayer2);
        _colorSliderP1.onValueChanged.AddListener(UpdateColorPlayer1);
        _colorSliderP2.onValueChanged.AddListener(UpdateColorPlayer2);

        _sliderMatchPoints.onValueChanged.AddListener(UpdateMatchPoints);
        _sliderShotClock.onValueChanged.AddListener(UpdateShotClock);
    }

    private void OnDestroy()
    {
        _sliderPlayer01.onValueChanged.RemoveListener(UpdateSpeedPlayer1);
        _sliderPlayer02.onValueChanged.RemoveListener(UpdateSpeedPlayer2);
        _colorSliderP1.onValueChanged.RemoveListener(UpdateColorPlayer1);
        _colorSliderP2.onValueChanged.RemoveListener(UpdateColorPlayer2);

        _sliderMatchPoints.onValueChanged.RemoveListener(UpdateMatchPoints);
        _sliderShotClock.onValueChanged.RemoveListener(UpdateShotClock);
    }

    private void UpdateMatchPoints(float value)
    {
        int points = Mathf.RoundToInt(value);
        _gameSettingsData.pointsToWin = points;
        _textMatchPoints.text = points.ToString();
    }

    private void UpdateShotClock(float value)
    {
        float seconds = Mathf.Round(value);
        _gameSettingsData.shotClockDuration = seconds;
        _textShotClock.text = seconds.ToString("F0") + "s";
    }

    private void UpdateSpeedPlayer1(float newSpeed)
    {
        _textPlayer01.text = newSpeed.ToString("F0");
        _settingsData.p1Speed = newSpeed;
    }

    private void UpdateSpeedPlayer2(float newSpeed)
    {
        _textPlayer02.text = newSpeed.ToString("F0");
        _settingsData.p2Speed = newSpeed;
    }

    private void UpdateColorPlayer1(float value)
    {
        _settingsData.p1ColorIndex = value;

        if (value == 0f)
        {
            _settingsData.p1Color = Color.white;
            _textColorP1.text = "BASE";
        }
        else if (value == 1f)
        {
            _settingsData.p1Color = Color.bisque;
            _textColorP1.text = "bisque";
        }
        else if (value == 2f)
        {
            _settingsData.p1Color = Color.blue;
            _textColorP1.text = "AZUL";
        }
        else if (value == 3f)
        {
            _settingsData.p1Color = Color.yellow;
            _textColorP1.text = "AMARILLO";
        }
        else if (value == 4f)
        {
            _settingsData.p1Color = Color.cyan;
            _textColorP1.text = "CELESTE";
        }
    }

    private void UpdateColorPlayer2(float value)
    {
        _settingsData.p2ColorIndex = value;

        if (value == 0f)
        {
            _settingsData.p2Color = new Color(1f, 0.44f, 0.44f);
            _textColorP2.text = "BASE";
        }
        else if (value == 1f)
        {
            _settingsData.p2Color = Color.blueViolet;
            _textColorP2.text = "VIOLETA";
        }
        else if (value == 2f)
        {
            _settingsData.p2Color = Color.blue;
            _textColorP2.text = "AZUL";
        }
        else if (value == 3f)
        {
            _settingsData.p2Color = Color.yellow;
            _textColorP2.text = "AMARILLO";
        }
        else if (value == 4f)
        {
            _settingsData.p2Color = Color.cyan;
            _textColorP2.text = "CELESTE";
        }
    }
}
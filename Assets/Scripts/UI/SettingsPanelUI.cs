using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsPanelUI : MonoBehaviour
{
    [Header("Data Source")]
    [SerializeField] private PlayerSettings settingsData;

    [Header("Config Player 1")]
    [SerializeField] private Slider sliderPlayer01;
    [SerializeField] private TextMeshProUGUI textPlayer01;
    [SerializeField] private Slider colorSliderP1;
    [SerializeField] private TextMeshProUGUI textColorP1;

    [Header("Config Player 2")]
    [SerializeField] private Slider sliderPlayer02;
    [SerializeField] private TextMeshProUGUI textPlayer02;
    [SerializeField] private Slider colorSliderP2;
    [SerializeField] private TextMeshProUGUI textColorP2;

    private void Start()
    {
       
        sliderPlayer01.value = settingsData.p1Speed;
        sliderPlayer02.value = settingsData.p2Speed;
        colorSliderP1.value = settingsData.p1ColorIndex;
        colorSliderP2.value = settingsData.p2ColorIndex;

        UpdateSpeedPlayer1(sliderPlayer01.value);
        UpdateSpeedPlayer2(sliderPlayer02.value);
        UpdateColorPlayer1(colorSliderP1.value);
        UpdateColorPlayer2(colorSliderP2.value);

        sliderPlayer01.onValueChanged.AddListener(UpdateSpeedPlayer1);
        sliderPlayer02.onValueChanged.AddListener(UpdateSpeedPlayer2);
        colorSliderP1.onValueChanged.AddListener(UpdateColorPlayer1);
        colorSliderP2.onValueChanged.AddListener(UpdateColorPlayer2);
    }

    private void UpdateSpeedPlayer1(float newSpeed)
    {
        textPlayer01.text = newSpeed.ToString("F0");
        settingsData.p1Speed = newSpeed;
    }

    private void UpdateSpeedPlayer2(float newSpeed)
    {
        textPlayer02.text = newSpeed.ToString("F0");
        settingsData.p2Speed = newSpeed;
    }

    private void UpdateColorPlayer1(float value)
    {
        settingsData.p1ColorIndex = value;

        if (value == 0f)
        {
            settingsData.p1Color = Color.white;
            textColorP1.text = "BASE";
        }
        else if (value == 1f)
        {
            settingsData.p1Color = Color.bisque;
            textColorP1.text = "bisque";
        }
        else if (value == 2f)
        {
            settingsData.p1Color = Color.blue;
            textColorP1.text = "AZUL";
        }
        else if (value == 3f)
        {
            settingsData.p1Color = Color.yellow;
            textColorP1.text = "AMARILLO";
        }
        else if (value == 4f)
        {
            settingsData.p1Color = Color.cyan;
            textColorP1.text = "CELESTE";
        }
    }

    private void UpdateColorPlayer2(float value)
    {
        settingsData.p2ColorIndex = value;

        if (value == 0f)
        {
            settingsData.p2Color = new Color(1f, 0.44f, 0.44f);
            textColorP2.text = "BASE";
        }
        else if (value == 1f)
        {
            settingsData.p2Color = Color.blueViolet;
            textColorP2.text = "VIOLETA";
        }
        else if (value == 2f)
        {
            settingsData.p2Color = Color.blue;
            textColorP2.text = "AZUL";
        }
        else if (value == 3f)
        {
            settingsData.p2Color = Color.yellow;
            textColorP2.text = "AMARILLO";
        }
        else if (value == 4f)
        {
            settingsData.p2Color = Color.cyan;
            textColorP2.text = "CELESTE";
        }
    }
}
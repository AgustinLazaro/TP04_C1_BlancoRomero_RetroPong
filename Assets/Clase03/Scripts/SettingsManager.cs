using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsManager : MonoBehaviour
{
    [Header("Config Player 1")]
    [SerializeField] private Slider sliderPlayer01;
    [SerializeField] private TextMeshProUGUI textPlayer01;
    [SerializeField] private Movement scriptPlayer1;
    [SerializeField] private Slider colorSliderP1;
    [SerializeField] private TextMeshProUGUI textColorP1;
    [SerializeField] private PlayerColor colorScriptPlayer1;

    [Header("Config Player 2")]
    [SerializeField] private Slider sliderPlayer02;
    [SerializeField] private TextMeshProUGUI textPlayer02;
    [SerializeField] private Movement scriptPlayer2;
    [SerializeField] private Slider colorSliderP2;
    [SerializeField] private TextMeshProUGUI textColorP2;
    [SerializeField] private PlayerColor colorScriptPlayer2;

    private void Start()
    {
       
        sliderPlayer01.onValueChanged.AddListener(UpdateSpeedPlayer1);
        sliderPlayer02.onValueChanged.AddListener(UpdateSpeedPlayer2);
        colorSliderP1.onValueChanged.AddListener(UpdateColorPlayer1);
        colorSliderP2.onValueChanged.AddListener(UpdateColorPlayer2);

       
        UpdateSpeedPlayer1(sliderPlayer01.value);
        UpdateSpeedPlayer2(sliderPlayer02.value);
        UpdateColorPlayer1(colorSliderP1.value);
        UpdateColorPlayer2(colorSliderP2.value);
    }

    private void UpdateSpeedPlayer1(float newSpeed)
    {
        textPlayer01.text = newSpeed.ToString();
        scriptPlayer1.moveSpeed = newSpeed;
    }

    private void UpdateSpeedPlayer2(float newSpeed)
    {
        textPlayer02.text = newSpeed.ToString();
        scriptPlayer2.moveSpeed = newSpeed;
    }

    private void UpdateColorPlayer1(float value)
    {
        if (value == 0f)
        {
            colorScriptPlayer1.SetPlayerColor(Color.white); 
            textColorP1.text = "BASE";
        }
        else if (value == 1f)
        {
            colorScriptPlayer1.SetPlayerColor(Color.bisque);
            textColorP1.text = "bisque";
        }
        else if (value == 2f)
        {
            colorScriptPlayer1.SetPlayerColor(Color.blue);
            textColorP1.text = "AZUL";
        }
        else if (value == 3f)
        {
            colorScriptPlayer1.SetPlayerColor(Color.yellow);
            textColorP1.text = "AMARILLO";
        }
        else if (value == 4f)
        {
            colorScriptPlayer1.SetPlayerColor(Color.cyan);
            textColorP1.text = "CELESTE";
        }
    }

    private void UpdateColorPlayer2(float value)
    {
        if (value == 0f)
        {
            colorScriptPlayer2.SetPlayerColor(new Color(1f, 0.44f, 0.44f));
            textColorP2.text = "BASE";
        }
        else if (value == 1f)
        {
            colorScriptPlayer2.SetPlayerColor(Color.blueViolet);
            textColorP2.text = "VIOLETA";
        }
        else if (value == 2f)
        {
            colorScriptPlayer2.SetPlayerColor(Color.blue);
            textColorP2.text = "AZUL";
        }
        else if (value == 3f)
        {
            colorScriptPlayer2.SetPlayerColor(Color.yellow);
            textColorP2.text = "AMARILLO";
        }
        else if (value == 4f)
        {
            colorScriptPlayer2.SetPlayerColor(Color.cyan);
            textColorP2.text = "CELESTE";
        }
    }
}
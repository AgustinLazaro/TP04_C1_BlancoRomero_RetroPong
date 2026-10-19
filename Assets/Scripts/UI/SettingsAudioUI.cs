using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsAudioUI : MonoBehaviour
{
    [Header("Mixer Reference")]
    [SerializeField] private AudioMixer _audioMixer;

    [Header("Sliders")]
    [SerializeField] private Slider _masterSlider;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _sfxSlider;

    private void Start()
    {
        InitializeSlider(_masterSlider, "MasterVolume");
        InitializeSlider(_musicSlider, "MusicVolume");
        InitializeSlider(_sfxSlider, "SFXVolume");

        _masterSlider.onValueChanged.AddListener(SetMasterVolume);
        _musicSlider.onValueChanged.AddListener(SetMusicVolume);
        _sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    private void OnDestroy()
    {
        _masterSlider.onValueChanged.RemoveListener(SetMasterVolume);
        _musicSlider.onValueChanged.RemoveListener(SetMusicVolume);
        _sfxSlider.onValueChanged.RemoveListener(SetSFXVolume);
    }

    private void InitializeSlider(Slider slider, string paramName)
    {
        if (_audioMixer.GetFloat(paramName, out float currentDb))
        {
            slider.value = Mathf.Pow(10f, currentDb / 20f);
        }
    }

    public void SetMasterVolume(float value)
    {
        // Bug: en Gameplay.unity los tres sliders de volumen tienen m_MinValue: 0 (en MainMenu.unity sí están en 0.0001).
        // Con value = 0, Mathf.Log10(0) devuelve -Infinity y el AudioMixer queda con un parámetro inválido del que ya no se recupera hasta reiniciar.
        // Poné el mínimo en 0.0001 también en la escena de juego, o clampeá acá: Mathf.Log10(Mathf.Max(value, 0.0001f)) * 20f.
        _audioMixer.SetFloat("MasterVolume", Mathf.Log10(value) * 20f);
    }

    public void SetMusicVolume(float value)
    {
        _audioMixer.SetFloat("MusicVolume", Mathf.Log10(value) * 20f);
    }

    public void SetSFXVolume(float value)
    {
        _audioMixer.SetFloat("SFXVolume", Mathf.Log10(value) * 20f);
    }
}
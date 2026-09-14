using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [Header("Config UI Panels")]
    [SerializeField] private GameObject _mainMenuPanel;
    [SerializeField] private GameObject _optionsPanel;
    [SerializeField] private GameObject _creditsPanel;

    [Header("Config Buttons")]
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _optionsButton;
    [SerializeField] private Button _creditsButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _backOptionsButton;
    [SerializeField] private Button _backCreditsButton;

    private void Start()
    {
        _playButton.onClick.AddListener(PlayGame);
        _optionsButton.onClick.AddListener(ShowOptions);
        _creditsButton.onClick.AddListener(ShowCredits);
        _exitButton.onClick.AddListener(ExitGame);

        _backOptionsButton.onClick.AddListener(HideOptions);
        _backCreditsButton.onClick.AddListener(HideCredits);
    }

    private void OnDestroy()
    {
        _playButton.onClick.RemoveListener(PlayGame);
        _optionsButton.onClick.RemoveListener(ShowOptions);
        _creditsButton.onClick.RemoveListener(ShowCredits);
        _exitButton.onClick.RemoveListener(ExitGame);

        _backOptionsButton.onClick.RemoveListener(HideOptions);
        _backCreditsButton.onClick.RemoveListener(HideCredits);
    }

    private void PlayGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    private void ShowOptions()
    {
        _optionsPanel.SetActive(true);
    }

    private void HideOptions()
    {
        _optionsPanel.SetActive(false);
    }

    private void ShowCredits()
    {
        _creditsPanel.SetActive(true);
    }

    private void HideCredits()
    {
        _creditsPanel.SetActive(false);
    }

    private void ExitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayMenuUI : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject _pauseMenuPanel;
    [SerializeField] private GameObject _optionsPanel;

    [Header("Buttons")]
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _optionsButton;
    [SerializeField] private Button _backToMenuButton;
    [SerializeField] private Button _backOptionsButton;

    private void Start()
    {
        Time.timeScale = 1f;

        _continueButton.onClick.AddListener(TogglePause);
        _optionsButton.onClick.AddListener(ShowOptions);
        _backToMenuButton.onClick.AddListener(ReturnToMainMenu);
        _backOptionsButton.onClick.AddListener(HideOptions);
    }

    private void OnDestroy()
    {
        _continueButton.onClick.RemoveListener(TogglePause);
        _optionsButton.onClick.RemoveListener(ShowOptions);
        _backToMenuButton.onClick.RemoveListener(ReturnToMainMenu);
        _backOptionsButton.onClick.RemoveListener(HideOptions);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_optionsPanel.activeSelf)
            {
                HideOptions();
            }
            else
            {
                TogglePause();
            }
        }
    }

    public void TogglePause()
    {
        _pauseMenuPanel.SetActive(!_pauseMenuPanel.activeSelf);

        if (_pauseMenuPanel.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    private void ShowOptions()
    {
        _optionsPanel.SetActive(true);
    }

    private void HideOptions()
    {
        _optionsPanel.SetActive(false);
    }

    private void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
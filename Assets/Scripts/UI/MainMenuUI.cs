using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [Header("Config UI panels")]
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject creditsPanel;

    [Header("Config Buttons")]
   
    [SerializeField] private Button playButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button creditsButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button backOptionsButton;
    [SerializeField] private Button backCreditsButton;
    private void Start()
    {
        playButton.onClick.AddListener(PlayButton);
        optionsButton.onClick.AddListener(ShowOptions);
        creditsButton.onClick.AddListener(ShowCredits);
        exitButton.onClick.AddListener(ExitButton);

       
        backOptionsButton.onClick.AddListener(HideOptions);
        backCreditsButton.onClick.AddListener(HideCredits);
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("Gameplay"); 
    }

    public void ShowOptions()
    {
        optionsPanel.SetActive(true);
    }

    public void HideOptions()
    {
        optionsPanel.SetActive(false);
    }

    public void ShowCredits()
    {
        creditsPanel.SetActive(true);
    }

    public void HideCredits()
    {
        creditsPanel.SetActive(false);
    }



    public void ExitButton()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}

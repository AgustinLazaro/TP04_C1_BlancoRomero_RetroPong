using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI; 
public class PauseMenuManager : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject pauseMenuPanel;
    [SerializeField] private GameObject optionsPanel;

    [Header("Buttons")]
    [SerializeField] private Button continueButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button backToMenuButton;
    [SerializeField] private Button backOptionsButton;

    private void Start()
    {
        Time.timeScale = 1f;

        continueButton.onClick.AddListener(TogglePause);
        optionsButton.onClick.AddListener(ShowOptions);
        backToMenuButton.onClick.AddListener(ReturnToMainMenu);

        backOptionsButton.onClick.AddListener(HideOptions);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            if (optionsPanel.activeSelf)
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
        pauseMenuPanel.SetActive(!pauseMenuPanel.activeSelf);

        if (pauseMenuPanel.activeSelf)
        {
            Time.timeScale = 0f; 
        }
        else
        {
            Time.timeScale = 1f; 
        }
    }

    public void ShowOptions()
    {
        optionsPanel.SetActive(true);
    }

    public void HideOptions()
    {
        optionsPanel.SetActive(false);
    }

    public void ReturnToMainMenu()
    {
       
        Time.timeScale = 1f;

       
        SceneManager.LoadScene("MainMenu");
    }
}
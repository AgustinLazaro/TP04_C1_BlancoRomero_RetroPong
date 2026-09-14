using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class HUDManager : MonoBehaviour
{
    [Header("Score Texts")]
    [SerializeField] private TextMeshProUGUI _textScoreP1;
    [SerializeField] private TextMeshProUGUI _textScoreP2;

    [Header("Timer Text")]
    [SerializeField] private TextMeshProUGUI _textShotClock;

    [Header("Victory Panel")]
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _winP1;
    [SerializeField] private GameObject _winP2;

    [Header("Victory Panel Buttons")]
    [SerializeField] private Button _buttonReplay;
    [SerializeField] private Button _buttonBackMenu;

    private void Awake()
    {
        _buttonReplay.onClick.AddListener(RestartGame);
        _buttonBackMenu.onClick.AddListener(BackToMenu);
    }

    private void OnDestroy()
    {
        _buttonReplay.onClick.RemoveListener(RestartGame);
        _buttonBackMenu.onClick.RemoveListener(BackToMenu);
    }

    public void UpdateScore(int p1Score, int p2Score)
    {
        _textScoreP1.text = p1Score.ToString();
        _textScoreP2.text = p2Score.ToString();
    }

    public void UpdateShotClock(float timeRemaining)
    {
        _textShotClock.text = timeRemaining.ToString("F0");
    }

    public void ShowVictory(int winnerPlayer)
    {
        _winPanel.SetActive(true);
        _winP1.SetActive(winnerPlayer == 1);
        _winP2.SetActive(winnerPlayer == 2);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
using UnityEngine;
using TMPro;

public class HUDManager : MonoBehaviour
{
    [Header("Score Texts")]
    [SerializeField] private TextMeshProUGUI _textScoreP1;
    [SerializeField] private TextMeshProUGUI _textScoreP2;

    [Header("Timer Text")]
    [SerializeField] private TextMeshProUGUI _textShotClock;

    public void UpdateScore(int p1Score, int p2Score)
    {
        _textScoreP1.text = p1Score.ToString();
        _textScoreP2.text = p2Score.ToString();
    }

    public void UpdateShotClock(float timeRemaining)
    {
        _textShotClock.text = timeRemaining.ToString("F0");
    }
}

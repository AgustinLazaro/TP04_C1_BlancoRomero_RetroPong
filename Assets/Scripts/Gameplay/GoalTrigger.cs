using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private int _scoringPlayer;
    [SerializeField] private MatchManager _matchManager;

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            _matchManager.ScoreGoal(_scoringPlayer);
        }
    }
}
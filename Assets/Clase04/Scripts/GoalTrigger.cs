using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private int _scoringPlayer;
    [SerializeField] private MatchManager _matchManager;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            _matchManager.ScoreGoal(_scoringPlayer);
        }
    }
}
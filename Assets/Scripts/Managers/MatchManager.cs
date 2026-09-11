using UnityEngine;

public class MatchManager : MonoBehaviour
{
    [Header("UIreference")]
    [SerializeField] private HUDManager _hudManager;

    [Header("Config")]
    [SerializeField] private GameSettings _settings;

    [Header("Ball Reference")]
    [SerializeField] private BallMovement _ball;

    private float _shotClockTimer;
    private bool _isTimerRunning;

    private int _player1Score;
    private int _player2Score;

    private void Start()
    {
        _hudManager.UpdateScore(_player1Score,_player2Score);
        StartRound();
    }

    private void Update()
    {
        if (_isTimerRunning == true)
        {
            ShotClockUpdate();
        }
    }

    private void ShotClockUpdate()
    {
        _shotClockTimer -= Time.deltaTime;

        if (_shotClockTimer <= 0f)
        {
            _shotClockTimer = 0f;
            _isTimerRunning = false;

            _hudManager.UpdateShotClock(_shotClockTimer);

            ShotClockTimeout();
        }
        else
        {
            //decreciendo
            _hudManager.UpdateShotClock(_shotClockTimer); 
        }
    }

    private void ShotClockTimeout()
    {
        if (_ball.transform.position.x < 0f)
        {
            _player2Score++;
            Debug.Log($"Punto Jugador 2. puntaje: {_player1Score} - {_player2Score}");
        }
        else
        {
            _player1Score++;
            Debug.Log($"Punto Jugador 1. puntaje: {_player1Score} - {_player2Score}");
        }

        _hudManager.UpdateScore(_player1Score, _player2Score);
        CheckWinCondition();
    }

    public void ScoreGoal(int scoringPlayer)
    {
        if (scoringPlayer == 2)
        {
            _player2Score++;
            Debug.Log($"Punto Jugador 2. puntaje: {_player1Score} - {_player2Score}");
        }
        else if (scoringPlayer == 1)
        {
            _player1Score++;
            Debug.Log($"Punto Jugador 1. puntaje: {_player1Score} - {_player2Score}");
        }
        _hudManager.UpdateScore(_player1Score, _player2Score);
        CheckWinCondition();
    }

    private void CheckWinCondition()
    {
        if (_player1Score >= _settings.PointsToWin)
        {
            Debug.Log("JUGADOR 1 GANA");
            _ball.ResetBall();
            _isTimerRunning = false;
        }

        else if (_player2Score >= _settings.PointsToWin)
        {
            Debug.Log("JUGADOR 2 GANA");
            _ball.ResetBall();
            _isTimerRunning = false;
        }

        else
        {
            StartRound();
        }
    }

    private void StartRound()
    {
        _shotClockTimer = _settings.ShotClockDuration;
        _isTimerRunning = true;

        _hudManager.UpdateShotClock(_shotClockTimer);

        _ball.ResetBall();
        _ball.LaunchBall();
    }

}



using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Scriptable Objects/GameSettings")]
public class GameSettings : ScriptableObject
{
    [Header("Default Values")]
    [SerializeField] private int defaultPointsToWin = 3;
    [SerializeField] private float defaultShotClockDuration = 20f;
    [SerializeField] private float defaultInitialBallSpeed = 300f;
    [SerializeField] private float defaultSpeedPerHit = 15f;

    [Header("Match Rules")]
    public int pointsToWin = 3;

    [Header("Timers")]
    public float shotClockDuration = 20f;

    [Header("Ball Mechanics")]
    public float initialBallSpeed = 300f;
    public float speedPerHit = 15f;

    public int PointsToWin => pointsToWin;
    public float ShotClockDuration => shotClockDuration;
    public float InitialBallSpeed => initialBallSpeed; 
    public float SpeedPerHit => speedPerHit;

    private void OnEnable()
    {
        ResetDefaults();
    }

    private void ResetDefaults()
    {
        pointsToWin = defaultPointsToWin;
        shotClockDuration = defaultShotClockDuration;
        initialBallSpeed = defaultInitialBallSpeed;
        speedPerHit = defaultSpeedPerHit;
    }
}
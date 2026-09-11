using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Scriptable Objects/GameSettings")]
public class GameSettings : ScriptableObject
{
    [Header("Match Rules")]
    [Tooltip("Puntos necesarios para ganar")]
    [SerializeField] private int _pointsToWin = 3;

    [Header("Timers")]
    [Tooltip("Tiempo limite en segundos para marcar")]
    [SerializeField] private float _shotClockDuration = 20f;

    [Header("Ball Mechanics")]
    [SerializeField] private float _initialBallSpeed = 5f;
    [SerializeField] private float _speedPerHit = 0.5f;


    public int PointsToWin => _pointsToWin;
    public float ShotClockDuration => _shotClockDuration;
    public float InitialBallSpeed => _initialBallSpeed;
    public float SpeedPerHit => _speedPerHit;
}

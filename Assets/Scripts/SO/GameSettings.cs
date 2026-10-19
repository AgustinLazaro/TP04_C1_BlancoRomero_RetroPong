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
    // Warning: los cuatro campos de abajo son public y justo después declarás properties de solo lectura para los mismos valores.
    // Mientras el campo siga siendo public, la property no protege nada: cualquiera puede escribir settings.pointsToWin. Pasalos a [SerializeField] private y dejá solo las properties, con un método Set por cada valor que el menú necesite cambiar.
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

    // Warning: la idea de no dejar que el SO se ensucie entre sesiones está bien, pero OnEnable no es un buen lugar para resetear.
    // Se dispara cada vez que Unity carga el asset (y en el editor después de cada recompilación), así que si el asset se descarga al cambiar de MainMenu a Gameplay, los valores que el jugador eligió en el menú se pierden.
    // Hacé el reset explícito desde el menú principal, o copiá el SO a una clase de estado de partida al empezar y trabajá sobre esa copia.
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
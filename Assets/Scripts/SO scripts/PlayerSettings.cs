using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSettings", menuName = "Scriptable Objects/PlayerSettings")]
public class PlayerSettings : ScriptableObject
{
    [Header("Settings player 1")] 
    public float p1Speed = 10f;
    public float p1ColorIndex = 0f;
    public Color p1Color = Color.white;

    [Header("Settings player 2")]
    public float p2Speed = 10f;
    public float p2ColorIndex = 0f;
    public Color p2Color = new Color(1f, 0.44f, 0.44f);
}

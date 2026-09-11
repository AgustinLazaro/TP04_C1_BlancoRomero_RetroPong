using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSettings", menuName = "Scriptable Objects/PlayerSettings")]
public class PlayerSettings : ScriptableObject
{
    [Header("Default Values")]
    [SerializeField] private float defaultP1Speed = 300f;
    [SerializeField] private float defaultP2Speed = 300f;
    [SerializeField] private float defaultP1ColorIndex = 0f;
    [SerializeField] private float defaultP2ColorIndex = 0f;
    [SerializeField] private Color defaultP1Color = Color.white;
    [SerializeField] private Color defaultP2Color = new Color(1f, 0.44f, 0.44f);

    [Header("Settings player 1")]
    public float p1Speed = 300f;
    public float p1ColorIndex = 0f;
    public Color p1Color = Color.white;

    [Header("Settings player 2")]
    public float p2Speed = 300f;
    public float p2ColorIndex = 0f;
    public Color p2Color = new Color(1f, 0.44f, 0.44f);

    private void OnEnable()
    {
        ResetDefaults();
    }

    //puedo usar getters? ni idea. la variable que va mutando
    private void ResetDefaults()
    {
        p1Speed = defaultP1Speed;
        p2Speed = defaultP2Speed;
        p1ColorIndex = defaultP1ColorIndex;
        p2ColorIndex = defaultP2ColorIndex;
        p1Color = defaultP1Color;
        p2Color = defaultP2Color;
    }
}
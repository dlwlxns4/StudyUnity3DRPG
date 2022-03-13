using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Narration/Line")]
public class NarrationLine : ScriptableObject
{
    [SerializeField]
    private NarrationCharacter speaker;
    [SerializeField]
    private string text;

    public NarrationCharacter Speaker => speaker;
    public string Text => text;
}

using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "ScriptableObjects/Narration/Dialogue/Dialogue")]
public class Dialogue : ScriptableObject
{
    [SerializeField]
    private DialogueNode firstNode;
    public DialogueNode FirstNode => firstNode;
    [SerializeField]
    private Sprite portrait;
    public Sprite Portrait => portrait;
}

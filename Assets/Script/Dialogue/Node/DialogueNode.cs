using UnityEngine;

public abstract class DialogueNode : ScriptableObject
{
    [SerializeField]
    private NarrationLine dialogueLine;

    public NarrationLine DialogueLine => dialogueLine;

    public abstract bool CanBeFollowedByNode(DialogueNode node);
    public abstract void Accept(DialogueNodeVisitor visitor);
}

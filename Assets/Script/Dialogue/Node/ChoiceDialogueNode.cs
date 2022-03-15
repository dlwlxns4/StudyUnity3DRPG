using System.Linq;
using System;
using UnityEngine;

[Serializable]
public class DialogueChoice
{
    [SerializeField]
    private string choicePreview;
    [SerializeField]
    private DialogueNode choiceNode;

    public string ChoicePreview => choicePreview;
    public DialogueNode ChoiceNode => choiceNode;
}

[CreateAssetMenu(menuName = "ScriptableObjects/Narration/Dialogue/Node/Choice")]
public class ChoiceDialogueNode : DialogueNode
{
    [SerializeField]
    private DialogueChoice[] canChoiceNodes;
    public DialogueChoice[] CanChoiceNodes => canChoiceNodes;

    public override bool CanBeFollowedByNode(DialogueNode node)
    {
        return canChoiceNodes.Any(x => x.ChoiceNode == node);
    }

    public override void Accept(DialogueNodeVisitor visitor)
    {
        visitor.Visit(this);
    }
}

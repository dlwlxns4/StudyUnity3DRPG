using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Narration/Dialogue/Node/Quest")]
public class QuestDialogueNode : DialogueNode
{
    [SerializeField]
    private DialogueNode nextNode;
    public DialogueNode NextNode => nextNode;

    public override bool CanBeFollowedByNode(DialogueNode node)
    {
        return nextNode==node;
    }

    public override void Accept(DialogueNodeVisitor visitor)
    {
        visitor.Visit(this);
    }
}

using System.Linq;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DialogueChoice
{
    [SerializeField]
    private string choicePreview;
    [SerializeField]
    public DialogueNode choiceNode;
    [SerializeField]

    public string ChoicePreview
    {
        get
        {
            return choicePreview;
        }
        set
        {
            choicePreview = value;
        }
    }
    public DialogueNode ChoiceNode 
    {
        get
        {
            return choiceNode;
        }
        set
        {
            choiceNode = value;
        }
    }
}

[CreateAssetMenu(menuName = "ScriptableObjects/Narration/Dialogue/Node/Choice")]
public class ChoiceDialogueNode : DialogueNode
{
    [SerializeField]
    private List<DialogueChoice> canChoiceNodes;
    public List<DialogueChoice> CanChoiceNodes => canChoiceNodes;
    

    public override bool CanBeFollowedByNode(DialogueNode node)
    {
        return canChoiceNodes.Any(x => x.ChoiceNode == node);
    }

    public override void Accept(DialogueNodeVisitor visitor)
    {
        visitor.Visit(this);
    }
}

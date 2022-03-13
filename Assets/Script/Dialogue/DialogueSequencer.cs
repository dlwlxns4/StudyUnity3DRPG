using UnityEngine;

public class DialogueSequencer
{
    public delegate void DialogueCallBack(Dialogue dialogue);
    public delegate void DialogueNodeCallBack(DialogueNode node);

    public DialogueCallBack OnDialogueStart;
    public DialogueCallBack OnDialogueEnd;

    public DialogueNodeCallBack OnDialogueNodeEnd;
    public DialogueNodeCallBack OnDialogueNodeStart;

    private Dialogue currentDialogue;
    private DialogueNode currentNode;

    public void StartDialogue(Dialogue dialogue)
    {
        if(currentDialogue == null)
        {
            currentDialogue = dialogue;
            OnDialogueStart?.Invoke(currentDialogue);
            StartDialogueNode(currentDialogue.FirstNode);
        }
    }

    private bool CanStartNode(DialogueNode node)
    {
        return (currentNode == null || node == null || currentNode.CanBeFollowedByNode(node));
    }

    public void StartDialogueNode(DialogueNode node)
    {
        if(CanStartNode(node))
        {

            StopDialogueNode(currentNode);
            currentNode = node;

            if(currentNode != null)
            {
                OnDialogueNodeStart?.Invoke(currentNode);
                Debug.Log(currentNode.DialogueLine.Text);
            }
            else
            {
                EndDialogue(currentDialogue);
            }
        }
    }

    private void StopDialogueNode(DialogueNode node)
    {
        if(currentNode == node)
        {
            OnDialogueNodeEnd?.Invoke(currentNode);
            currentNode=null;
        }
    }

    public void EndDialogue(Dialogue dialogue)
    {
        if (currentDialogue == dialogue)
        {
            StopDialogueNode(currentNode);
            OnDialogueEnd?.Invoke(currentDialogue);
            currentDialogue = null;
        }
    }
}

using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObjects/Narration/Dialogue/Dialogue Channel")]
public class DialogueChannel : ScriptableObject
{
    public delegate void DialogueCallBack(Dialogue dialogue);
    public DialogueCallBack OnDialogueRequsted;
    public DialogueCallBack OnDialogueStart;
    public DialogueCallBack OnDialogueEnd;

    public delegate void DialogueNodeCallBack(DialogueNode node);
    public DialogueNodeCallBack OnDialogueNodeStart;
    public DialogueNodeCallBack OnDialogueNodeEnd;
    public DialogueNodeCallBack OnDialogueNodeRequested;


    public void RaiseRequsetDialogue(Dialogue dialogue)
    {
        OnDialogueRequsted?.Invoke(dialogue);
    }

    public void RaiseDialogueStart(Dialogue dialogue)
    {
        OnDialogueStart?.Invoke(dialogue);
    }

    public void RaiseDialogueEnd(Dialogue dialogue)
    {
        OnDialogueEnd?.Invoke(dialogue);
    }

    public void RaiseDialogueNodeStart(DialogueNode node)
    {
        OnDialogueNodeStart?.Invoke(node);
    }

    public void RaiseRequestDialogueNode(DialogueNode node)
    {
        OnDialogueNodeRequested?.Invoke(node);
    }

    public void RaiseDialogueNodeEnd(DialogueNode node)
    {
        OnDialogueNodeEnd?.Invoke(node);
    }

}

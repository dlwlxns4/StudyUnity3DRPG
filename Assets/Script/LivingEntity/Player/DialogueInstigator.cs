using UnityEngine;

public class DialogueInstigator : MonoBehaviour
{

    [SerializeField]
    private DialogueChannel dialogueChannel;
    
    private DialogueSequencer dialogueSequencer;

    [SerializeField]
    private FlowChannel flowChannel;
    [SerializeField]
    private FlowState dialogueState;

    private FlowState cachedFlowState;

    private void Awake() 
    {
        dialogueSequencer = new DialogueSequencer();

        dialogueSequencer.OnDialogueStart += OnDialogueStart;
        dialogueSequencer.OnDialogueEnd += OnDialogueEnd;
        dialogueSequencer.OnDialogueNodeStart += dialogueChannel.RaiseDialogueNodeStart;
        dialogueSequencer.OnDialogueNodeEnd += dialogueChannel.RaiseDialogueNodeEnd;

        dialogueChannel.OnDialogueRequsted += dialogueSequencer.StartDialogue;
        dialogueChannel.OnDialogueNodeRequested += dialogueSequencer.StartDialogueNode;
    }

    private void OnDestroy() 
    {
        dialogueSequencer.OnDialogueStart -= OnDialogueStart;
        dialogueSequencer.OnDialogueEnd -= OnDialogueEnd;
        dialogueSequencer.OnDialogueNodeStart -= dialogueChannel.RaiseDialogueNodeStart;
        dialogueSequencer.OnDialogueNodeEnd -= dialogueChannel.RaiseDialogueNodeEnd;

        dialogueChannel.OnDialogueRequsted -= dialogueSequencer.StartDialogue;
        dialogueChannel.OnDialogueNodeRequested -= dialogueSequencer.StartDialogueNode;
    }

    private void OnDialogueStart(Dialogue dialogue)
    {
        dialogueChannel.RaiseDialogueStart(dialogue);

        cachedFlowState = FlowStateMachine.Instance.CurrentState;
        flowChannel.RaisedFlowStateRequest(dialogueState);
    }

    private void OnDialogueEnd(Dialogue dialogue)
    {
        flowChannel.RaisedFlowStateRequest(cachedFlowState);
        cachedFlowState = null;

        dialogueChannel.RaiseDialogueEnd(dialogue);
    }
}

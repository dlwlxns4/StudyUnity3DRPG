using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDialogueController : MonoBehaviour, DialogueNodeVisitor
{
    [SerializeField]
    private TextMeshProUGUI speakerText;

    [SerializeField]
    private TextMeshProUGUI dialogueText;
    [SerializeField]
    private DialogueChannel dialogueChannel;
    [SerializeField]

    private DialogueNode nextNode = null;
    private bool listenToInput = false;

    void Awake()
    {
        gameObject.SetActive(false);
        dialogueChannel.OnDialogueNodeStart += OnDialogueNodeStart;
        dialogueChannel.OnDialogueNodeEnd += OnDialogueNodeEnd;
    }

    // Update is called once per frame
    void Update()
    {
        if(listenToInput && Input.GetKeyDown(KeyCode.Space))
        {
            dialogueChannel.RaiseRequestDialogueNode(nextNode);
        }
    }

    private void OnDialogueNodeStart(DialogueNode node)
    {
        gameObject.SetActive(true);

        dialogueText.text = node.DialogueLine.Text;
        speakerText.text = node.DialogueLine.Speaker.characterName;

        node.Accept(this);
    }

    private void OnDialogueNodeEnd(DialogueNode node)
    {
        nextNode = null;
        listenToInput=false;
        dialogueText.text="";
        speakerText.text="";

        gameObject.SetActive(false);
    }

    public void Visit(BasicDialogueNode node)
    {
        listenToInput=true;
        nextNode = node.NextNode;
    }

    public void Visit(ChoiceDialogueNode node)
    {
        
    }
}

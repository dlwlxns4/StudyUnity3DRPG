using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIDialogueChoiceController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI choiceNode;
    [SerializeField]
    private DialogueChannel dialogueChannel;
    private DialogueNode choiceNextNdoe;

    public DialogueChoice choice
    {
        set
        {
            choiceNode.text = value.ChoicePreview;
            choiceNextNdoe = value.ChoiceNode;
        }
    }

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        dialogueChannel.RaiseRequestDialogueNode(choiceNextNdoe);   
        QuestManager.Instace.latestSelectQuestName = choiceNode.text;
    }
}

using System.Linq;
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
    private string[] agreeArray = new string[]{"수락하기"};
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
        if(!agreeArray.Contains(choiceNode.text))
        {
            QuestManager.Instace.latestSelectQuestName = choiceNode.text;
        }
        dialogueChannel.RaiseRequestDialogueNode(choiceNextNdoe);   
    }
}

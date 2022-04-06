using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;

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
    [SerializeField]
    private RectTransform choiceBoxTransform;

    [SerializeField]
    private UIDialogueChoiceController choiceControllerPrefab;

    [SerializeField]
    private List<GameObject> choiceNodeList;

    private int currSelectNode=-1;

    const string isQuest = "퀘스트";
    void Awake()
    {
        dialogueChannel.OnDialogueNodeStart += OnDialogueNodeStart;
        dialogueChannel.OnDialogueNodeEnd += OnDialogueNodeEnd;
        gameObject.SetActive(false);
        choiceBoxTransform.gameObject.SetActive(false);
    }

    private void OnDestroy() {
        dialogueChannel.OnDialogueNodeStart -= OnDialogueNodeStart;
        dialogueChannel.OnDialogueNodeEnd -= OnDialogueNodeEnd;
    }

    // Update is called once per frame
    void Update()
    {
        if(listenToInput==false)
        {
            return ;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(currSelectNode == -1)
            {
                dialogueChannel.RaiseRequestDialogueNode(nextNode);
            }
            else
            {
                choiceNodeList[currSelectNode].GetComponent<UIDialogueChoiceController>().OnClick();
            }
        }

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(currSelectNode > 0)
            {
                choiceNodeList[currSelectNode].GetComponent<SelectImage>().GetSelectImage.SetActive(false);
                currSelectNode--;
                choiceNodeList[currSelectNode].GetComponent<SelectImage>().GetSelectImage.SetActive(true);
            }
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(currSelectNode < choiceNodeList.Count-1)
            {
                choiceNodeList[currSelectNode].GetComponent<SelectImage>().GetSelectImage.SetActive(false);
                currSelectNode++;
                choiceNodeList[currSelectNode].GetComponent<SelectImage>().GetSelectImage.SetActive(true);
            }
        }
    }

    private void OnDialogueNodeStart(DialogueNode node)
    {
        gameObject.SetActive(true);

        string textString = node.DialogueLine.Text;
        textString = textString.Replace("\\n", "\n");
        dialogueText.text = textString;
        speakerText.text = node.DialogueLine.Speaker.characterName;
        node.Accept(this);

    }

    private void OnDialogueNodeEnd(DialogueNode node)
    {
        nextNode = null;
        listenToInput=false;
        dialogueText.text="";
        speakerText.text="";

        foreach (Transform child in choiceBoxTransform)
        {
            Destroy(child.gameObject);
        }

        gameObject.SetActive(false);
        choiceBoxTransform.gameObject.SetActive(false);
        currSelectNode=-1;
        choiceNodeList.Clear();
    }

    public void Visit(BasicDialogueNode node)
    {
        listenToInput=true;
        nextNode = node.NextNode;
    }

    public void Visit(ChoiceDialogueNode node)
    {
        choiceBoxTransform.gameObject.SetActive(true);
        listenToInput=true;
    
        
        FindQuest(node);

        foreach(DialogueChoice choice in node.CanChoiceNodes)
        {
            UIDialogueChoiceController newChoice = Instantiate(choiceControllerPrefab, choiceBoxTransform);
            newChoice.choice = choice;
            choiceNodeList.Add(newChoice.gameObject);
        }

        currSelectNode=0;
        choiceNodeList[currSelectNode].GetComponent<SelectImage>().GetSelectImage.SetActive(true);
    }

    public void Visit(QuestDialogueNode node)
    {
        listenToInput=true;

        nextNode = node.NextNode;
    }

    private void FindQuest(ChoiceDialogueNode node)
    {
        if(node.CanChoiceNodes.Any(x => x.ChoicePreview == isQuest))
        {
            List<QuestData> questObjects = QuestManager.Instace.FindQuestData();

            ChoiceDialogueNode choiceNode = ((ChoiceDialogueNode)node.CanChoiceNodes.Find(x=>x.ChoicePreview == isQuest).ChoiceNode);

            choiceNode.CanChoiceNodes.Clear();

            foreach(var quest in questObjects)
            {
                DialogueChoice choice = new DialogueChoice();
                choice.ChoicePreview = quest.questObject.QuestName;

                if(quest.isCompleted == true)
                {
                    choice.ChoiceNode = quest.questObject.CompleteDialogueNode;

                }
                else if(quest.isAccept == false)
                {
                    choice.ChoiceNode = quest.questObject.DialogueNode;
                }
                else
                {
                     choice.ChoiceNode = quest.questObject.AcceptDialogueNode;
                }
                choiceNode.CanChoiceNodes.Insert(0,choice);
            }

            DialogueChoice back = new DialogueChoice();
            back.ChoicePreview = "돌아가기";
            back.ChoiceNode = null;
            choiceNode.CanChoiceNodes.Add(back);
        }
    }
}

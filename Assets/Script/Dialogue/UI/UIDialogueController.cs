using TMPro;
using UnityEngine;
using UnityEngine.UI;
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

    void Awake()
    {
        dialogueChannel.OnDialogueNodeStart += OnDialogueNodeStart;
        dialogueChannel.OnDialogueNodeEnd += OnDialogueNodeEnd;
        gameObject.SetActive(false);
        choiceBoxTransform.gameObject.SetActive(false);
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
}

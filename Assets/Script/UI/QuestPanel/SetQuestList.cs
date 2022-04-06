using UnityEngine;
using UnityEngine.UI;

public class SetQuestList : MonoBehaviour
{
    [SerializeField]
    private UIChannel UIChannel;
    [SerializeField]
    private Text questNameText;
    [SerializeField]
    private GameObject questListPrefab;
    [SerializeField]
    private GameObject questListPanel;
    private GridLayoutGroup gridLayout;

    [SerializeField]
    private GameObject informationPanel;
    [SerializeField]
    private Text questDescriptionText;
    [SerializeField]
    private Text questGoalText;

    public Quest currSelectQuest{get;set;}

    private void Awake() 
    {
        UIChannel.OnSetQuestOnUI += SetOnQuestList;
        this.gameObject.SetActive(false);
        gridLayout = GetComponentInChildren<GridLayoutGroup>();
        UIChannel.OnSetQuestInformation += SetQuestInformation;
    }

    private void OnDestroy() 
    {
        UIChannel.OnSetQuestInformation -= SetQuestInformation;
        UIChannel.OnSetQuestOnUI -= SetOnQuestList;
        
    }

    private void SetOnQuestList(string questName)
    {
        GameObject questList = Instantiate(questListPrefab, Vector3.zero, Quaternion.identity);
        questList.GetComponentInChildren<Text>().text = questName;

        questList.transform.SetParent(gridLayout.transform, false);
    }

    private void SetQuestInformation(Quest quest)
    {
        informationPanel.SetActive(true);
        questDescriptionText.text = "";
        questGoalText.text = "";

        questDescriptionText.text = quest.Description;

        foreach(var goal in quest.Goals)
        {
            questGoalText.text += $"{goal.Description} : {goal.CurrentAmount} / {goal.RequiredAmount} \n"; 
        }
    }

}

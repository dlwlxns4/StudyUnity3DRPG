using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

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
    private TextMeshProUGUI questDescriptionText;
    [SerializeField]
    private TextMeshProUGUI questGoalText;
    private List<GameObject> questsList = new List<GameObject>();

    public Quest currSelectQuest{get;set;}

    private void Awake() 
    {
        this.gameObject.SetActive(false);
        gridLayout = GetComponentInChildren<GridLayoutGroup>();
        UIChannel.OnSetQuestInformation += SetQuestInformation;
        UIChannel.OnSetQuestOnUI += SetOnQuestList;
        UIChannel.OnRemoveQuestOnUI += RemoveQuestList;
    }

    private void OnDestroy() 
    {
        UIChannel.OnSetQuestInformation -= SetQuestInformation;
        UIChannel.OnSetQuestOnUI -= SetOnQuestList;
        UIChannel.OnRemoveQuestOnUI -= RemoveQuestList;
        
    }

    public void OpenPanel()
    {
        this.gameObject.SetActive(!this.gameObject.activeSelf);
    }

    private void SetOnQuestList(string questName)
    {
        GameObject questList = Instantiate(questListPrefab, Vector3.zero, Quaternion.identity);
        questList.GetComponentInChildren<Text>().text = questName;
        questsList.Add(questList);

        questList.transform.SetParent(gridLayout.transform, false);
    }

    private void RemoveQuestList(string questName)
    {
        GameObject quest = questsList.Find(x => x.GetComponentInChildren<Text>().text == questName);
        questsList.Remove(quest);
        Destroy(quest);
        informationPanel.SetActive(false);
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

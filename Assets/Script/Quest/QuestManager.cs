using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    private static QuestManager instance;
    public static QuestManager Instace => instance;

    private int latestInteractObjectID{get;set;}


    [SerializeField]
    private List<QuestObject> questObjectList = new List<QuestObject>();
    
    [SerializeField]
    private List<Quest> acceptQuestList = new List<Quest>();

    [SerializeField]
    private UIChannel uiChannel;


    void Awake() 
    {
        instance = this; 
    }


    public List<QuestObject> FindQuest(int id)
    {   
        List<QuestObject> questObjList = new List<QuestObject>();
        questObjList = questObjectList.FindAll(x => x.QuestID == id);

        return questObjectList;
    } 

    public void AcceptQuest()
    {
        Quest quest = new MushroomHunter();
        quest.Init();
        acceptQuestList.Add(quest);
        Debug.Log("퀘스트 이름" + $" {quest.QuestName}");
        uiChannel.RaiseSetQuestOnUI(quest.QuestName);
    }


}

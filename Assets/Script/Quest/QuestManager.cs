using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class QuestData
{
    public QuestData(QuestObject obj, bool isAccept)
    {
        questObject = obj;
        isAccept = false;
    }
    public QuestObject questObject;
    public bool isAccept;
}

public class QuestManager : MonoBehaviour
{
    private static QuestManager instance;
    public static QuestManager Instace => instance;
    public int latestInteractObjectID{get;set;}


    // [SerializeField]
    // private List<QuestObject> questObjectList = new List<QuestObject>();
    [SerializeField]
    private List<QuestData> questDataList = new List<QuestData>();

    [SerializeField]
    private List<Quest> acceptQuestList = new List<Quest>();

    [SerializeField]
    private UIChannel uiChannel;

    public string latestSelectQuestName{get;set;}

    void Awake() 
    {
        instance = this; 
    }


    public List<QuestData> FindQuestData()
    {   
        // List<QuestObject> questObjList = new List<QuestObject>();
        List<QuestData> questDatasList = new List<QuestData>();
        questDatasList = questDataList.FindAll( x=> x.questObject.QuestID == latestInteractObjectID);
        // questObjList = questObjectList.FindAll(x => x.QuestID == latestInteractObjectID);

        return questDatasList;
    } 

    public void AcceptQuest()
    {
        QuestData questObj = questDataList.Find(x=>x.questObject.QuestName == latestSelectQuestName);
        if(questObj.isAccept == false)
        {
            questObj.isAccept = true;
            string questClass = questObj.questObject.QuestClassName;
            Type questType = Type.GetType(questClass);
            Quest quest = Activator.CreateInstance(questType) as Quest;
            quest.Init();

            acceptQuestList.Add(quest);
            uiChannel.RaiseSetQuestOnUI(quest.QuestName);
        }
    }
}

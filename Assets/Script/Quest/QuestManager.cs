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
    public bool isCompleted;
    public bool isReceiveReward;
}

public class QuestManager : MonoBehaviour
{
    private static QuestManager instance;
    public static QuestManager Instace => instance;
    public int latestInteractObjectID{get;set;}
    public int storyProgress{get;set;}


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
        storyProgress=1;
    }


    public List<QuestData> FindQuestData()
    {   
        // List<QuestObject> questObjList = new List<QuestObject>();
        List<QuestData> questDatasList = new List<QuestData>();
        questDatasList = questDataList.FindAll( x=> x.questObject.QuestID == latestInteractObjectID);
        questDatasList.RemoveAll(x=> x.isReceiveReward == true);
        // questObjList = questObjectList.FindAll(x => x.QuestID == latestInteractObjectID);

        return questDatasList;
    } 

    public Quest FindQuestData(string questName)
    {   
       return acceptQuestList.Find(x=>x.QuestName == questName);
    } 

    public void AcceptQuest()
    {
        QuestData questObj = questDataList.Find(x=>x.questObject.QuestName == latestSelectQuestName);
        if(questObj.isCompleted == false)
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

    public void CompleteQuest()
    {
        Quest quest = acceptQuestList.Find(x=>x.QuestName == latestSelectQuestName);
        if(quest == null)
        {
            return;
        }

        if(quest.Completed)
        {
            Debug.Log("퀘스트 완료 in QuestManager ");
            questDataList.Find(x => x.questObject.QuestID == quest.QuestID).isReceiveReward=true;
            acceptQuestList.Remove(quest);
            quest.GiveReward();
        }
    }


    public void QuestSetIsComplete(int questID)
    {
        questDataList.Find(x=> x.questObject.QuestID == questID).isCompleted = true;
    }
}

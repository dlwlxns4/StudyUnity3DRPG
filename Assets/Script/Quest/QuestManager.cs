using System;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    private static QuestManager instance;
    public static QuestManager Instace => instance;
    public int latestInteractObjectID{get;set;}


    [SerializeField]
    private List<QuestObject> questObjectList = new List<QuestObject>();
    
    [SerializeField]
    private List<Quest> acceptQuestList = new List<Quest>();

    [SerializeField]
    private UIChannel uiChannel;

    public string latestSelectQuestName{get;set;}

    void Awake() 
    {
        instance = this; 
    }


    public List<QuestObject> FindQuest()
    {   
        List<QuestObject> questObjList = new List<QuestObject>();
        questObjList = questObjectList.FindAll(x => x.QuestID == latestInteractObjectID);

        return questObjectList;
    } 

    public void AcceptQuest()
    {
        QuestObject questObj = questObjectList.Find(x=>x.QuestName == latestSelectQuestName);
        string questClass = questObj.QuestClassName;
        Type type = Type.GetType(questClass);
        Quest obj = Activator.CreateInstance(type) as Quest;
        obj.Init();

        acceptQuestList.Add(obj);
        Debug.Log("퀘스트 이름" + $" {obj.QuestName}");
        questObj.isAccept=true;
        uiChannel.RaiseSetQuestOnUI(obj.QuestName);
    }
}

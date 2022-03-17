using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    private static QuestManager instance;
    public static QuestManager Instace => instance;

    public int latestInteractObjectID;

    [SerializeField]
    private List<QuestObject> questObjectList;


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
}

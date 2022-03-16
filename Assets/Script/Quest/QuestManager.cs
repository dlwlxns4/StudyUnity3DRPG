using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    private static QuestManager instance;
    public QuestManager Instace => instance;



    [SerializeField]
    private List<QuestObject> questObjectList;


    void Awake() 
    {
        instance = this;    
    }


    public QuestDialogueNode FindQuest(int id)
    {   
       return questObjectList.Find(x => x.QuestID == id).DialogueNode;
    } 
}

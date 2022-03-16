using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObjects/Quest/QuestObject")]
public class QuestObject : ScriptableObject
{
    [SerializeField]
    private int questID;
    [SerializeField]
    string questName;
    [SerializeField]
    QuestDialogueNode dialogueNode;

    public int QuestID => questID;
    public string QuestName => questName;
    public QuestDialogueNode DialogueNode => dialogueNode;    
}

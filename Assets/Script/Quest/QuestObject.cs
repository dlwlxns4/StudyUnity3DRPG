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
    DialogueNode dialogueNode;
    [SerializeField]
    DialogueNode acceptDialogueNode;
    [SerializeField]
    DialogueNode completeDialogueNode;
    [SerializeField]
    string questClassName;
    [SerializeField]
    int canAcceptStorySequence;


    public int QuestID => questID;
    public string QuestName => questName;
    public DialogueNode DialogueNode => dialogueNode;    
    public string QuestClassName => questClassName;
    public DialogueNode AcceptDialogueNode => acceptDialogueNode;
    public DialogueNode CompleteDialogueNode => completeDialogueNode;
    public int CanAcceptStorySequence => canAcceptStorySequence;
}

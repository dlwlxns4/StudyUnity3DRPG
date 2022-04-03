using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGoal
{
    public string Description{get;set;}
    public bool Completed{get;set;}
    public int CurrentAmount{get;set;}
    public int RequiredAmount{get;set; }
    public Quest GoalOwner{get;set;}

    public QuestGoal(Quest owner)
    {
        GoalOwner = owner;
    }

    public virtual void Init()
    {
        // default Init sutff
        
    }

    public void Evalutate()
    {
        if(CurrentAmount >= RequiredAmount)
        {
            Complete();
            Debug.Log($"{Description} 완료");
            GoalOwner.CheckGoals();
        }
    }

    public void Complete()
    {
        Completed = true;
    }
}

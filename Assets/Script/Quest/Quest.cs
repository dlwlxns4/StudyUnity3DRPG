using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Quest : MonoBehaviour
{
    public List<QuestGoal> Goals{get;set;} = new List<QuestGoal>();
    public string QuestName{get;set;}
    public string Description{get;set;}
    public bool Completed{get;set;}
    public int QuestID{get;set;}

    public void CheckGoals()
    {
        Completed = Goals.All(x => x.Completed);

        if(Completed)
        {
            GiveReward();
        }
    }

    void GiveReward()
    {
    }
}

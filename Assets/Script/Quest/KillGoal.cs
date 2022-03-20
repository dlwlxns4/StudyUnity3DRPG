using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillGoal : QuestGoal
{
    public int EnemyID{get;set;}

    public KillGoal(int enemyID, string description, bool completed, int currentAmount, int requiredAmount)
    {
        this.EnemyID = enemyID;
        this.Description = description;
        this.Completed = completed;
        this.CurrentAmount = currentAmount;
        this.RequiredAmount = requiredAmount;
    }

    public override void Init()
    {
        base.Init();
        CombatChannel.OnEnemyDiedEvent += EnemyDied;
    }

    void EnemyDied(LivingEntity enemy)
    {
        Debug.Log("!!꺄륵");
        if(enemy.ObjectId == this.EnemyID)
        {
            this.CurrentAmount++;
            Evalutate();
        }
    }
}

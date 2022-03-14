using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : ScriptableObject 
{
    [System.Serializable]
    public struct Info
    {
        public string name;
        public Sprite icon;
        public string description;
    }

    [Header("Info")] 
    public Info information;

    
    //Reward
    [System.Serializable]
    public struct Stat
    {
        public int currency;
        public int exp;
    }

    [Header("Reward")] 
    public Stat reward = new Stat{currency=10, exp=10};


    public abstract class QuestGoal : ScriptableObject
    {
        protected string description;
        public int currentAmount {get; protected set;}
        public int requiredAmound =1;

        public virtual string GetDescription()
        {
            return description;
        }
    }

    public List<QuestGoal> goals;
}


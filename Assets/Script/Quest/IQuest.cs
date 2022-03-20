using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class IQuest 
{
    public void CheckGoals(List<QuestGoal> Goals, bool Completed)
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

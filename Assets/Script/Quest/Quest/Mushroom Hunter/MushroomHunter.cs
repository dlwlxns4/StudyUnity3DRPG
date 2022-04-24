using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomHunter : Quest
{
    // Start is called before the first frame update
    public override void Init()
    {
        QuestName = "버섯 소탕의뢰";
        QuestID=1;
        Description = "머쉬룸이 흉포해져서 마을사람들을 공격하고있어\n머쉬룸을 5마리 처치해줘";

        Goals.Add(new KillGoal(1, "머쉬룸 5마리 처치", false, 0, 5, this));
        Goals.ForEach(x => x.Init());
    }

    public override void GiveReward()
    {
        base.GiveReward();
        QuestManager.Instace.storyProgress++;
    }
}

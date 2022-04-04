using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyKiller : Quest
{
    public override void Init()
    {
        QuestName = "요정 처치";
        QuestID=1;
        Description = "버섯들이 흉포해진 원인을 찾았어!\n요정이 말썽을 부리고 있었어\n요정을 처치해줘";

        Goals.Add(new KillGoal(2, "요정 처치", false, 0, 1, this));
        Goals.ForEach(x => x.Init());
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyKiller : Quest
{
    public override void Init()
    {
        QuestName = "드라이어드 처치";
        QuestID=2;
        Description = "버섯들이 흉포해진 원인을 찾았어!\n산 정상의 드라이어드가 원인이었어! 드라이어드를 처치해줘";

        Goals.Add(new KillGoal(2, "드라이어드 처치", false, 0, 1, this));
        Goals.ForEach(x => x.Init());
    }
}

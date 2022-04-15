using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MpPotion : BasicItem, IUsable
{
    public void UseItem()
    {
        Debug.Log("Mp물약 사용");
        UIChannel.RaiseGetUseItem(this, false);
    }
}

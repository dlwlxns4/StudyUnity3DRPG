using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpPotion : BasicItem, IUsable
{
    public void UseItem()
    {
        Debug.Log("Hp물약사용");
        UIChannel.RaiseGetUseItem(this, false);
    }
}

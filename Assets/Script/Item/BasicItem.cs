using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicItem : Item, IPickUpable
{
    public void AcquireItem()
    {
        UIChannel.RaiseGetUseItem(this, true);
    }
}

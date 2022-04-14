using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyItem : MonoBehaviour
{
    [SerializeField]
    Inventory inventory;
    public ItemData currItem{get;set;}

    public void BuyAcquireItem()
    {
        Debug.Log(currItem);
        int gold = inventory.GetPossessGold();

        if(gold >= 0)
        {
            inventory.AcquireItem(currItem);
            inventory.SetPossesGold(gold);
        }
    }
}

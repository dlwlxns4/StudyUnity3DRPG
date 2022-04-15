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

        if(gold >= currItem.BuyPrice)
        {
            inventory.AcquireItem(currItem);
            gold-=currItem.BuyPrice;
            inventory.SetPossesGold(gold);
        }

        this.gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyItem : MonoBehaviour
{
    [SerializeField]
    Inventory inventory;
    public Item currItem{get;set;}

    public void BuyAcquireItem()
    {
        int gold = inventory.GetPossessGold();

        if(gold >= currItem.GetItemData.BuyPrice)
        {
            inventory.GetUseItem(currItem, true);
            gold-=currItem.GetItemData.BuyPrice;
            inventory.SetPossesGold(gold);
        }

        this.gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemSlot : MonoBehaviour
{
    [SerializeField]
    Image itemImage;
    [SerializeField]
    TextMeshProUGUI CountText;
    public int Count=0;
    public ItemData itemData{get;set;}


    public void SetItemImage(ItemData itemData)
    {
        itemImage.sprite = itemData.ItemImage;
        this.itemData = itemData;
        IncreaseCount();
    }

    public void IncreaseCount()
    {
        Count++;
        CountText.text = $"{Count}";
    }
}

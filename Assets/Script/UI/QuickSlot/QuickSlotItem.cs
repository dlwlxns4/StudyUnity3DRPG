using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class QuickSlotItem : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    Image itemImage;
    Item itemData;
    ItemSlot itemSlot;
    TextMeshProUGUI countText;

    void Awake()
    {
        countText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void SetData(ItemSlot itemSlot)
    {
        itemImage.sprite = itemSlot.itemData.GetItemData.ItemImage;
        this.itemSlot = itemSlot;
        countText.text=$"{itemSlot.Count}";
        itemImage.color = new Color(1f, 1f, 1f, 1f);
    }

    public void UseItem()
    {
        itemSlot?.itemData.GetComponent<IUsable>()?.UseItem();
        if(itemSlot?.Count!=0)
        {
            countText.text = $"{itemSlot?.Count}";
        }
        else
        {
            countText.text = "";
            itemImage.sprite=null;
            itemImage.color = new Color(1f,1f,1f,0f);
            this.itemSlot=null;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Right)
        {
            itemData=null;
            itemImage.sprite = null;
            itemImage.color = new Color(1f,1f,1f,0f);
        }
    }
}

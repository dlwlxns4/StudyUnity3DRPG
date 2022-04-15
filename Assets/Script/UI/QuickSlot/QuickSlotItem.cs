using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class QuickSlotItem : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    Image itemImage;
    Item itemData;

    void Start()
    {
        
    }

    public void SetData(Item itemData)
    {
        itemImage.sprite = itemData.GetItemData.ItemImage;
        this.itemData = itemData;
        itemImage.color = new Color(1f, 1f, 1f, 1f);
    }

    public void UseItem()
    {
        itemData?.GetComponent<IUsable>()?.UseItem();
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

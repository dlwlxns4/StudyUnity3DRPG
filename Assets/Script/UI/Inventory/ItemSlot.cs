using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    Image itemImage;
    [SerializeField]
    TextMeshProUGUI CountText;
    public int Count=0;
    public ItemData itemData{get;set;}

    Image shadowSlotImage;

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

    public void OnBeginDrag(PointerEventData eventData)
    {
        // if(itemData != null)
        // {
            shadowSlotImage = Instantiate(itemImage, this.transform.position, Quaternion.identity).GetComponent<Image>();
            shadowSlotImage.rectTransform.sizeDelta = itemImage.rectTransform.sizeDelta/3;
            shadowSlotImage.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
        // }
    }

    public void OnDrag(PointerEventData eventData)
    {
        shadowSlotImage.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Destroy(shadowSlotImage.gameObject);
        UIChannel.RaiseSetQuickSlot(eventData.position, itemData);
    }
}

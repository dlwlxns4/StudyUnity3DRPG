using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class QuickSlot : MonoBehaviour
{
    RectTransform rectTransform;
    QuickSlotItem[] quickSlotsList;
    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        quickSlotsList = GetComponentsInChildren<QuickSlotItem>();
        UIChannel.OnSetQuickSlot += SetItem;
    }

    void SetItem(Vector3 pointer, ItemData itemData)
    {
        FindQuickSlotNumber(pointer, itemData);
    }

    void FindQuickSlotNumber(Vector3 pointer, ItemData itemData)
    {
        Vector2 size = new Vector2(45,35);
        foreach(var quickSlotElement in quickSlotsList)
        {

            Vector2 position = quickSlotElement.GetComponent<RectTransform>().position;
            if(position.x - size.x/2 < pointer.x && position.x + size.x/2 > pointer.x)
            {
                if(position.y - size.y/2 < pointer.y && position.y + size.y/2 > pointer.y)
                {
                    quickSlotElement.SetItemImage(itemData.ItemImage);
                    break;
                }
            }
        }
    }
}

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

    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            quickSlotsList[0].UseItem();
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            quickSlotsList[1].UseItem();
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            quickSlotsList[2].UseItem();
        }
    }

    void SetItem(Vector3 pointer, ItemSlot itemSlot)
    {
        FindQuickSlotNumber(pointer, itemSlot);
    }

    void FindQuickSlotNumber(Vector3 pointer, ItemSlot itemSlot)
    {
        Vector2 size = new Vector2(45,35);
        foreach(var quickSlotElement in quickSlotsList)
        {
            Vector2 position = quickSlotElement.GetComponent<RectTransform>().position;
            if(position.x - size.x/2 < pointer.x && position.x + size.x/2 > pointer.x)
            {
                if(position.y - size.y/2 < pointer.y && position.y + size.y/2 > pointer.y)
                {
                    quickSlotElement.SetData(itemSlot);
                    break;
                }
            }
        }
    }
}

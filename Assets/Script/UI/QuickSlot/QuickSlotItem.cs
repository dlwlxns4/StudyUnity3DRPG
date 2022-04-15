using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class QuickSlotItem : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    Image itemImage;

    void Start()
    {
        
    }

    public void SetItemImage(Sprite image)
    {
        itemImage.sprite = image;
        itemImage.color = new Color(1f, 1f, 1f, 1f);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Right)
        {
            itemImage.sprite = null;
            itemImage.color = new Color(1f,1f,1f,0f);
        }
    }
}

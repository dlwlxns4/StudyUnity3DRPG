using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalesItem : MonoBehaviour
{
    [SerializeField]
    List<Item> itemDataList = new List<Item>(); 

    void Awake()
    {
        Interactable interactable = GetComponent<Interactable>();
        interactable.OnInteraction.AddListener(AddEvent);
    }

    public List<Item> GetItemDataList()
    {
        return itemDataList; 
    }

    public void AddEvent()
    {
        Shop shop = GameObject.FindGameObjectWithTag("Canvas").transform.Find("ShopPanel").GetComponent<Shop>();
        shop.OpenShop(this.gameObject);
    }
}

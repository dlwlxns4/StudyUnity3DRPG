using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalesItem : MonoBehaviour
{
    [SerializeField]
    List<Item> itemDataList = new List<Item>(); 

    public List<Item> GetItemDataList()
    {
        return itemDataList; 
    }
}

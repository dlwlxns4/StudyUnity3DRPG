using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalesItem : MonoBehaviour
{
    [SerializeField]
    List<ItemData> itemDataList = new List<ItemData>(); 

    public List<ItemData> GetItemDataList()
    {
        return itemDataList; 
    }
}

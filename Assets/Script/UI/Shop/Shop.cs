using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField]
    GameObject itemListPrefab;
    [SerializeField]
    GameObject selectPanel;

    void Awake()
    {
        

    }

    public void OpenShop(GameObject npc)
    {
        this.gameObject.SetActive(true);
        GridLayoutGroup gridLayout = GetComponentInChildren<GridLayoutGroup>();
        List<ItemData> saleItemList = npc.GetComponent<SalesItem>().GetItemDataList();

        foreach(var item in saleItemList)
        {
            GameObject itemList = Instantiate(itemListPrefab, Vector3.zero, Quaternion.identity);
            itemList.GetComponent<SaleItemList>().SetItemImage(item.ItemImage);
            itemList.GetComponent<SaleItemList>().itemData = item;
            itemList.GetComponent<SaleItemList>().Init(selectPanel);
            itemList.transform.SetParent(gridLayout.transform, false);
        }
    }

}

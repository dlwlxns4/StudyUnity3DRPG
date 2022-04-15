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
    [SerializeField]
    List<GameObject> itemsList;
    [SerializeField]
    FlowChannel flowChannel;
    [SerializeField]
    FlowState dialogueState;
    [SerializeField]
    FlowState cacheState;
    [SerializeField]
    GameObject inventory;

    void Update() 
    {
        CloseShop();
    }

    public void OpenShop(GameObject npc)
    {
        this.gameObject.SetActive(true);
        GridLayoutGroup gridLayout = GetComponentInChildren<GridLayoutGroup>();
        List<ItemData> saleItemList = npc.GetComponent<SalesItem>().GetItemDataList();
        
        cacheState = FlowStateMachine.Instance.CurrentState;
        flowChannel.RaisedFlowStateRequest(dialogueState);
        inventory.SetActive(true);

        foreach(var item in saleItemList)
        {
            GameObject itemList = Instantiate(itemListPrefab, Vector3.zero, Quaternion.identity);
            itemList.GetComponent<SaleItemList>().SetItemImage(item.ItemImage);
            itemList.GetComponent<SaleItemList>().itemData = item;
            itemList.GetComponent<SaleItemList>().Init(selectPanel);
            itemList.transform.SetParent(gridLayout.transform, false);

            itemsList.Add(itemList);
        }
    }


    public void CloseShop()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            foreach(var item in itemsList)
            {
                Destroy(item);
            }
            inventory.SetActive(false);

            itemsList.Clear();
            flowChannel.RaisedFlowStateRequest(cacheState);
            this.gameObject.SetActive(false);
        }
    }
}

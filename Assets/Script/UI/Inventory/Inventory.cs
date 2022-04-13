using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    int gold;
    [SerializeField]
    GameObject[] itemList = new GameObject[20];

    // Start is called before the first frame update
    void Awake()
    {
        UIChannel.OnSetInven += OpenInventory;
        this.gameObject.SetActive(false);
    }

     void OnDestroy()
    {
        UIChannel.OnSetInven -= OpenInventory;
    }

    public void AcquireItem()
    {
        for(int i=0; i<itemList.Length; ++i)
        {  
        }
    }

    private void OpenInventory()
    {
        this.gameObject.SetActive(!this.gameObject.activeSelf);
    }
}

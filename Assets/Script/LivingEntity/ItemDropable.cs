using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemDropable : MonoBehaviour 
{

    [System.Serializable]
    struct ItemProbability
    {
        [SerializeField]
        public ItemData itemData;
        [SerializeField]
        public float probability;
    }

    [SerializeField]
    private List<ItemProbability> itemList = new List<ItemProbability>();
    void Awake()
    {
    }
    
    public void DropItem()
    {
        foreach(var item in itemList)
        {
            float probability = Random.Range(0f, 100f);
            if(probability >= (100-item.probability))
            {
                Vector3 dropPosition = this.transform.position;
                dropPosition.y +=0.8f;
                GameObject itemObj = Instantiate(item.itemData.ItemPrefab, dropPosition, Quaternion.identity);
            }
        }
    }

}

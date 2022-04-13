using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemDropable : MonoBehaviour 
{

    [System.Serializable]
    struct ItemProbability
    {
        [SerializeField]
        public GameObject itemPrefab;
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
            if(probability >= (item.probability-100))
            {
                Vector3 dropPosition = this.transform.position;
                dropPosition.y +=0.8f;
                GameObject itemObj = Instantiate(item.itemPrefab, dropPosition, Quaternion.identity);
            }
        }
    }

}

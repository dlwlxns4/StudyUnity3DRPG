using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    [SerializeField]
    int gold;
    [SerializeField]
    TextMeshProUGUI goldText;

    [SerializeField]
    ItemSlot[] itemList = new ItemSlot[20];

    Vector2 downPosition;

    // Start is called before the first frame update
    void Awake()
    {
        UIChannel.OnSetInven += OpenInventory;
        UIChannel.OnAcquireCoin += AcquireCoin;
        UIChannel.OnGetUseItem += GetUseItem;
        itemList = GetComponentsInChildren<ItemSlot>();
        this.gameObject.SetActive(false);
    }

    void OnDestroy()
    {
        UIChannel.OnSetInven -= OpenInventory;
        UIChannel.OnGetUseItem -= GetUseItem;
        UIChannel.OnAcquireCoin -= AcquireCoin;
    }

    public void GetUseItem(Item itemData, bool isGet)
    {
        if(isGet)
        {
            foreach(var itemSlot in itemList)
            {
                if(itemSlot.itemData == null)
                {
                    itemSlot.SetItemImage(itemData);
                    return ;
                }
                else if(itemSlot.itemData.GetItemData.ItemCode == itemData.GetItemData.ItemCode )
                {
                    itemSlot.IncreaseCount();
                    return ;
                }
            }
        }
        else
        {
            foreach(var itemSlot in itemList)
            {
                if(itemSlot.itemData == itemData)
                {
                    itemSlot.DecreaseCount();
                    if(itemSlot.Count==0)
                    {
                        itemSlot.Init();
                    }
                    return ;
                }
            }
        }
    }

    private void OpenInventory()
    {
        this.gameObject.SetActive(!this.gameObject.activeSelf);
    }

    private void AcquireCoin(int coin)
    {
        gold += coin;
        Debug.Log(coin);
        goldText.text = $"Gold : {gold}";
    }

    public int GetPossessGold()
    {
        return gold;
    }

    public void SetPossesGold(int gold)
    {
        this.gold = gold;
        goldText.text=$"{this.gold}";
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        Vector3 offset = eventData.position - downPosition;
        downPosition = eventData.position;
        this.gameObject.transform.position += offset;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        downPosition = eventData.position;
    }
}

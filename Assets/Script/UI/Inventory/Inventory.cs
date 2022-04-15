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
    RectTransform rectTransform;

    Vector2 downPosition;

    // Start is called before the first frame update
    void Awake()
    {
        UIChannel.OnSetInven += OpenInventory;
        UIChannel.OnAcquireCoin += AcquireCoin;
        UIChannel.OnAcquireItem += AcquireItem;
        itemList = GetComponentsInChildren<ItemSlot>();
        rectTransform = GetComponent<RectTransform>();
        this.gameObject.SetActive(false);
    }

    void OnDestroy()
    {
        UIChannel.OnSetInven -= OpenInventory;
        UIChannel.OnAcquireItem -= AcquireItem;
        UIChannel.OnAcquireCoin -= AcquireCoin;
    }

    public void AcquireItem(ItemData itemData)
    {
        foreach(var itemSlot in itemList)
        {
            if(itemSlot.itemData == null)
            {
                itemSlot.GetComponent<ItemSlot>().SetItemImage(itemData);
                return ;
            }
            else if(itemSlot.itemData.ItemCode == itemData.ItemCode )
            {
                itemSlot.GetComponent<ItemSlot>().IncreaseCount();
                return ;
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

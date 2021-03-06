using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class SaleItemList : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    public Item itemData{get;set;}
    [SerializeField]
    Image itemImage;
    Image panelImage;
    Color cacheColor;
    GameObject selectPanel;
    TextMeshProUGUI priceText;

    public void OnPointerEnter(PointerEventData eventData)
    {
        cacheColor = panelImage.color;
        panelImage.color = new Color(0.5f,0.5f,0.5f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        panelImage.color = cacheColor;
    }


    void Awake()
    {
        panelImage=GetComponent<Image>();
    }

    public void Init(GameObject selectPanel)
    {
        this.selectPanel = selectPanel;
    }

    public void SetItemImage(Item item)
    {
        itemImage.sprite = item.GetItemData.ItemImage;
        GetComponentInChildren<TextMeshProUGUI>().text = $"{item.GetItemData.BuyPrice}";
    }

    public void BuyItem()
    {
        selectPanel.SetActive(true);
        selectPanel.GetComponent<BuyItem>().currItem = itemData;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        BuyItem();
    }
}

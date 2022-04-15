using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Item/ItemData")]
public class ItemData : ScriptableObject
{
    [SerializeField]
    int itemCode;
    [SerializeField]
    Sprite itemImage;
    [SerializeField]
    GameObject itemPrefab;
    [SerializeField]
    int buyPrice;
    [SerializeField]
    int sellPrice;

    public int ItemCode => itemCode;
    public Sprite ItemImage => itemImage;
    public GameObject ItemPrefab => itemPrefab;
    public int BuyPrice => buyPrice;
    public int SellPrice => sellPrice;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Item, IPickUpable
{
    [SerializeField]
    int minCoin;
    [SerializeField]
    int maxCoin;

    public void AcquireItem()
    {
        int cash = Random.Range(minCoin, maxCoin+1);
        UIChannel.RaiseAccuireCoin(cash);
    }
}

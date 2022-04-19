using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
    Image image;
    [SerializeField]
    PlayerStatus playerStatus;

    void Awake()
    {
        image = GetComponent<Image>();
        PlayerChannel.OnGetExpEvent +=FillExpBar;
    }

    private void OnDestroy() 
    {
        PlayerChannel.OnGetExpEvent -= FillExpBar;
    }

    void FillExpBar(int exp)
    {
        float currExp = playerStatus.CurrExp + exp;
        image.fillAmount = currExp / (float)playerStatus.RequiredExp;
        Debug.Log(image.fillAmount + " " + playerStatus.CurrExp+exp + " " + playerStatus.RequiredExp );
    }

}

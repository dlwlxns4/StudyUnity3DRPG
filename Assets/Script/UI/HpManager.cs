using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HpManager : MonoBehaviour
{
    private Image hpImage;
    private Text hpText;
    private float effectHp;
    public delegate void SetHpEvent();
    public SetHpEvent SetHp;
    [SerializeField]
    PlayerStatus playerStatus;
    public float HpRecoveryDelay{get;set;}

    void Start()
    {
        hpImage = GetComponent<Image>();
        hpText = GetComponentInChildren<Text>();
        UIChannel.OnSpendHp += SpendHp;
        UIChannel.OnFillHp += FillHp;
        effectHp = playerStatus.MaxHp;
        HpRecoveryDelay = 1;
    }

    void OnDestroy() 
    {
    }

    void SpendHp(int spendHp)
    {
        if(spendHp == 0)
        {
            hpText.text = $"{playerStatus.RemainHp}";
            effectHp = playerStatus.RemainHp;
            return;
        }

        playerStatus.RemainHp -= spendHp;
        if(playerStatus.RemainHp < 0)
        {
            playerStatus.RemainHp = 0;
        }
        hpText.text = $"{playerStatus.RemainHp}";
        StartCoroutine(SpendHpEffect());
    }

    void FillHp(int fillHp)
    {
        effectHp =playerStatus.RemainHp;
        playerStatus.RemainHp += fillHp;
        if(playerStatus.RemainHp>=playerStatus.MaxHp)
        {
            playerStatus.RemainHp   = playerStatus.MaxHp;
        }

        hpText.text = $"{playerStatus.RemainHp}";
        StartCoroutine(FillHpEffect());
    }

    IEnumerator SpendHpEffect()
    {
        while(effectHp >= playerStatus.RemainHp)
        {
            hpImage.fillAmount =  effectHp / playerStatus.MaxHp;
            effectHp -= 0.2f;
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator FillHpEffect()
    {
        while(effectHp <= playerStatus.RemainHp)
        {
            hpImage.fillAmount =  effectHp / playerStatus.MaxHp;
            effectHp += 0.2f;
            yield return new WaitForSeconds(0.01f);
        }
    }
}

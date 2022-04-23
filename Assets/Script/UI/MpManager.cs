using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MpManager : MonoBehaviour
{
    private Image mpImage;
    private Text mpText;
    private float effectMp;
    public delegate void SetMpEvent();
    public SetMpEvent SetMp;
    [SerializeField]
    PlayerStatus playerStatus;
    public float MpRecoveryDelay{get;set;}

    void Start()
    {
        mpImage = GetComponent<Image>();
        mpText = GetComponentInChildren<Text>();
        UIChannel.OnSpendMp += SpendMp;
        UIChannel.OnFillMp += FillMp;
        effectMp = playerStatus.MaxMp;
        MpRecoveryDelay = 1;
    }

    void Update()
    {
        if(playerStatus.RemainMp == playerStatus.MaxMp)
        {
            return;
        }

        MpRecoveryDelay -= Time.deltaTime;
        if(MpRecoveryDelay <=0)
        {
            MpRecoveryDelay=1;
            playerStatus.RemainMp +=1;
            mpText.text = $"{playerStatus.RemainMp}";
            StartCoroutine(FillMpEffect());
        }
    }

    void OnDestroy() 
    {
        UIChannel.OnSpendMp -= SpendMp;
    }

    void SpendMp(int spendMp)
    {
        if(spendMp == 0)
        {
            mpText.text = $"{playerStatus.RemainMp}";
            effectMp = playerStatus.RemainMp;
            return;
        }

        playerStatus.RemainMp -= spendMp;
        if(playerStatus.RemainMp < 0)
        {
            playerStatus.RemainMp = 0;
        }
        mpText.text = $"{playerStatus.RemainMp}";
        StartCoroutine(SpendMpEffect());
    }

    void FillMp(int fillMp)
    {
        effectMp =playerStatus.RemainMp;
        playerStatus.RemainMp += fillMp;
        if(playerStatus.RemainMp>=playerStatus.MaxMp)
        {
            playerStatus.RemainMp = playerStatus.MaxMp;
        }

        mpText.text = $"{playerStatus.RemainMp}";
        StartCoroutine(FillMpEffect());
    }

    IEnumerator SpendMpEffect()
    {
        while(effectMp >= playerStatus.RemainMp)
        {
            mpImage.fillAmount =  effectMp / playerStatus.MaxMp;
            effectMp -= 0.2f;
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator FillMpEffect()
    {
        while(effectMp <= playerStatus.RemainMp)
        {
            mpImage.fillAmount =  effectMp / playerStatus.MaxMp;
            effectMp += 0.2f;
            yield return new WaitForSeconds(0.01f);
        }
    }
}

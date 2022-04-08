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
    PlayerState playerState;
    public float MpRecoveryDelay{get;set;}

    void Start()
    {
        mpImage = GetComponent<Image>();
        mpText = GetComponentInChildren<Text>();
        UIChannel.OnSpendMp += SpendMp;
        effectMp = playerState.MaxMp;
        MpRecoveryDelay = 1;
    }

    void Update()
    {
        if(playerState.RemainMp == playerState.MaxMp)
        {
            return;
        }

        MpRecoveryDelay -= Time.deltaTime;
        if(MpRecoveryDelay <=0)
        {
            MpRecoveryDelay=1;
            mpText.text = $"{playerState.RemainMp}";
            playerState.RemainMp +=1;
            StartCoroutine(FillMpEffect());
        }
        Debug.Log(playerState.RemainMp);
    }

    void OnDestroy() 
    {
        UIChannel.OnSpendMp -= SpendMp;
    }

    void SpendMp(int spendMp)
    {
        playerState.RemainMp -= spendMp;
        if(playerState.RemainMp < 0)
        {
            playerState.RemainMp = 0;
        }
        mpText.text = $"{playerState.RemainMp}";
        StartCoroutine(SpendMpEffect());
    }

    IEnumerator SpendMpEffect()
    {
        while(effectMp >= playerState.RemainMp)
        {
            mpImage.fillAmount =  effectMp / playerState.MaxMp;
            effectMp -= 0.2f;
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator FillMpEffect()
    {
        while(effectMp <= playerState.RemainMp)
        {
            mpImage.fillAmount =  effectMp / playerState.MaxMp;
            effectMp += 0.2f;
            yield return new WaitForSeconds(0.01f);
        }
    }
}

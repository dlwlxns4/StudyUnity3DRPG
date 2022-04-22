using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MonsterState : MonoBehaviour
{
    public enum EnemyState{Normal, Boss};
    EnemyState enemyState;
    public Image normalHpImage;
    public Text normalNameText;
    public Text normalRemainHpText;
    public Animator normalAnimator;
    public Image bossHpImage;
    public TextMeshProUGUI bossNameText;
    public TextMeshProUGUI bossRemainHpText;
    public Animator bossAnimator;

    public delegate void SetMonsterState();
    public SetMonsterState setMonsterState; 

    public bool isDamaged=false;

    LivingEntity LivingEntity;

    void Awake()
    {
        UIChannel.OnSetMonsterState += SetState;
        UIChannel.OnBossAnimatorEvent += RaiseBossFillAmountAnime;
        normalHpImage.transform.parent.gameObject.SetActive(false);
        bossHpImage.transform.parent.gameObject.SetActive(false);
    }

    private void OnDestroy() 
    {
        UIChannel.OnSetMonsterState -= SetState;
    }

    private void OnEnable() 
    {
        normalAnimator.Play("Enable");
    }

    private void SetState(LivingEntity livingEntity, bool isBoss)
    {
        if(this.LivingEntity != livingEntity)
        {
        }
        Debug.Log(isBoss);

        switch(isBoss)
        {
            case false:
            SetNormalEnemyState(livingEntity);
            break;
            case true:
            SetBossEnemyState(livingEntity);
            break;           
        }
    }

    void SetNormalEnemyState(LivingEntity livingEntity)
    {
        if(normalHpImage.transform.parent.gameObject.activeSelf == false)
        {
            normalHpImage.transform.parent.gameObject.SetActive(true);
        }

        normalAnimator.Play("Enable");
        isDamaged=true;
        normalNameText.text = livingEntity.MonsterName;
        normalRemainHpText.text =  $"{livingEntity.RemainHp}";
        normalHpImage.fillAmount = livingEntity.RemainHp/(float)livingEntity.MaxHp;
        StopCoroutine(FadeOutPanel());
        StartCoroutine(FadeOutPanel());
    }

    void SetBossEnemyState(LivingEntity livingEntity)
    {
        isDamaged=true;
        bossNameText.text = livingEntity.MonsterName;
        bossRemainHpText.text =  $"{livingEntity.RemainHp}";
        bossHpImage.fillAmount = livingEntity.RemainHp/(float)livingEntity.MaxHp;
    }

    IEnumerator FadeOutPanel()
    {
        isDamaged=false;
        yield return new WaitForSeconds(3f);

        if(isDamaged==false)
        {
            normalHpImage.transform.parent.gameObject.SetActive(false);
        }
    }

    void RaiseBossFillAmountAnime(LivingEntity living)
    {
        StartCoroutine(BossAniamtor(living));
    }

    IEnumerator BossAniamtor(LivingEntity livingEntity)
    {
        float fillAmount = bossHpImage.fillAmount;
        bossHpImage.transform.parent.gameObject.SetActive(true);
        bossNameText.text = livingEntity.MonsterName;
        bossRemainHpText.text =  $"{livingEntity.RemainHp}";
        while(bossHpImage.fillAmount<1f)
        {
            fillAmount +=0.05f;
            bossHpImage.fillAmount = fillAmount;
            yield return new WaitForSeconds(0.01f);
        }
    }
}

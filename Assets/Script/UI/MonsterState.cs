using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterState : MonoBehaviour
{
    public Text nameText;
    public Text remainHpText;

    public delegate void SetMonsterState();
    public SetMonsterState setMonsterState; 

    public bool isDamaged=false;

    Animator animator;
    LivingEntity LivingEntity;

    void Awake()
    {
        animator = GetComponent<Animator>();
        UIChannel.OnSetMonsterState += SetState;
        this.gameObject.SetActive(false);
    }

    private void OnDestroy() {
        UIChannel.OnSetMonsterState -= SetState;
    }

    private void OnEnable() 
    {
        animator.Play("Enable");
    }

    private void SetState(LivingEntity livingEntity)
    {
        if(this.LivingEntity != livingEntity)
        {
        }
        if(this.gameObject.activeSelf == false)
        {
            this.gameObject.SetActive(true);
        }

        animator.Play("Enable");
        isDamaged=true;
        nameText.text = livingEntity.MonsterName;
        remainHpText.text =  $"{livingEntity.RemainHp}";
        StartCoroutine(FadeOutPanel());
    }

    IEnumerator FadeOutPanel()
    {
        isDamaged=false;
        yield return new WaitForSeconds(3f);

        if(isDamaged==false)
        {
            this.gameObject.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : LivingEntity
{
    private Animator animator;

    void Start()
    {
        MaxHp=30;
        RemainHp=30;
        MonsterName = "머쉬룸";
        ObjectId=1;
        animator = GetComponent<Animator>();
        IsDead=false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnDamaged(int damagedFigure)
    {
        if(IsDead)
        {
            Debug.Log("죽은몬스터야!!");
            return;
        }

        RemainHp -= damagedFigure;
        animator.SetBool("IsDamaged", true);
        UIChannel.RaiseSetMonsterState(RemainHp, MonsterName);
        if(RemainHp <= 0 )
        {
            Die();
        }
    }

    public override void Die()
    {
        animator.SetBool("IsDamaged", false);
        animator.SetBool("IsFollow",false);
        animator.SetBool("IsDie", true);
        IsDead=true;
        StartCoroutine(DieEffect());
        this.GetComponent<BoxCollider>().enabled = false;
        base.Die();
    }

    public override void DoAttack()
    {
        return ;
    }
}

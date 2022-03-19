using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : LivingEntity
{
    private Animator animator;

    void Start()
    {
        maxHp=10;
        remainHp=10;
        monsterName = "머쉬룸";
        animator = GetComponent<Animator>();
        isDead=false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnDamaged(int damagedFigure)
    {
        if(isDead)
            return;

        remainHp -= damagedFigure;
        animator.SetBool("IsDamaged", true);
        uiChannel.RaiseSetMonsterState(remainHp, monsterName);
        if(remainHp <= 0 )
        {
            Die();
        }
    }

    public override void Die()
    {
        animator.SetBool("IsDamaged", false);
        animator.SetBool("IsFollow",false);
        animator.SetBool("IsDie", true);
        isDead=true;
        StartCoroutine(DieEffect());
        this.GetComponent<BoxCollider>().enabled = false;
    }

    public override void DoAttack()
    {
        return ;
    }
}

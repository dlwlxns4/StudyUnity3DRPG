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

    public override void OnDamaged(int damagedFigure)
    {
        base.OnDamaged(damagedFigure);
        animator.SetBool("IsDamaged", true);
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
}

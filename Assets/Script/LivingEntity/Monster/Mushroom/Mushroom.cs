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
        if(remainHp <= 0 )
        {
            Die();
        }
    }

    public override void Die()
    {
        animator.SetBool("IsDamaged", false);
        animator.SetBool("IsDie", true);
        animator.SetBool("IsFollow",false);
        isDead=true;
        StartCoroutine(DieEffect());
    }

    public override void DoAttack()
    {
        return ;
    }

    IEnumerator DieEffect()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }
}

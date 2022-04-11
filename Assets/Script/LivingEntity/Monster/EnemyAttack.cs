using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    enum AttackState {Shooting, AOE};
    AttackState attackState;

    float attackDelay=0f;
    Animator animator;

    int beamAttackCount = 0;
    int beamAttackMaxCount = 3;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator AttackDelay()
    {
        attackState = (AttackState)Random.Range(0, 2);

        while(attackDelay<=2f)
        {
            attackDelay+=Time.deltaTime;
            if(attackDelay >=2f)
            {
                switch(attackState)
                {
                    case AttackState.Shooting:
                    animator.SetBool("IsBeamAttack", true);
                    Debug.Log("Beam");
                    break;

                    case AttackState.AOE:
                    animator.SetBool("IsAoeAttack", true);
                    Debug.Log("Aoe");

                    break;
                }


                attackDelay = 0;
                animator.SetBool("IsFollow", false);
                animator.SetBool("IsReady", false);
            }
            yield return null;
        }
    }

    public void CheckAttackEnd()
    {
        switch(attackState)
        {
            case AttackState.Shooting:
            beamAttackCount++;
            if(beamAttackCount < beamAttackMaxCount)
            {
                animator.SetBool("IsBeamAttack", true);
            }
            else
            {
                animator.SetBool("IsBeamAttack", false);
                beamAttackCount=0;
            }
            break;

            case AttackState.AOE:
            animator.SetBool("IsAoeAttack", false);
            break;
        }
    }
}

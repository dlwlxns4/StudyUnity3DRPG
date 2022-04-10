using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DruydReadyState : ReadyState
{
    enum AttackState {Shooting, AOE};
    AttackState attackState;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        attackState = (AttackState)Random.Range(0, 1);
        Debug.Log(attackState);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemyTransform.rotation = Quaternion.Lerp(enemyTransform.rotation, Quaternion.LookRotation(enemy.GetTargetTransform().position - enemyTransform.position), Time.deltaTime * 5f);
       
        attackDelay+=Time.deltaTime;
        if(attackDelay >=2f)
        {
            switch(attackState)
            {
                case AttackState.Shooting:
                animator.SetBool("IsBeamAttack", true);
                break;
            }


            attackDelay = 0;
            animator.SetBool("IsFollow", false);
            animator.SetBool("IsReady", false);
        }
        

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}

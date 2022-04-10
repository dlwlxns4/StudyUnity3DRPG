using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DruydFollowState : FollowState
{
    float attackDelay;
    float elaspedTime=0f;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        attackDelay = Random.Range(5f, 10f);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemyTransform.position = Vector3.MoveTowards(enemyTransform.position, enemy.GetTargetTransform().position, Time.deltaTime * moveSpeed);
        enemyTransform.rotation = Quaternion.Lerp(enemyTransform.rotation, Quaternion.LookRotation(enemy.GetTargetTransform().position - enemyTransform.position), Time.deltaTime * 5f);
    
        elaspedTime+= Time.deltaTime;
        if(attackDelay <= elaspedTime)
        {
            animator.SetBool("IsReady", true);
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

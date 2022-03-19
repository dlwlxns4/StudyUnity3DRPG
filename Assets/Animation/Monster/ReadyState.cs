using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyState : StateMachineBehaviour
{
    Transform enemyTransform;
    Enemy enemy;

    float attackDelay=0f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemyTransform = animator.GetComponent<Transform>();
        enemy = animator.GetComponent<Enemy>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(Vector3.Distance(enemyTransform.position, enemy.GetTargetTransform().position) > 4f )
        {
            animator.SetBool("IsBack", true);
        }
        else if(Vector3.Distance(enemyTransform.position, enemy.GetTargetTransform().position) < 1f )
        {
            attackDelay+=Time.deltaTime;
            if(attackDelay >=2f)
            {
                animator.SetBool("IsAttack", true);
                attackDelay = 0;
            }
        }  
        else
        {
            animator.SetBool("IsFollow",true);
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

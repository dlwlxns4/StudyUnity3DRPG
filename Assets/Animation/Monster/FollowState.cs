using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowState : StateMachineBehaviour
{
    protected Transform enemyTransform;
    protected Enemy enemy;
    [SerializeField]
    protected float moveSpeed;
    [SerializeField]
    protected float targetDistance;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       enemyTransform = animator.GetComponent<Transform>();
       enemy = animator.GetComponent<Enemy>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemyTransform.position = Vector3.MoveTowards(enemyTransform.position, enemy.GetTargetTransform().position, Time.deltaTime * moveSpeed);
        enemyTransform.rotation = Quaternion.Lerp(enemyTransform.rotation, Quaternion.LookRotation(enemy.GetTargetTransform().position - enemyTransform.position), Time.deltaTime * 5f);

        if(Vector3.Distance(enemyTransform.position, enemy.GetTargetTransform().position) < targetDistance )
        {
            animator.SetBool("IsReady", true);
            animator.SetBool("IsFollow",false);
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

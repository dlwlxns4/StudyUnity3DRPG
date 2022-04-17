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
        attackDelay = Random.Range(5f, 7f);
    }

}

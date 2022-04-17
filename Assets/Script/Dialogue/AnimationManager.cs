using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    Animator animator;
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable() 
    {
        animator.Play("Enable");
    }

    private void OnDisable() 
    {
        animator.Play("Disable");    
    }
}

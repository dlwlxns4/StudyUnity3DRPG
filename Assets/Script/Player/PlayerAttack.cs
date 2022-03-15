using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private PlayerInput playerInput;
    private Animator playerAnimator;
    private int comboStep;
    private bool isComboPossible;

    public delegate void OnAttack();
    public OnAttack onAttack;
    private PlayerMovement playerMovement;
    private Rigidbody playerRigidBody;

    // Start is called before the first frame update
    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerAnimator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        playerRigidBody = GetComponent<Rigidbody>();

        playerInput.attackInput = false;
    }

    // Update is called once per frame
    void Update()
    {
        DoAttack();   
    }

    private void DoAttack()
    {
        if(playerInput.attackInput==true)
        {
            if(comboStep==0)
            {
                playerAnimator.Play("AttackA");
                OnRaiseAttack();
                comboStep = 1;

                return ;
            }

            if(comboStep !=0)
            {
                if(isComboPossible)
                {
                    isComboPossible = false;
                    comboStep+=1;
                }
            }
        }

    }


    public void DoComboAttack()
    {
        bool isAttack = true;
        switch(comboStep)
        {
            case 2:
                playerAnimator.Play("AttackB");
                break;
            case 3:
                playerAnimator.Play("AttackC");
                break;
            case 4:
                playerAnimator.Play("AttackD");
                break;
            case 5:
                playerAnimator.Play("AttackE");
                break;
            case 6:
                playerAnimator.Play("AttackToStand");
                break;
            default:
                isAttack=false;
                break;
        }

        if(isAttack)
        {
            AttackReboundReset();
        }
    }
    public void ComboPossible()
    {
        isComboPossible = true;
        AttackRebound();
    }

    private void OnRaiseAttack()
    {
        onAttack?.Invoke();
    }

    public void ComboReset()
    {
        playerMovement.RaiseCanMove();
        isComboPossible = false;
        comboStep = 0;
        AttackReboundReset();
    }

    public void ResetOnlyComboStepAndComboPossible()
    {
        isComboPossible = false;
        comboStep = 0;
    }

    public void AttackRebound()
    {
        Vector3 forward = transform.forward*0.5f;
        playerRigidBody.velocity += forward;
    }
    
    private void AttackReboundReset()
    {
        playerRigidBody.velocity = Vector3.zero;
    }
}

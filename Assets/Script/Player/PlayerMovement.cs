using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerInput playerInput;
    Rigidbody playerRigidBody;
    Animator animator;

    [SerializeField] float moveSpeed = 4f;


    void Awake()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        Rotate();
    }

    void Move()
    {
        Vector3 moveDir = new Vector3(playerInput.xInput, 0f, playerInput.yInput) * moveSpeed * Time.deltaTime;
        //대각선 이동 속도제어
        if(Mathf.Abs(playerInput.xInput) == 1 && Mathf.Abs(playerInput.yInput)==1)
        {
            moveDir /= Mathf.Sqrt(2f);
        }
        playerRigidBody.position += moveDir;

        //Animator Run
        bool isRun;
        isRun = moveDir.magnitude > 0 ? true : false;
        animator.SetBool("IsRun", isRun);
    }

    private void Rotate()
    {
        float xInput = playerInput.xInput;
        float yInput = playerInput.yInput;

        //None KeyInput
        if(xInput==0 && yInput==0)
        {
            return ;
        }

        float rotate = 0;
        if (xInput == 1)
        {
            rotate = 90 + (-45) * (yInput);
        }
        else if (xInput == 0)
        {
            rotate = 90 + (-90) * (yInput);
        }
        else if (xInput == -1)
        {
            rotate = 270 + (45) * (yInput);
        }
        playerRigidBody.rotation = Quaternion.Euler(transform.rotation.x, rotate, transform.rotation.z);
    }
}





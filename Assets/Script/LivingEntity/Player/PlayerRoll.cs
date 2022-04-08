using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRoll : MonoBehaviour
{
    private PlayerInput playerInput;
    private Animator animator;
    private Rigidbody playerRigidbody;

    [SerializeField]
    private FlowChannel flowChannel;
    [SerializeField]
    private FlowState rollState;
    private PlayerState playerState;
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
        playerState = GetComponent<PlayerState>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerState.RemainMp<5)
        {
            return;
        }

        if(playerInput.rollInput)
        {
            playerInput.rollInput=false;
            UIChannel.RaiseSetMpState(5);
            animator.Play("Roll");
            StartCoroutine(Dodge());
        }
    }

    IEnumerator Dodge()
    {
        FlowState cachedFlowState = FlowStateMachine.Instance.CurrentState;
        float xInput = playerInput.xInput;
        float yInput = playerInput.yInput;
        Vector3 dodgeVelocity = new Vector3(xInput *4f, playerRigidbody.velocity.y, yInput *4f);
        //대각선 이동 속도제어
        if(Mathf.Abs(playerInput.xInput) == 1 && Mathf.Abs(playerInput.yInput)==1)
        {
            dodgeVelocity /= Mathf.Sqrt(2f);
        }


        //None KeyInput
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
        playerRigidbody.rotation = Quaternion.Euler(transform.rotation.x, rotate, transform.rotation.z);
    

        flowChannel.RaisedFlowStateRequest(rollState);

        
        playerRigidbody.velocity = dodgeVelocity;
        // playerRigidbody.velocity = transform.forward *4f;

        yield return new WaitForSeconds(0.45f);
        flowChannel.RaisedFlowStateRequest(cachedFlowState);
    }
}

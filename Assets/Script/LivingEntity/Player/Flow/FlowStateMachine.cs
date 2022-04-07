using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowStateMachine : MonoBehaviour
{
    [SerializeField]
    private FlowChannel flowChannel;
    [SerializeField]
    private FlowState startUpState;
    [SerializeField]
    private FlowState currentState;
    public FlowState CurrentState => currentState;

    private static FlowStateMachine instance;
    public static FlowStateMachine Instance => instance;


    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            flowChannel.OnFlowStateRequested += SetFlowState;
        }
        else
        {
            Destroy(this);
        }
    }

    private void OnDestroy() 
    {
        flowChannel.OnFlowStateRequested -= SetFlowState;
    }

    private void Start() 
    {
        SetFlowState(startUpState);    
    }


    private void SetFlowState(FlowState state)
    {
        if(currentState != state)
        {
            currentState=state;
            flowChannel.RaiseFlowStateChanged(currentState);
        }
    }
}

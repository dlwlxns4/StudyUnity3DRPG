using UnityEngine;
using UnityEngine.Events;
using System;

[Serializable]
public class FlowListenerEntry
{
    public FlowState state;
    public UnityEvent unityEvent;
}

public class FlowListener : MonoBehaviour
{
    [SerializeField]
    private FlowChannel flowChannel;
    [SerializeField]
    private FlowListenerEntry[] flowEntries;

    void Awake()
    {
        flowChannel.OnFlowStateChanged += OnFlowStateChanged;
    }

    private void OnFlowStateChanged(FlowState state)
    {
        FlowListenerEntry foundEntry = Array.Find(flowEntries, x => x.state == state);

        if(foundEntry!=null)
        {
            foundEntry.unityEvent.Invoke();
        }
    }
}

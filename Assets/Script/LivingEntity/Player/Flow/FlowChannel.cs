using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Flow/Flow Channel")]
public class FlowChannel : ScriptableObject
{
    public delegate void FlowStateCallBack(FlowState state);
    public FlowStateCallBack OnFlowStateRequested;
    public FlowStateCallBack OnFlowStateChanged;

    public void RaisedFlowStateRequest(FlowState state)
    {
        OnFlowStateRequested?.Invoke(state);
    }

    public void RaiseFlowStateChanged(FlowState state)
    {
        OnFlowStateChanged?.Invoke(state);
    }
}

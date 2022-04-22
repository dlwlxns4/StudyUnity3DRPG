using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChannel 
{
    public delegate void GetExpEvent(int exp);
    public static GetExpEvent OnGetExpEvent;
    public delegate void UseItem(PlayerStatus.PlayerState state, int count);
    public static UseItem OnUseItem;
    public static void RaiseGetExpEvent(int exp)
    {
        OnGetExpEvent?.Invoke(exp);
    }

    public static void RaiseUseItem(PlayerStatus.PlayerState state, int count)
    {
        OnUseItem?.Invoke(state, count);
    }
}

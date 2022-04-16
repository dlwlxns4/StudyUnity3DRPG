using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChannel 
{
    public delegate void GetExpEvent(int exp);
    public static GetExpEvent OnGetExpEvent;
    public static void RaiseGetExpEvent(int exp)
    {
        OnGetExpEvent?.Invoke(exp);
    }
}

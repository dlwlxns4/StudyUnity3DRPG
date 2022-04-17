using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChannel : MonoBehaviour
{
    public delegate void ShakeCameraEvent();
    public static ShakeCameraEvent OnshakeCamera;
    public delegate void FollowPlayerEvent(Vector3 target);
    public static FollowPlayerEvent OnFollowPlayer;


    public static void RaiseShakeCamera()
    {
        OnshakeCamera?.Invoke();
    }

    public static void RaiseFollowPlayer(Vector3 target)
    {
        OnFollowPlayer?.Invoke(target);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChannel : MonoBehaviour
{
    public delegate void ShakeCameraEvent();
    public static ShakeCameraEvent OnshakeCamera;

    public static void RaiseShakeCamera()
    {
        OnshakeCamera?.Invoke();
    }
}

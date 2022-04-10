using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FollowCamEffector : MonoBehaviour
{
    void Awake()
    {
        CameraChannel.OnshakeCamera += ShakeCamera;
    }

    void OnDestroy()
    {
        CameraChannel.OnshakeCamera -= ShakeCamera;
    }

    void ShakeCamera()
    {
        StartCoroutine(ShakeCameraCoroutine());
        Debug.Log("카메라 흔들기");
    }

    IEnumerator ShakeCameraCoroutine()
    {

        int x, y;
        x = Random.Range(1,3);
        y = Random.Range(1,3);
        Vector3 shakePos = new Vector3(x+100,this.transform.position.y, y+100);
        this.transform.position = shakePos;
        yield return new WaitForSeconds(0.1f);
    }
}

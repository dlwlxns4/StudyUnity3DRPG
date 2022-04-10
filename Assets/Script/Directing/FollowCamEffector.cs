using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class FollowCamEffector : MonoBehaviour
{
    float shakeDuration =0.2f;
    float shakeAmplitude = 1f;
    float shakeFrequency = 2.0f;
    float shakeElaspedTime = 0f;
    [SerializeField]
    CinemachineVirtualCamera virtualCamera;
    CinemachineBasicMultiChannelPerlin virtualCameraNoise;
    
    void Awake()
    {
        CameraChannel.OnshakeCamera += ShakeCamera;
        virtualCameraNoise = virtualCamera.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
    }

    void OnDestroy()
    {
        CameraChannel.OnshakeCamera -= ShakeCamera;
    }

    void ShakeCamera()
    {
        StartCoroutine(ShakeCameraCoroutine());
    }

    IEnumerator ShakeCameraCoroutine()
    {
        virtualCameraNoise.m_AmplitudeGain = shakeAmplitude;
        virtualCameraNoise.m_FrequencyGain = shakeFrequency;

        yield return new WaitForSeconds(0.08f);
         virtualCameraNoise.m_AmplitudeGain = 0;
        virtualCameraNoise.m_FrequencyGain = shakeFrequency;
    }
}

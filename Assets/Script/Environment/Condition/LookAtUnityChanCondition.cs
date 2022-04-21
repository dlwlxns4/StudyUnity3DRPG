using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Cinemachine;

public class LookAtUnityChanCondition : ConditionBoundary
{
    [SerializeField]
    CinemachineVirtualCamera followCam;
    [SerializeField]
    GameObject target;
    static bool isActive;

    void Awake()
    {
        if(isActive)
        {
            Destroy(this.gameObject);
        }
    }

    public override void ActionEvent()
    {
        if(!isActive)
        {
            isActive=true;
            StartCoroutine(SwitchTarget());
        }
    }

    IEnumerator SwitchTarget()
    {
        Transform originFollowTransform = followCam.Follow;
        Transform originLookAtTransform = followCam.LookAt;
        
        followCam.Follow = target.transform;
        followCam.LookAt = target.transform;
        
        yield return new WaitForSeconds(3f);

        followCam.Follow = originFollowTransform;
        followCam.LookAt = originLookAtTransform;
        Destroy(this.transform.parent.gameObject);
    }
}

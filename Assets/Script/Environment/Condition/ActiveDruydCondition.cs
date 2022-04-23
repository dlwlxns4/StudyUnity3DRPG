using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ActiveDruydCondition : ConditionBoundary
{
    [SerializeField]
    GameObject Druyd;
    [SerializeField]
    CinemachineVirtualCamera virtualCamera;

    public override void ActionEvent()
    {
        StartCoroutine(SetCamera());
    }

    IEnumerator SetCamera()
    {
        virtualCamera.gameObject.SetActive(true);
        Druyd.GetComponent<Animator>().Play("Effect");
        yield return new WaitForSeconds(4f);
        virtualCamera.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        UIChannel.RaiseBossStateAnimator(Druyd.GetComponent<LivingEntity>());
        Druyd.GetComponent<Animator>().SetBool("IsFollow", true);
        SoundManager.Instance.ClipChange(SoundManager.Instance.bossSound);
        Destroy(this.transform.parent.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public Transform target{get;set;}
    Vector3 newPos;

    // Update is called once per frame
    void Update()
    {
        newPos = target.position;
        newPos.y += 0.3f;
        this.transform.position=newPos;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtWorldFront : MonoBehaviour
{

    Transform camPosition;

    void Start()
    {
        camPosition = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(transform.position + camPosition.rotation * Vector3.forward, camPosition.rotation * Vector3.up);
    }
}

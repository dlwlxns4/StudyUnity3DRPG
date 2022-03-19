using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform targetPosition;
    private Vector3 bornedPosition;

    void Start()
    {
        targetPosition = GameObject.FindGameObjectWithTag("Player").transform;
        bornedPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Transform GetTargetTransform()
    {
        return targetPosition;
    } 

    public Vector3 GetBornedPosition()
    {
        return bornedPosition;
    }
}
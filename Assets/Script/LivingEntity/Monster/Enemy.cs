using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : LivingEntity
{
    private Transform targetPosition;
    private Vector3 bornedPosition;

    void Awake()
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

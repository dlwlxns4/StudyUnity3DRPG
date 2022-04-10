using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    GameObject boomParticle;
    
    private Vector3 targetPosition;

    public void Init(Vector3 targetPos)
    {
        targetPosition = targetPos;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * moveSpeed);
    }

    void OnCollisionEnter(Collision collision)
    {
        Instantiate(boomParticle, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}

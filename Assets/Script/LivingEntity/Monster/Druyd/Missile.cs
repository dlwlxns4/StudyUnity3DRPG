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
        targetPosition = targetPos- transform.position ;
        targetPosition = targetPosition.normalized;
    }

    void Update()
    {
        transform.Translate(targetPosition * Time.deltaTime * moveSpeed);
    }

    void OnCollisionEnter(Collision other) 
    {
        Debug.Log(other.gameObject.name);
        Instantiate(boomParticle, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

}

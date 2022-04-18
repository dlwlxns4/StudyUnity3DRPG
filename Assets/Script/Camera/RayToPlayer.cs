using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayToPlayer : MonoBehaviour
{
    float distanceToPlayer;
    Vector3 direction;
    Transform target;
    Renderer obstacleRenderer;
    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, target.position);
        direction = (target.position - transform.position).normalized;
        RaycastHit hit;
        Debug.DrawRay(transform.position, direction* distanceToPlayer, Color.red, 0.1f);
        if(Physics.Raycast(transform.position, direction, out hit, distanceToPlayer))
        {
            if(hit.transform.gameObject.tag !="Player")
            {
                obstacleRenderer = hit.transform.gameObject.GetComponentInChildren<Renderer>();
                Debug.Log(obstacleRenderer);
                if(obstacleRenderer!=null)
                {
                    Material material = obstacleRenderer.material;
                    Color materialColor = material.color;
                    materialColor.a = 0.5f;
                    material.color = materialColor; 
                }
            }
        }

    }
}

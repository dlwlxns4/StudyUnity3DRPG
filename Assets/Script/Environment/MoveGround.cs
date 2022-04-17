using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGround : MonoBehaviour
{
    Vector3 newPos;
    private void OnCollisionStay(Collision other) 
    {
        if(other.gameObject.tag == "Player")
        {
            // newPos = other.transform.position;
            // newPos.x = this.transform.position.x;
            // other.transform.position=newPos;
        }    
    }
}

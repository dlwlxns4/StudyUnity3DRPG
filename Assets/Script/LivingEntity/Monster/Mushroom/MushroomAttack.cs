using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomAttack : MonoBehaviour
{
    [SerializeField]
    BoxCollider collider;
    
    public void ActiveCollider()
    {
        collider.enabled = !collider.enabled;
    }
}

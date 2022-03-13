using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    PlayerInteract playerInteract;
    // Start is called before the first frame update
    void Start()
    {
        playerInteract = GetComponent<PlayerInteract>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Attack()
    {
        if(playerInteract.interactState != PlayerInteract.InteractState.NONE)
        {
            return ;
        }


    }
}

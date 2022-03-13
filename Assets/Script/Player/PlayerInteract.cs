using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerInteract : MonoBehaviour
{
    public enum InteractState {NONE, DETECTNPC, TALKING};

    List<Interactable> nearByInteractableObj = new List<Interactable>();
    [SerializeField] GameObject interactInfoPanel;
    public InteractState interactState{get; set;}
    PlayerInput playerInput;
    Rigidbody rigidbody;
    int npcCount;

    PlayerMovement playerMovement;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        rigidbody = GetComponent<Rigidbody>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        InteractNPC();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        Interactable interactable = other.GetComponent<Interactable>();
        if(interactable != null)
        {
            nearByInteractableObj.Add(interactable);
            interactInfoPanel.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Interactable interactable = other.GetComponent<Interactable>();
        if(interactable != null)
        {
            nearByInteractableObj.Remove(interactable);

            if(nearByInteractableObj.Count == 0 )
            {
                interactInfoPanel.SetActive(false);
            }
        }
    }

    void InteractNPC()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(nearByInteractableObj.Count==0)
            {
                return ;
            }
            nearByInteractableObj[0].DoInteraction();
        }
    }
}

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
    [SerializeField]
    private GameObject questPanel;
    [SerializeField]
    private GameObject questInformationPanel;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        rigidbody = GetComponent<Rigidbody>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        InteractNPC();
        SetOnQuestPanel();
        SetOnInventory();
        SetOnStatus();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        Interactable interactable = other.GetComponent<Interactable>();
        if(interactable != null)
        {
            nearByInteractableObj.Add(interactable);
            interactInfoPanel.SetActive(true);
            interactInfoPanel.GetComponent<InteractPanel>().SetText(other.name);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        Interactable interactable = other.GetComponent<Interactable>();
        if(interactable != null)
        {
            nearByInteractableObj.Remove(interactable);
            if(nearByInteractableObj.Count == 0 )
            {
                interactInfoPanel.GetComponent<InteractPanel>().DisableAnimation(null);
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
            ClearNearObj();
        }
    }

    public void SetOnQuestPanel()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            questPanel.SetActive(!(questPanel.activeSelf));
        }
    }

    public void ClearNearObj()
    {
        nearByInteractableObj.Clear();
    }

    public void SetOnInventory()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            UIChannel.RaiseSetInven();
        }
    }

    public void SetOnStatus()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            UIChannel.RaiseStatusPanel();
        }
    }
}

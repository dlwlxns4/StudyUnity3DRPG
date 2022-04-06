using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField]
    private int sceneNumber;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Vector3 movePosition;
    
    public void DoPortal()
    {
        SceneManager.LoadScene(sceneNumber);
        player.transform.position = movePosition;
    }

    void Awake()   
    {
        player = GameObject.FindWithTag("Player");
    }
    
}


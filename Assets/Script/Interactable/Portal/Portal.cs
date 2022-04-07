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
        if(new Vector2(0, -1.0f).normalized == -Vector2.up)
        {
            Debug.Log("몰루");
        }
        player = GameObject.FindWithTag("Player");
    }
    
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Portal : MonoBehaviour
{
    [SerializeField]
    private int sceneNumber;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Vector3 movePosition;
    [SerializeField]
    Image image;

    public void DoPortal()
    {
        StartCoroutine(FadeOut());
    }

    void Awake()   
    {
        player = GameObject.FindWithTag("Player");
        image = GameObject.FindGameObjectWithTag("Canvas").transform.Find("FadePanel").GetComponent<Image>();
    }
    
    public void Init(Vector3 destination, int sceneNum)
    {
        movePosition= destination;
        sceneNumber = sceneNum;
        player = GameObject.FindWithTag("Player");
        image = GameObject.FindGameObjectWithTag("Canvas").transform.Find("FadePanel").GetComponent<Image>();
    }

    IEnumerator FadeOut()
    {
        image.gameObject.SetActive(true);
        Color opacity = image.color;
        while(opacity.a <=1f)
        {
            opacity.a += 0.05f;
            image.color= opacity;
            yield return new WaitForSeconds(0.05f);
        }
        
        SceneManager.LoadScene(sceneNumber);
        player.transform.position = movePosition;
        CameraChannel.RaiseFollowPlayer(player.transform.position);
        image.GetComponent<SceneEffect>().FadeIn();
    }


}


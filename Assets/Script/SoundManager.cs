using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    public AudioClip jungleSound;
    public AudioClip bossSound;
    public AudioClip rewindSound;
    AudioSource audioSource;

    void Awake()
    {
        if(Instance == null)
        {
            audioSource = Camera.main.GetComponent<AudioSource>();
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void Play()
    {
        StartCoroutine(Cresendo());
    }

    public void ClipChange(AudioClip clip)
    {
        StartCoroutine(Decresendo(clip));
    }

    IEnumerator Cresendo()
    {
        float volume = Camera.main.GetComponent<AudioSource>().volume;
        Camera.main.GetComponent<AudioSource>().Play();
        while(volume<0.1f)
        {
            volume+=0.01f;
            Debug.Log("뿌뤼ㅃ뤼루");
            Camera.main.GetComponent<AudioSource>().volume = volume;
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator Decresendo(AudioClip clip)
    {
        float volume = Camera.main.GetComponent<AudioSource>().volume;
        while(volume>0f)
        {
            volume-=0.01f;
            Camera.main.GetComponent<AudioSource>().volume = volume;
            yield return new WaitForSeconds(0.1f);
        }
        Camera.main.GetComponent<AudioSource>().clip = clip;
        StartCoroutine(Cresendo());
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneEffect : MonoBehaviour
{
    Image fadeInOutImage;
    Color imageColor;

    void Start()
    {
        fadeInOutImage = GetComponent<Image>();
        gameObject.SetActive(false);
        // screenDirecting;
        // StartCoroutine(FadeInScreen());
    }

    public void FadeOut()
    {
        StartCoroutine(FadeOutScreen());
    }
    public void FadeIn()
    {
        StartCoroutine(FadeInScreen());
    }

    IEnumerator FadeOutScreen()
    {
        while(fadeInOutImage.color.a <=1f)
        {
            imageColor.a += 0.1f;
            fadeInOutImage.color = imageColor;
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator FadeInScreen()
    {
        yield return new WaitForSeconds(0.3f);
        imageColor.a = 1.0f;
        while(fadeInOutImage.color.a >=0f)
        {
            imageColor.a -= 0.05f;
            fadeInOutImage.color = imageColor;
            yield return new WaitForSeconds(0.05f);
        }
        this.gameObject.SetActive(false);
    }
}

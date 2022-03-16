using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneEffect : MonoBehaviour
{

    Image fadeInOutImage;
    Color imageColor;

    [Header("DollyCam")]
    public ScreenDirecting screenDirecting;
    
    void Start()
    {
        fadeInOutImage = GetComponent<Image>();
        // screenDirecting;
        screenDirecting.endOfBranch+=FadeToggleHelper;

        StartCoroutine(FadeInScreen());
    }

    void FadeToggleHelper()
    {
        StartCoroutine(FadeToggleScreen());
    }

    IEnumerator FadeToggleScreen()
    {
        while(fadeInOutImage.color.a <=1f)
        {
            imageColor.a += 0.1f;
            fadeInOutImage.color = imageColor;
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(2f);
        
        StartCoroutine(FadeInScreen());
    }

    IEnumerator FadeInScreen()
    {
        imageColor.a = 1.0f;
        while(fadeInOutImage.color.a >=0f)
        {
            imageColor.a -= 0.1f;
            fadeInOutImage.color = imageColor;
            yield return new WaitForSeconds(0.1f);
        }
    }

    
}

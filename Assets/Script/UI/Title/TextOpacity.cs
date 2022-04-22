using System.Collections;
using UnityEngine;
using TMPro;

public class TextOpacity : MonoBehaviour
{  
    [SerializeField]
    TextMeshProUGUI text;


    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        Color color = text.color;
        while(color.a>0f)
        {
            color.a-=0.1f;
            text.color = color;
            yield return new WaitForSeconds(0.05f);
        }
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        Color color = text.color;
        while(color.a<1f)
        {
            color.a+=0.1f;
            text.color = color;
            yield return new WaitForSeconds(0.05f);
        }
        StartCoroutine(FadeOut());
    }
}

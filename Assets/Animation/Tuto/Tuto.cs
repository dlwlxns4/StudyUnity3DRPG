using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tuto : MonoBehaviour
{
    [SerializeField]
    Image fadePanel;

    void Awake()
    {
        Color panelColor = fadePanel.color;
        panelColor.a = 1f;
        fadePanel.color = panelColor;
    }

    public void RaiseFadeIn()
    {
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        Color panelColor = fadePanel.color;
        while(panelColor.a>0f)
        {
            panelColor.a -= 0.01f;
            fadePanel.color = panelColor;
            yield return new WaitForSeconds(0.03f);
        }
    }
    public void RaiseFadeOut()
    {
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        Color panelColor = fadePanel.color;
        while(panelColor.a<1f)
        {
            panelColor.a += 0.01f;
            fadePanel.color = panelColor;
            yield return new WaitForSeconds(0.02f);
        }
        SceneManager.LoadScene(0);
    }
}

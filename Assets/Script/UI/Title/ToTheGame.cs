using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ToTheGame : MonoBehaviour
{
    [SerializeField]
    Image fadePanel;
    bool isStart;

    // Update is called once per frame
    void Update()
    {
        if(isStart)
        {
            return;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(FadeOut());
        }
    }

    IEnumerator FadeOut()
    {
        isStart = true;
        Color color = fadePanel.color;
        while(color.a<1f)
        {
            color.a += 0.05f;
            fadePanel.color=color;
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(3);
    }
}

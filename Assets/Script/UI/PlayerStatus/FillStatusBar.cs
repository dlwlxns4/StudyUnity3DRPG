using UnityEngine;
using UnityEngine.UI;

public class FillStatusBar : MonoBehaviour
{
    Image image;
    float currStatus=0f;

    void Awake()
    {
        image = GetComponent<Image>();
    }

    public void FillBar()
    {
        if(currStatus==1)
        {
            return ;
        }
        currStatus +=0.1f;
        image.fillAmount=currStatus/1f;
    }
}

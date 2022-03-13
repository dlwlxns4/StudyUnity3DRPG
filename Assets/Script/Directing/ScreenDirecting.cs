using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ScreenDirecting : MonoBehaviour
{
    public Image fadeInOutImage;
    Color imageColor;

    
    public event Action endOfBranch;
    void Start()
    {
        imageColor = fadeInOutImage.color;
    }

    public void EndOfBranch()
    {
        endOfBranch.Invoke();
    }
}

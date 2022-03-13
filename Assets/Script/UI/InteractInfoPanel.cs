using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractInfoPanel : MonoBehaviour
{
    [SerializeField] Text nameText;
    [SerializeField] Text talkText;

    public void SetNameText(string name)
    {
        nameText.text = name;
    }

}

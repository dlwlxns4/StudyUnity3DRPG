using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class StatuePanel : MonoBehaviour
{
    UnityEvent setStatusEvent;
    [SerializeField]
    TextMeshProUGUI ApText;
    [SerializeField]
    TextMeshProUGUI LvText;
    [SerializeField]
    PlayerStatus playerStatus;

    void Awake()
    {
        playerStatus.levlUpEvent.AddListener(SetLevelAp);
        this.gameObject.SetActive(false);
        UIChannel.openStatus += OpenStatus;
    }

    public void SetLevelAp(int lv, int Ap)
    {
        LvText.text = $"Level. {lv}";
        ApText.text = $"Point. {Ap}";
    }

    public void OpenStatus()
    {
        this.gameObject.SetActive(!this.gameObject.activeSelf);
    }
}

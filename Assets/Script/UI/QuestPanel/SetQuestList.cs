using UnityEngine;
using UnityEngine.UI;

public class SetQuestList : MonoBehaviour
{
    [SerializeField]
    private UIChannel uichannel;
    [SerializeField]
    private Text questNameText;

    private void Awake() 
    {
        uichannel.OnSetQuestOnUI += SetOnQuestList;
        this.gameObject.SetActive(false);
    }

    private void SetOnQuestList(string questName)
    {
        questNameText.text = questName;
    }

}

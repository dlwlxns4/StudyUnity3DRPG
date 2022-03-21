using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SetQuestInformation : MonoBehaviour, IPointerDownHandler
{


    [SerializeField]
    private UIChannel uiChannel;


    public void OnPointerDown(PointerEventData eventData)
    {
        string clickedQuestText = this.GetComponentInChildren<Text>().text;

        Quest questData = QuestManager.Instace.FindQuestData(clickedQuestText);
        uiChannel.RaiseSetQuestInformation(questData);
    }
}

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SetQuestInformation : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        string clickedQuestText = this.GetComponentInChildren<Text>().text;

        Quest questData = QuestManager.Instace.FindQuestData(clickedQuestText);
        UIChannel.RaiseSetQuestInformation(questData);
    }
}

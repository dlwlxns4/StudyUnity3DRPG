using UnityEngine;
using UnityEngine.UI;

public class SetQuestList : MonoBehaviour
{
    [SerializeField]
    private UIChannel uichannel;
    [SerializeField]
    private Text questNameText;
    [SerializeField]
    private GameObject questListPrefab;
    [SerializeField]
    private GameObject questListPanel;
    private GridLayoutGroup gridLayout;

    private void Awake() 
    {
        uichannel.OnSetQuestOnUI += SetOnQuestList;
        this.gameObject.SetActive(false);
        gridLayout = GetComponentInChildren<GridLayoutGroup>();
    }

    private void SetOnQuestList(string questName)
    {
        GameObject questList = Instantiate(questListPrefab, Vector3.zero, Quaternion.identity);
        questList.GetComponentInChildren<Text>().text = questName;

        questList.transform.SetParent(gridLayout.transform, false);
    }

}

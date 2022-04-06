using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/UI/UIChannel")]
public class UIChannel : ScriptableObject
{
    public delegate void SetMonsterState(int hp, string name);
    public static SetMonsterState OnSetMonsterState;

    public delegate void SetQuestOnUI(string questName);
    public static SetQuestOnUI OnSetQuestOnUI;

    public delegate void SetQuestInformation(Quest quest);
    public static SetQuestInformation OnSetQuestInformation;

    public static void RaiseSetMonsterState(int hp, string name)
    {
        OnSetMonsterState?.Invoke(hp, name);
    }

    public static void RaiseSetQuestOnUI(string questName)
    {
        OnSetQuestOnUI?.Invoke(questName);
    }

    public static void RaiseSetQuestInformation(Quest quest)
    {
        OnSetQuestInformation?.Invoke(quest);
    }
}

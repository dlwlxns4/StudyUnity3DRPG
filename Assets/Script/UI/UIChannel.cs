using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/UI/UIChannel")]
public class UIChannel : ScriptableObject
{
    public delegate void SetMonsterState(int hp, string name);
    public static SetMonsterState OnSetMonsterState;

    public delegate void SetQuestOnUI(string questName);
    public static SetQuestOnUI OnSetQuestOnUI;

    delegate void SetRemoveQuestOnUI(string questName);
    public static SetQuestOnUI OnRemoveQuestOnUI;

    public delegate void SetQuestInformation(Quest quest);
    public static SetQuestInformation OnSetQuestInformation;
    public delegate void SpendMpEvent(int spendMp);
    public static SpendMpEvent OnSpendMp;
    public delegate void SetInvenEvent();
    public static SetInvenEvent OnSetInven;

    public static void RaiseSetMonsterState(int hp, string name)
    {
        OnSetMonsterState?.Invoke(hp, name);
    }

    public static void RaiseSetQuestOnUI(string questName)
    {
        OnSetQuestOnUI?.Invoke(questName);
    }

    public static void RaiseRemoveQuestOnUI(string questName)
    {
        OnRemoveQuestOnUI?.Invoke(questName);
    }

    public static void RaiseSetQuestInformation(Quest quest)
    {
        OnSetQuestInformation?.Invoke(quest);
    }

    public static void RaiseSetMpState(int spendMp)
    {
        OnSpendMp?.Invoke(spendMp);
    }

    public static void RaiseSetInven()
    {
        OnSetInven?.Invoke();
    }
}

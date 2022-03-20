using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/UI/UIChannel")]
public class UIChannel : ScriptableObject
{
    public delegate void SetMonsterState(int hp, string name);
    public SetMonsterState OnSetMonsterState;

    public delegate void SetQuestOnUI(string questName);
    public SetQuestOnUI OnSetQuestOnUI;


    public void RaiseSetMonsterState(int hp, string name)
    {
        OnSetMonsterState?.Invoke(hp, name);
    }

    public void RaiseSetQuestOnUI(string questName)
    {
        OnSetQuestOnUI?.Invoke(questName);
    }
}

using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/UI/UIChannel")]
public class UIChannel : ScriptableObject
{
    public delegate void SetMonsterState(LivingEntity livingEntity, bool isBoss);
    public static SetMonsterState OnSetMonsterState;

    public delegate void SetQuestOnUI(string questName);
    public static SetQuestOnUI OnSetQuestOnUI;

    delegate void SetRemoveQuestOnUI(string questName);
    public static SetQuestOnUI OnRemoveQuestOnUI;

    public delegate void SetQuestInformation(Quest quest);
    public static SetQuestInformation OnSetQuestInformation;
    public delegate void SpendMpEvent(int spendMp);
    public static SpendMpEvent OnSpendMp;
    public delegate void FillMpEvent(int fillMp);
    public static FillMpEvent OnFillMp;
    public delegate void SpendHpEvent(int spendHp);
    public static SpendHpEvent OnSpendHp;
    public delegate void FillHpEvent(int fillHp);
    public static FillHpEvent OnFillHp;
    public delegate void SetInvenEvent();
    public static SetInvenEvent OnSetInven;
    public delegate void GetUseItemEvent(Item item, bool isGet);
    public static GetUseItemEvent OnGetUseItem;
    public delegate void AcquireCoinEvent(int coin);
    public static AcquireCoinEvent OnAcquireCoin;
    public delegate void OpenShopEvent();
    public static OpenShopEvent openShop;
    public delegate void OpenStatusEvent();
    public static OpenShopEvent openStatus;
    public delegate void SetQuickSlotEvent(Vector3 pointer, ItemSlot itemSlot);
    public static SetQuickSlotEvent OnSetQuickSlot;
    public delegate void BossAniamtorEvent(LivingEntity livingEntity);
    public static BossAniamtorEvent OnBossAnimatorEvent;

    public static void RaiseOpenShop()
    {
        openShop?.Invoke();
    }
    
    public static void RaiseSetMonsterState(LivingEntity livingEntity, bool isBoss)
    {
        OnSetMonsterState?.Invoke(livingEntity, isBoss);
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

    public static void RaiseFillMpState(int fillMp)
    {
        OnFillMp?.Invoke(fillMp);
    }

        public static void RaiseSetHpState(int spendHp)
    {
        OnSpendHp?.Invoke(spendHp);
    }

    public static void RaiseFillHpState(int fillHp)
    {
        OnFillHp?.Invoke(fillHp);
    }

    public static void RaiseSetInven()
    {
        OnSetInven?.Invoke();
    }

    public static void RaiseGetUseItem(Item itemData, bool isGet)
    {
        OnGetUseItem?.Invoke(itemData, isGet);
    }

    public static void RaiseAccuireCoin(int coin)
    {
        OnAcquireCoin?.Invoke(coin);
    }

    public static void RaiseSetQuickSlot(Vector3 pointer, ItemSlot itemSlot)
    {
        OnSetQuickSlot?.Invoke(pointer, itemSlot);
    }

    public static void RaiseStatusPanel()
    {
        openStatus?.Invoke();
    } 

    public static void RaiseBossStateAnimator(LivingEntity livingEntity)
    {
        OnBossAnimatorEvent?.Invoke(livingEntity);
    }
}

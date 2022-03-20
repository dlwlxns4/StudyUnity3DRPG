using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Combat/CombatChannel")]
public class CombatChannel : ScriptableObject
{
    public delegate void EnemyDiedEvent(LivingEntity enemy);
    public static EnemyDiedEvent OnEnemyDiedEvent;

    public static void RaiseEnemyDiedEvent(LivingEntity enemy)
    {
        OnEnemyDiedEvent?.Invoke(enemy);
    }
}

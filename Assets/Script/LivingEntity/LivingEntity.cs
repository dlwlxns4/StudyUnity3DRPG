using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LivingEntity : MonoBehaviour
{
    public int MaxHp{get;set;}
    public int RemainHp{get;set;}
    public int Strength{get;set;}
    public bool IsDead{get;set;}
    public string MonsterName{get;set;}
    public int ObjectId{get;set;}
    [SerializeField]
    protected UIChannel uiChannel;

    public abstract void OnDamaged(int damagedFigure);

    public abstract void Die();

    public abstract void DoAttack();

    public IEnumerator DieEffect()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }
}

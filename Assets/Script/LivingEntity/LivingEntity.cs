using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LivingEntity : MonoBehaviour
{
    public int maxHp{get;set;}
    public int remainHp{get;set;}
    public int strength{get;set;}
    public bool isDead{get;set;}
    public string monsterName{get;set;}
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

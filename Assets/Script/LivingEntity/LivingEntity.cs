using System.Collections;
using UnityEngine;
using UnityEngine.AI;

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

    public virtual void Die()
    {
        CombatChannel.RaiseEnemyDiedEvent(this);
    }

    public abstract void DoAttack();

    public IEnumerator DieEffect()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }

    public void Respawn(Vector3 spawnerPoint, int distance)
    {
        Vector3 spawnPosition = Random.insideUnitSphere*distance + spawnerPoint;
        spawnPosition.y = spawnerPoint.y+0.5f;
        RemainHp = MaxHp;
        IsDead=false;
        this.transform.position=spawnPosition;
        this.gameObject.SetActive(true);
    }
}

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
    Material material;
    [SerializeField]
    Material flickerMaterial;
    protected UIChannel uiChannel;
    [SerializeField]
    private SkinnedMeshRenderer meshRenderer;

    private void Awake() 
    {
        meshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
    }

    public virtual void OnDamaged(int damagedFigure)
    {
        if(IsDead)
        {
            return;
        }

        RemainHp -= damagedFigure;
        UIChannel.RaiseSetMonsterState(RemainHp, MonsterName);
        StartCoroutine(MaterialFlicker());
        if(RemainHp <= 0 )
        {
            Die();
            this.GetComponent<ItemDropable>()?.DropItem();
        }
    }

    public virtual void Die()
    {
        CombatChannel.RaiseEnemyDiedEvent(this);
    }

    public virtual IEnumerator DieEffect()
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
        this.GetComponent<BoxCollider>().enabled = true;
        this.gameObject.SetActive(true);
    }

    IEnumerator MaterialFlicker()
    {
        meshRenderer.material = flickerMaterial;
        yield return new WaitForSeconds(0.05f);
        meshRenderer.material = material;
    }
}

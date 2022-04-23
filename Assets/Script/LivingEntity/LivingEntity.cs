using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public abstract class LivingEntity : MonoBehaviour
{
    public int MaxHp{get;set;}
    public int RemainHp{get;set;}
    public int Strength;
    public bool IsDead{get;set;}
    public string MonsterName{get;set;}
    public int ObjectId{get;set;}
    [SerializeField]
    int exp;
    public int Exp{get{return exp;}set{exp=value;}}
    public Vector3 HomePos{get;set;}
    protected Material cacheMaterial;
    [SerializeField]
    protected Material flickerMaterial;
    private SkinnedMeshRenderer meshRenderer;
    [SerializeField]
    bool isBoss;

    private void Awake() 
    {
        meshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        cacheMaterial = meshRenderer.material;
    }

    public virtual void OnDamaged(int damagedFigure)
    {
        if(IsDead)
        {
            return;
        }

        RemainHp -= damagedFigure;
        
        UIChannel.RaiseSetMonsterState(this, isBoss);
        
        
        StartCoroutine(MaterialFlicker());
        if(RemainHp <= 0 )
        {
            GetComponent<Animator>().SetBool("IsDie", true);
            Die();
            Debug.Log("EXP!" + exp);
            PlayerChannel.RaiseGetExpEvent(exp);
            this.GetComponent<ItemDropable>()?.DropItem();
        }
    }

    public virtual void Die()
    {
        CombatChannel.RaiseEnemyDiedEvent(this);
        IsDead=true;
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
        HomePos = spawnPosition;
    }

    IEnumerator MaterialFlicker()
    {
        meshRenderer.material = flickerMaterial;
        yield return new WaitForSeconds(0.05f);
        meshRenderer.material = cacheMaterial;
    }

}

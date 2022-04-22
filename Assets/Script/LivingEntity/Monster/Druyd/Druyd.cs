using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Druyd : LivingEntity, IAttackable, IMovable, IBasicAttack, IAoeAttack
{

    Transform target;
    [SerializeField]
    GameObject BeamShooter;
    private Animator animator;
    [SerializeField]
    GameObject missilePrefab;
    [SerializeField]
    GameObject pillarBlastPrefab;
    [SerializeField]
    GameObject pillarEffectPrefab;
    NavMeshAgent navMesh;
    float attackDelay;
    enum AttackState{Beam, Aoe};
    AttackState attackState;
    bool isShoot=false;
    int shootCount=0;
    GameObject portalPrefab;
    void Start()
    {
        MaxHp=100;
        RemainHp=100;
        MonsterName = "드라이어드";
        ObjectId=2;
        animator = GetComponent<Animator>();
        IsDead=false;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        navMesh = GetComponent<NavMeshAgent>();
    }

    public override void OnDamaged(int damagedFigure)
    {
        base.OnDamaged(damagedFigure);
    }

    void DoBeamAttack()
    {
        Vector3 rotate = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
        this.transform.LookAt(rotate);
        attackDelay += Time.deltaTime;
        if(isShoot)
        {  
            if(attackDelay >= 1.04f)
            {
                attackDelay=0;
                isShoot=false;
                if(shootCount==2)
                {
                    shootCount=0;
                    animator.SetBool("IsFollow", true);
                }
            }     
            return;
        }    

        if(!isShoot)
        {
            if(attackDelay >= 0.2f)
            {
                isShoot=true;
                GameObject missile = Instantiate(missilePrefab, BeamShooter.transform.position, Quaternion.identity);
                missile.GetComponent<Missile>().Init(target.position);
                attackDelay=0;
                shootCount++;
            }
        }
    }

    public void BasicAttack()
    {
        throw new System.NotImplementedException();
    }

    public void AoeAttack()
    {
        int count=0;
        Vector3 rotation = new Vector3(-90,0,0);
        
        attackDelay += Time.deltaTime;
        for(int i=0; i<3; ++i)
        {
            if(attackDelay>=2f)
            {
                while(count<20)
                {
                    Vector3 spawnPosition = Random.insideUnitSphere * 10 + this.transform.position;
                    spawnPosition.y = this.transform.position.y + 0.6f;
                    GameObject gameObject =Instantiate(pillarEffectPrefab, spawnPosition, Quaternion.Euler(rotation));
                    StartCoroutine(CreateExplosion(spawnPosition));
                    count++;
                    Debug.Log(i);
                }
                count=0;
                attackDelay=0;
            }
        }
        // StartCoroutine(BlastAoeAttack());
    }

    // IEnumerator BlastAoeAttack()
    // {
    //     int count=0;
    //     Vector3 rotation = new Vector3(-90,0,0);
    //     for(int i=0; i<3; ++i)
    //     {
    //         while(count<20)
    //         {
    //             Vector3 spawnPosition = Random.insideUnitSphere * 10 + this.transform.position;
    //             spawnPosition.y = this.transform.position.y + 0.6f;
    //             GameObject gameObject =Instantiate(pillarEffectPrefab, spawnPosition, Quaternion.Euler(rotation));
    //             StartCoroutine(CreateExplosion(spawnPosition));
    //             count++;
    //         }
    //         count=0;
    //         yield return new WaitForSeconds(2f);
    //     }
    // }
    IEnumerator CreateExplosion(Vector3 transform)
    {
        yield return new WaitForSeconds(1.5f);
        Instantiate(pillarBlastPrefab, transform, Quaternion.identity);
    }

    public void Move()
    {
        // throw new System.NotImplementedException();
    }

    public void CanMove()
    {
        animator.SetBool("IsFollow", true);
    }

    public void Chase()
    {
        navMesh.SetDestination(target.position);
        attackDelay += Time.deltaTime;
        if(attackDelay>=3f)
        {
            attackDelay=0;
            animator.SetBool("IsReady", true);
            animator.SetBool("IsFollow",  false);
        }
    }

    public void GoHome(Vector3 homePos)
    {
        return;
    }

    void IAttackable.AttackReady()
    {
        attackDelay += Time.deltaTime;
        if(attackDelay>=1f)
        {
            attackState = (AttackState)Random.Range(0,2);
            attackDelay = 0;
            switch(attackState)
            {
                case AttackState.Beam:
                animator.SetBool("IsBeamAttack", true);
                break;
                case AttackState.Aoe:
                animator.SetBool("IsAoeAttack", true);
                break;
            }
            animator.SetBool("IsReady", false);
        }
    }

    void IAttackable.Attack()
    {
        switch(attackState)
        {
            case AttackState.Beam:
            DoBeamAttack();
            break;
            case AttackState.Aoe:
            AoeAttack();
            break;
        }
        return ;
    }

    public void AttackExit()
    {
        animator.SetBool("IsBeamAttack", false);
        animator.SetBool("IsAoeAttack", false);
        return;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mushroom : LivingEntity, IMovable, IAttackable
{
    private Animator animator;
    
    NavMeshAgent navMesh;
    GameObject target;
    float attackDelay;

    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");
        MaxHp=30;
        RemainHp=30;
        MonsterName = "머쉬룸";
        ObjectId=1;
        animator = GetComponent<Animator>();
        IsDead=false;
    }

    public override void OnDamaged(int damagedFigure)
    {
        base.OnDamaged(damagedFigure);
        animator.SetBool("IsDamaged", true);
    }


    public override void Die()
    {
        animator.SetBool("IsDamaged", false);
        animator.SetBool("IsFollow",false);
        animator.SetBool("IsDie", true);
        IsDead=true;
        StartCoroutine(DieEffect());
        this.GetComponent<BoxCollider>().enabled = false;
        base.Die();
    }

    
    public void Move()
    {
        if(Vector3.Distance(this.transform.position, target.transform.position) > 4f )
        {
            animator.SetBool("IsBack", true);
        }
        else if(Vector3.Distance(this.transform.position, target.transform.position) < 1f )
        {
            attackDelay+=Time.deltaTime;
            if(attackDelay >=2f)
            {
                // animator.SetBool("Iseady", true);
                attackDelay = 0;
            }
        }  
        else
        {
            animator.SetBool("IsFollow",true);
            animator.SetBool("IsReady", false);
        }
        
    }

    public void CanMove()
    {
        if(Vector3.Distance(this.transform.position, target.transform.position)<=4f)
        {
            navMesh.speed = 1f;
            animator.SetBool("IsFollow", true);
        }
    }

    public void Chase()
    {
        navMesh.SetDestination(target.transform.position);

        if(Vector3.Distance(this.transform.position, target.transform.position) < 1.5f )
        {
            animator.SetBool("IsReady", true);
            animator.SetBool("IsFollow",false);
        }

        if(Vector3.Distance(this.transform.position, target.transform.position)>4f)
        {
            navMesh.speed = 2f;
            animator.SetBool("IsFollow",false);
            animator.SetBool("IsBack",true);
        }
    }

    public void GoHome(Vector3 homePos)
    {
        navMesh.SetDestination(homePos);
        if(Vector3.Distance(this.transform.position, homePos) <=0.5f)
        {
            animator.SetBool("IsBack", false);
            animator.SetBool("IsFollow", false);
        }
        
        

        if(Vector3.Distance(this.transform.position, target.transform.position)<=4f)
        {
            animator.SetBool("IsBack", false);
            animator.SetBool("IsFollow", true);
        }
    }

    public void AttackReady()
    {
        navMesh.velocity = Vector3.zero;
        attackDelay+=Time.deltaTime;
        if(attackDelay<=0.3f)
        {
            Vector3 rotate = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
            this.transform.LookAt(rotate);
        }
        
        if(attackDelay >=0.5f)
        {
            attackDelay=0;
            animator.SetBool("IsAttack", true);
            animator.SetBool("IsReady", false);
        }
    }

    public void Attack()
    {
        navMesh.velocity = Vector3.zero;
        
        attackDelay+=Time.deltaTime;
        if(attackDelay>=2f)
        {
            attackDelay=0;
            animator.SetBool("IsAttack",false);
            if(Vector3.Distance(target.transform.position, this.transform.position)<=1.1f)
            {
                animator.SetBool("IsReady", true);
            }
            else if(Vector3.Distance(target.transform.position, this.transform.position)<=4f)
            {
                animator.SetBool("IsFollow", true);
            }
            else
            {
                animator.SetBool("IsBack", true);
            }
        }
    }

    public void AttackExit()
    {
        return;
    }
}
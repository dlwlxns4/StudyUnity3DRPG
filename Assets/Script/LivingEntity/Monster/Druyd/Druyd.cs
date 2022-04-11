using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Druyd : LivingEntity, IBasicAttack, IAoeAttack
{

    private Animator animator;
    [SerializeField]
    GameObject missilePrefab;
    Transform targetTransform;
    [SerializeField]
    GameObject BeamShooter;
    [SerializeField]
    GameObject pillarBlastPrefab;
    [SerializeField]
    GameObject pillarEffectPrefab;

    void Start()
    {
        MaxHp=500;
        RemainHp=500;
        MonsterName = "페어리";
        ObjectId=2;
        animator = GetComponent<Animator>();
        IsDead=false;
        targetTransform = GetComponent<Enemy>().GetTargetTransform();
    }

    public override void OnDamaged(int damagedFigure)
    {
        base.OnDamaged(damagedFigure);
    }

    void DoBeamAttack()
    {
        GameObject missile = Instantiate(missilePrefab, BeamShooter.transform.position, Quaternion.identity);
        missile.GetComponent<Missile>().Init(targetTransform.position);
    }

    public void BasicAttack()
    {
        throw new System.NotImplementedException();
    }

    public void AoeAttack()
    {
        StartCoroutine(BlastAoeAttack());
    }

    IEnumerator BlastAoeAttack()
    {
        int count=0;
        Vector3 rotation = new Vector3(-90,0,0);
        for(int i=0; i<3; ++i)
        {
            while(count<20)
            {
                Vector3 spawnPosition = Random.insideUnitSphere * 10 + this.transform.position;
                spawnPosition.y = this.transform.position.y + 0.6f;
                GameObject gameObject =Instantiate(pillarEffectPrefab, spawnPosition, Quaternion.Euler(rotation));
                StartCoroutine(CreateExplosion(spawnPosition));
                count++;
            }
            count=0;
            yield return new WaitForSeconds(2f);
        }
    }
    IEnumerator CreateExplosion(Vector3 transform)
    {
        yield return new WaitForSeconds(1.5f);
         Instantiate(pillarBlastPrefab, transform, Quaternion.identity);
    }
}

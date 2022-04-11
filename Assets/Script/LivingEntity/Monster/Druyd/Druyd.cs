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
        throw new System.NotImplementedException();
    }
}

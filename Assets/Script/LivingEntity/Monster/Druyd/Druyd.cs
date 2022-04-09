using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Druyd : LivingEntity
{
    private Animator animator;

    void Start()
    {
        MaxHp=500;
        RemainHp=500;
        MonsterName = "페어리";
        ObjectId=2;
        animator = GetComponent<Animator>();
        IsDead=false;
    }

    public override void OnDamaged(int damagedFigure)
    {
        base.OnDamaged(damagedFigure);

    }
}

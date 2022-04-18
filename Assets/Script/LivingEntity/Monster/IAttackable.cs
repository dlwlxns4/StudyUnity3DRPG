using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackable 
{
    public void AttackReady();
    public void Attack();
    public void AttackExit();
}

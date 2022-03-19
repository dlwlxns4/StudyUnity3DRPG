using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponColliision : MonoBehaviour
{
    public bool CanDamage{get;set;}
    private int damageFigure=5;
    private PlayerAttack playerAttack; 

    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(CanDamage == false)
            return;

        if(other.tag == "Enemy")
        {
            other.GetComponent<LivingEntity>()?.OnDamaged(damageFigure);
            Debug.Log("공격!");
        }    
    }

    private void OnTriggerExit(Collider other) 
    {
        
    }
}

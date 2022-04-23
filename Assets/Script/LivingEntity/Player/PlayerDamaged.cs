using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamaged : MonoBehaviour
{


    [SerializeField]
    GameObject damagedEffectPrefab;



    private void OnTriggerEnter(Collider other) 
    {

        if(other.CompareTag("Enemy") || other.CompareTag("Damageable"))
        {
            LivingEntity livingEntity = other.GetComponent<LivingEntity>();
            if(livingEntity!=null)
            {
                Instantiate(damagedEffectPrefab, (other.transform.position+this.transform.position)/2, Quaternion.identity);
                UIChannel.RaiseSetHpState(livingEntity.Strength);
            }
        }
    }

}

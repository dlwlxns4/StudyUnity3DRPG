using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponColliision : MonoBehaviour
{
    public bool CanDamage{get;set;}
    PlayerStatus playerStatus;
    private PlayerAttack playerAttack; 
    [SerializeField]
    private GameObject hitParticlePrefab;
    [SerializeField]
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        playerStatus = GetComponentInParent<PlayerStatus>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(CanDamage == false)
            return;

        if(other.tag == "Enemy")
        {
            audioSource.Play();
            Instantiate(hitParticlePrefab, (other.transform.position+this.transform.position)/2, Quaternion.identity);
            other.GetComponent<LivingEntity>()?.OnDamaged(playerStatus.Strength);
            CameraChannel.RaiseShakeCamera();
        }    
    }
}

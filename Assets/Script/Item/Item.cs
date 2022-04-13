using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    bool canPickUp=false;

    void Awake()
    { 
    }

    private void Start() 
    {
        BoundItem();
    }

    private void Update() 
    {
    }
    public void BoundItem()
    {
        Vector3 force = new Vector3(Random.Range(-20f, 20f), 50f, Random.Range(-20f, 20f));
        this.gameObject.GetComponent<Rigidbody>().AddForce(force, ForceMode.Force);
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag=="Ground")
        {
            canPickUp=true;
        }
    }

    private void OnTriggerStay(Collider other) 
    {
        if(!canPickUp)
            return;

        if(other.tag == "Player")
        {
            StartCoroutine(GetItem(other));
            canPickUp=false;
        }
    }

    IEnumerator GetItem(Collider other)
    {
        while(true)
        {
            if(Vector3.Distance(this.transform.position, other.transform.position) <= 1f)
            {
                Destroy(this.gameObject);
                break;
            }
            this.transform.position = Vector3.MoveTowards(this.transform.position, other.transform.position,  2f * Time.deltaTime);
            // this.transform.Translate(other.transform.position * 1f * Time.deltaTime);
            yield return null;
        }
    }
}

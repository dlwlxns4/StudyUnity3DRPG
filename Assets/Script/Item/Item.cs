using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    bool canPickUp=false;
    [SerializeField]
    protected ItemData itemData;
    public ItemData GetItemData => itemData;
    private void Start() 
    {
        BoundItem();
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
            Debug.Log(this.gameObject.name);
            StartCoroutine(GetItem(other));
            canPickUp=false;
        }
    }

    IEnumerator GetItem(Collider other)
    {
        while(true)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, other.transform.position,  2f * Time.deltaTime);
            if(Vector3.Distance(this.transform.position, other.transform.position)<=0.8f)
            {
                this.GetComponent<IPickUpable>()?.AcquireItem();
                Destroy(this.gameObject);
                break;
            }
            yield return null;
        }
    }

    public void DropItem()
    {
        return ;
    }

}

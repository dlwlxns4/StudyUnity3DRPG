using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class DontDestroy : MonoBehaviour
{

    void Awake() 
    {
        OnlyOneObject.checkObject(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
    }

    public void DestoryObject()
    {
        Destroy(this.gameObject);
    }
}

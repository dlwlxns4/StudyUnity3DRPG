using UnityEngine;

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

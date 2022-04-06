using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class OnlyOneObject
{
    public static List<string> onlyOneObject = new List<string>();

    public static void checkObject(GameObject gameObject)
    {
        if(onlyOneObject.Any(x => x == gameObject.name) == false)
        {
            onlyOneObject.Add(gameObject.name);
            foreach(string a in onlyOneObject)
            {
                Debug.Log(a);
            }
        }
        else
        {
            Debug.Log("삭제!!!");
            gameObject.GetComponent<DontDestroy>()?.DestoryObject();
        }
    }
}

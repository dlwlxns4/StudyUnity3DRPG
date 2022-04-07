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
        }
        else
        {
            gameObject.GetComponent<DontDestroy>()?.DestoryObject();
        }
    }
}

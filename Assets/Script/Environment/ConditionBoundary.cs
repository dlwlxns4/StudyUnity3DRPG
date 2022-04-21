using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ConditionBoundary : MonoBehaviour
{

    public abstract void ActionEvent();

    void OnTriggerEnter(Collider other) 
    {
        ActionEvent();
    }
}

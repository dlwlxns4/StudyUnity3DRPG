using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    [SerializeField]
    private int maxHp;
    public int MaxHp
    {
        get{return maxHp;} 
        set{maxHp=value;}
    }
    [SerializeField]
    private int remainHp;
    public int RemainHp{get;set;}
    [SerializeField]
    private int maxMp;
    public int MaxMp
    {
        get{return maxMp;}
        set{maxMp = value;}
    }
    [SerializeField]
    private int remainMp;
    public int RemainMp
    {
        get{return remainMp;}
        set{remainMp = value;}
    }


}

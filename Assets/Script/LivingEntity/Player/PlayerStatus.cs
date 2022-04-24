using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField]
    private int maxHp;
    public int MaxHp{ get{return maxHp;}  set{maxHp=value;} }
    [SerializeField]
    private int remainHp;
    public int RemainHp{get{return remainHp;}set{remainHp=value;}}
    [SerializeField]
    private int maxMp;
    public int MaxMp{ get{return maxMp;} set{maxMp = value;} }
    [SerializeField]
    private int remainMp;
    public int RemainMp{ get{return remainMp;} set{remainMp = value;} }
    [SerializeField]
    private int requiredExp;
    public int RequiredExp{get{return requiredExp;}set{requiredExp=value;}}
    [SerializeField]
    private int currExp;
    public int CurrExp{get{return currExp;} set{currExp = value;}}
    [SerializeField]
    private int strength;
    public int Strength{get{return strength;}set{strength = value;}}
    public int Level{get;set;}

    [SerializeField]
    public GameObject levelUpPrefab;
    public int AbilityPoint{get;set;}

    [SerializeField]
    public UnityEvent<int,int> levlUpEvent;

    public enum PlayerState{Hp, Mp, Strength, Level}

    private void Awake() 
    {
        Level=1;
        requiredExp=10;   
        maxHp=20;
        remainHp=20;
        strength=5;
        PlayerChannel.OnGetExpEvent += GetExp;     
        PlayerChannel.OnUseItem += UseStatusItem;
    }

    public void GetExp(int exp)
    {
        currExp += exp;
        if(currExp >= requiredExp)
        {
            LevelUp();
            PlayerChannel.RaiseGetExpEvent(0);
        }
    }
    
    public void LevelUp()
    {
        Level++;
        requiredExp = (int)(requiredExp * 1.2f);
        currExp=0;
        Vector3 rotation = new Vector3(-90f, 0f, 0f);
        Vector3 newPos = this.transform.position;
        newPos.y += 0.3f;
        GameObject levelUpParticle = Instantiate(levelUpPrefab, newPos, Quaternion.Euler(rotation));
        levelUpParticle.GetComponent<FollowObject>().target = this.transform;
        AbilityPoint+=3;
        levlUpEvent.Invoke(Level, AbilityPoint);
    }

    public void IncreaseHp()
    {
        AbilityPoint--;
        maxHp +=10;
        remainHp +=10;
        levlUpEvent.Invoke(Level, AbilityPoint);
        UIChannel.RaiseSetHpState(0);
    }

    public void IncreaseStrength()
    {
        AbilityPoint--;
        strength+=1;
        levlUpEvent.Invoke(Level, AbilityPoint);
    }

    public void IncreaseMp()
    {
        AbilityPoint--;
        maxMp+=2;
        RemainMp+=2;
        UIChannel.RaiseSetMpState(0);
        levlUpEvent.Invoke(Level, AbilityPoint);
    }

    void UseStatusItem(PlayerState status, int count)
    {
        switch(status)
        {
            case PlayerState.Hp:
            UIChannel.RaiseFillHpState(count);
            break;
            case PlayerState.Mp:
            UIChannel.RaiseFillMpState(count);
            break;
        }
    }
}

using System.Collections.Generic;
using System.Collections;
using UnityEngine;
public class MonsterSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject monsterPrefab;
    [SerializeField]
    private int spawnMonsterCount;
    [SerializeField]
    private int resapwnDistance;

    private List<GameObject> monsterList = new List<GameObject>();

    void Awake()
    {
        InitMonster();
        StartCoroutine(spawnMonster());
    }

    void InitMonster()
    {
        for(int i=0; i<spawnMonsterCount; ++i)
        {
            GameObject monster = Instantiate(monsterPrefab, Vector3.zero, Quaternion.identity);
            monster.SetActive(false);
            monsterList.Add(monster);
        }
    }

    void RespawnMonster()
    {
        foreach(var monster in monsterList)
        {
            if(monster.activeSelf == false)
            {
                monster.GetComponent<LivingEntity>().Respawn(this.transform.position, resapwnDistance);
            }
        }
    }

    IEnumerator spawnMonster()
    {
        while(true)
        {
            RespawnMonster();
            yield return new WaitForSeconds(10f);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterState : MonoBehaviour
{
    public Text nameText;
    public Text remainHpText;

    public delegate void SetMonsterState();
    public SetMonsterState setMonsterState; 

    public bool isDamaged=false;

    [SerializeField]
    private UIChannel uiChannel; 

    void Awake()
    {
        UIChannel.OnSetMonsterState += SetState;
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetState(int remainHp, string name)
    {
        if(this.gameObject.activeSelf == false)
        {
            this.gameObject.SetActive(true);
        }

        isDamaged=true;
        nameText.text = name;
        remainHpText.text =  $"{remainHp}";
        StartCoroutine(FadeOutPanel());
    }

    IEnumerator FadeOutPanel()
    {
        isDamaged=false;
        yield return new WaitForSeconds(3f);

        if(isDamaged==false)
        {
            this.gameObject.SetActive(false);
        }
    }
}

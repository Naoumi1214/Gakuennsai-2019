using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPController : MonoBehaviour
{
    private GameObject hpObj;
    private int hp;

    void Awake()
    {
        Debug.Log("スタート");
        hpObj = (GameObject)Resources.Load("HP");
    }

    //体力の初期値の設定
    public void SetHP(int hp)
    {
        this.hp = hp;
        Debug.Log(this.hp);

        //体力を一旦全削除
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }

        if (this.hp>5)
        {
            this.hp = 5;
        }

        //現在の体力分表示する
        for (int i = 0; i < this.hp; i++)
        {
            GameObject HP = Instantiate(hpObj, transform);
            HP.GetComponent<RawImage>().enabled=true;

        }

        Debug.Log("体力"+this.hp);
    }

    //体力を1削る
    public void DestroyHP()
    {
        //int hpCnt = transform.childCount - 1;
        if (hp>0)
        {
            Destroy(transform.GetChild(hp-1).gameObject);
            hp--;
            Debug.Log("体力"+hp);
        }

        if (hp==0)
        {
            Debug.Log("GameOver");
        }
    }
    public int Rehp()
    {
        return this.hp;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;


///------------------------------------------------------
///------------------------------------------------------
/// <summary>
/// ■Sprite画像を利用して,フェードアウトを行うクラス.
/// </summary>
public class rescount : MonoBehaviour
{
    GameObject hp;
    HPController hpc;
    private Text targetText;
    bool tf,fst;
    long timecount;
    int retaime;
    float syoki;
    //色のための変数-------------------------------------------
    public float alpha;             //アルファ値
    public float alphaControlTime;  //アルファ値の変化時間
    float floattaime;
    //--------------------------------------------------------

    //GameObjectの取得----------------------------------------
    public GameObject spriteObject; //2Dオブジェクト(Sprite画像)の読み込み
    //-------------------------------------------------------


    ///------------------------------------------------------
    /// <summary>
    /// ●初期化する関数.
    /// </summary>
    void Start()
    {
        alpha = 0f; //アルファ値の初期値(Sprite画像が透明な状態)
        tf = true;
        fst = true;
        timecount =1000000000000000000;
        retaime = 10;
        floattaime = 0;
        syoki = 0;
    }


    ///------------------------------------------------------
    /// <summary>
    /// ●フェードアウト演出を行う関数.
    /// </summary>
    public void FadeOut()
    {
        alpha += Time.deltaTime * alphaControlTime; //アルファ値の変化

        /*Scene内にフェード(2Dオブジェクト)が存在するとき,*/
        if (GameObject.Find("Textcount") != null)
        {
            /*フェード(2Dオブジェクト)を発見し,取得する.*/
            spriteObject = GameObject.Find("Textcount");
        }

        //フェード(2Dオブジェクト)の色の読み込み--------------------
        spriteObject.GetComponent<Text>().color = new Color(255, 0, 150, alpha);
        //-------------------------------------------------------

        /*アルファ値が1以上のとき,*/
        if (alpha >= 1f)
        {
            /*アルファ値は1になる.*/
            alpha = 1f;
        }
    }


    ///------------------------------------------------------
    /// <summary>
    /// ●1秒間に呼ばれる回数が一定で実行する関数.
    /// </summary>
    void FixedUpdate()
    {
        this.hp = GameObject.Find("HPGauge");
        hpc = this.hp.GetComponent<HPController>();
        int hp = hpc.Rehp();
        if (hp == 0 || tf)
        {
            //Debug.Log(hp.DestroyHP());
            FadeOut(); //フェードアウト演出を行う関数の呼びだし
            tf = false;
        }
        if (hp == 0)
        {
            float nowtime = Time.fixedTime;
            if (fst)
            {
                syoki = nowtime;
                fst = false;
            }
            Debug.Log(Time.fixedTime);
            if (nowtime < 0)
            {
                nowtime = 0;
            }
            floattaime += nowtime;
            if (syoki+1<nowtime)
            {
                syoki++;
                timecount++;
                this.targetText = this.GetComponent<Text>();
                this.targetText.text = ""+retaime;
                retaime--;
            }
            if (retaime == 0)
            {
                SceneManager.LoadScene("main");
            }
        }
    }
}
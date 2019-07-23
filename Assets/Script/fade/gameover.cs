using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

///------------------------------------------------------
///------------------------------------------------------
/// <summary>
/// ■Sprite画像を利用して,フェードアウトを行うクラス.
/// </summary>
public class gameover : MonoBehaviour
{
    GameObject hp;
    HPController hpc;
    //色のための変数-------------------------------------------
    public float alpha;             //アルファ値
    public float alphaControlTime;  //アルファ値の変化時間
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
    }


    ///------------------------------------------------------
    /// <summary>
    /// ●フェードアウト演出を行う関数.
    /// </summary>
    public void FadeOut()
    {
        alpha += Time.deltaTime * alphaControlTime; //アルファ値の変化

        /*Scene内にフェード(2Dオブジェクト)が存在するとき,*/
        if (GameObject.Find("Image") != null)
        {
            /*フェード(2Dオブジェクト)を発見し,取得する.*/
            spriteObject = GameObject.Find("Image");
        }

        //フェード(2Dオブジェクト)の色の読み込み--------------------
        spriteObject.GetComponent<Image>().color = new Color(0, 0, 0, alpha);
        //-------------------------------------------------------

        /*アルファ値が1以上のとき,*/
        if (alpha >= 1f)
        {
            /*アルファ値は1になる.*/
            alpha = 1f;
            SceneManager.LoadScene("title");

        }
    }


    ///------------------------------------------------------
    /// <summary>
    /// ●1秒間に呼ばれる回数が一定で実行する関数.
    /// </summary>
    bool tf = true;
    void FixedUpdate()
    {
        this.hp = GameObject.Find("HPGauge");
        hpc = this.hp.GetComponent<HPController>();
        int hp = hpc.Rehp();
        if (hp==0||tf)
        {
            //Debug.Log(hp.DestroyHP());
            FadeOut(); //フェードアウト演出を行う関数の呼びだし
            tf = false;
        }
    }
}
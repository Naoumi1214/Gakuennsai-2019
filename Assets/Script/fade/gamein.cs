using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///------------------------------------------------------
///------------------------------------------------------
/// <summary>
/// ■Sprite画像を利用して,フェードインを行うクラス.
/// </summary>
public class gamein : MonoBehaviour
{
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
        alpha = 1f; //アルファ値の初期値(Sprite画像が透明でない状態)
    }


    ///------------------------------------------------------
    /// <summary>
    /// ●フェードイン演出を行う関数.
    /// </summary>
    public void FadeIn()
    {
        alpha -= Time.deltaTime * alphaControlTime; //アルファ値の変化

        /*Scene内にフェード(2Dオブジェクト)が存在するとき,*/
        if (GameObject.Find("Fade") != null)
        {
            /*フェード(2Dオブジェクト)を発見し,取得する.*/
            spriteObject = GameObject.Find("Fade");
        }

        //フェード(2Dオブジェクト)の色の読み込み--------------------
        spriteObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, alpha);
        //-------------------------------------------------------

        /*アルファ値が0以下のとき,*/
        if (alpha <= 0f)
        {
            /*アルファ値は0になる.*/
            alpha = 0f;
        }
    }


    ///------------------------------------------------------
    /// <summary>
    /// ●1秒間に呼ばれる回数が一定で実行する関数.
    /// </summary>
    void FixedUpdate()
    {
        FadeIn();  //フェードイン演出を行う関数の呼びだし
    }
}
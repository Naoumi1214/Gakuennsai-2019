using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    //変数定義
    public float flap = 350f;
    public float scroll = 5f;
    float direction = 0f;
    Rigidbody2D rb2d;
    bool jump = false;

    //Kinect関係
    KinectController kinect = new KinectController();
    
    // Use this for initialization
    void Start()
    {
        //コンポーネント読み込み
        rb2d = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        //自動で移動
        this.gameObject.transform.Translate(0.07f, 0, 0);
        //キャラのy軸のdirection方向にscrollの力をかける
        rb2d.velocity = new Vector2(scroll * direction, rb2d.velocity.y);
        this.kinect.KinectUpdate();
        //ジャンプ判定
        if ((Input.GetKeyDown("space") || this.kinect.getJumping()) && !jump)
        {
            if (kinect.getJumpingHeight() > 1.28)
            {
                rb2d.AddForce(Vector2.up * (flap * 1.5f));
                jump = true;
            }
            else
            {
                rb2d.AddForce(Vector2.up * flap);
                jump = true;
            }
           
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("yuka"))
        {
            jump = false;
        }
    }
}
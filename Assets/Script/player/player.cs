using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    //変数定義
    bool runnable = true;
    public float flap = 500f;
    Rigidbody2D rb2d;
    //bool jump = true;
    bool jump = false;
    bool stst;
    int coinCnt = 0; //コインの枚数
    private bool isMuteki;
    [SerializeField] //new
    private ItemController itemCtl;

    //
    KinectController kinect;

    // Use this for initialization
    void Start()
    {
        //コンポーネント読み込み]
        rb2d = GetComponent<Rigidbody2D>();
        stst = true;

        kinect = new KinectController();
    }


    // Update is called once per frame
    void Update()
    {
        kinect.KinectUpdate();

        if (stst)
        {
            if (runnable)
            {
                //自動で移動
                this.gameObject.transform.Translate(0.07f, 0, 0);
            }
        }

        //ジャンプ判定
        if ((Input.GetKeyDown("space") || kinect.getJumping()) && !jump)
        {
            jump = true;
            //大ジャンプ
            if (Input.GetKey(KeyCode.UpArrow) || (kinect.getJumpingHeight() >= 1.4f * kinect.getHeight()))
            {
                rb2d.AddForce(Vector2.up * flap * 1.5f);
            }
            //普通ジャンプ
            else
            {
                rb2d.AddForce(Vector2.up * flap);
            }
        }
        if (jump && rb2d.velocity.y < 0) //ジャンプ制御
        {
            Vector2 v = rb2d.velocity;
            v.y -= 0.02f;
            rb2d.velocity = v;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("stop"))
        {
            runnable = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("stop"))
        {
            runnable = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("respawn"))
        {

        }
        if (other.gameObject.CompareTag("death"))
        {
            stst = false;
        }
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        GameObject obj = other.gameObject;

        if (obj.CompareTag("yuka")) //new
        {
            jump = false;
            stst = true;
        }

    }
    void OnCollisionExit2D(Collision2D other)
    {
        /*if (other.gameObject.CompareTag("yuka"))
        {
            jump = true;
        }*/
    }

    public void CoinCounter() //new
    {
        coinCnt++;
        Debug.Log(coinCnt + "枚");
    }

    public void MutekiTime() //new
    {
        isMuteki = true;
        Debug.Log("無敵だあああ");
        itemCtl.SetItem("Muteki");
        Invoke("MutekiEnd", 10);

    }

    public void MutekiEnd() //new
    {
        isMuteki = false;
        Debug.Log("終わりだあああ");
        itemCtl.LoseItem();
    }

    public bool GetMuteki() //new
    {
        return isMuteki;
    }

}
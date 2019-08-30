using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField]
    private int hp;
    [SerializeField]
    private HPController hpCtl;
    Rigidbody2D rb2d;
    private bool isDamage = true; //trueの時ダメージを受ける

    void Start()
    {
        hp = 5;
        hpCtl.SetHP(hp); //HPControllerのStartより早く動いている
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDamage)
        {
            if (collision.gameObject.CompareTag("death"))
            {
                hpCtl.DestroyHP();
                isDamage = false;
                Debug.Log("ダメージ無効");
            }

            if (collision.gameObject.CompareTag("enemy"))
            {
                player player = GetComponent<player>();
                bool isMuteki = player.GetMuteki();
                Debug.Log(isMuteki);

                if (!(rb2d.velocity.y < 0) && !isMuteki)
                {
                    hpCtl.DestroyHP();
                    isDamage = false;
                    Debug.Log("ダメージ無効");
                    Invoke("SetIsDamage", 2);
                }
            }
        }
    }

    public void SetIsDamage()
    {
        isDamage = true;
        Debug.Log("ダメージ無効解除");
    }
}

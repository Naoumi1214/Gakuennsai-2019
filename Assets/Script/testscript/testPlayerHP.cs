using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testPlayerHP : MonoBehaviour
{
    [SerializeField]
    private int hp;
    [SerializeField]
    private HPController hpCtl;
    Rigidbody2D rb2d;
    RaycastHit2D rh2d;

    void Start()
    {
        hp = 5;
        hpCtl.SetHP(hp); //HPControllerのStartより早く動いている
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 pos = transform.position;
        pos.x += 1;
        rh2d = Physics2D.Raycast(pos,Vector2.right,1);
        Debug.DrawRay(pos, new Vector3(1, 0, 0), Color.blue, 1);
        Debug.Log("レイキャスト"+rh2d.collider);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        /*if (collision.gameObject.CompareTag("enemy"))
        {
            testplayer player = GetComponent<testplayer>();
            bool isMuteki = player.GetMuteki();
            Debug.Log(isMuteki);

            if (!(rb2d.velocity.y < 0) && !isMuteki)
            {
                hpCtl.DestroyHP();
            }
        }*/

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("death"))
        {
            hpCtl.DestroyHP();
        }

        if (collision.gameObject.CompareTag("enemy"))
        {
            testplayer player = GetComponent<testplayer>();
            bool isMuteki = player.GetMuteki();
            Debug.Log(isMuteki);

            if (!(rb2d.velocity.y < 0) && !isMuteki)
            {
                hpCtl.DestroyHP();
            }
        }
    }
}

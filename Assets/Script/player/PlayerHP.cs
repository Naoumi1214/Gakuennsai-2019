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

    void Start()
    {
        hp = 5;
        hpCtl.SetHP(hp);
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("enemy"))
        {
            player player = GetComponent<player>();
            bool isMuteki = player.GetMuteki();
            Debug.Log(isMuteki);

            if (!(rb2d.velocity.y < 0)&&!isMuteki) //new
            {
                hpCtl.DestroyHP();
            }
        }
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("death"))
        {
            hpCtl.DestroyHP();
        }
    }
}

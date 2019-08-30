using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;

        if (collision.transform.CompareTag("Player"))
        {
            player player = obj.GetComponent<player>();
            bool isMuteki = player.GetMuteki();
            Rigidbody2D rb2d = player.GetComponent<Rigidbody2D>();

            if (rb2d.velocity.y < 0 || isMuteki)
            {
                Destroy(transform.parent.gameObject);
                Debug.Log("敵を倒した");
            }
        }
    }
}

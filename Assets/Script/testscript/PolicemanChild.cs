using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolicemanChild : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;

        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("通過1");
            testplayer player = obj.GetComponent<testplayer>();
            bool isMuteki = player.GetMuteki();
            Rigidbody2D rb2d = player.GetComponent<Rigidbody2D>();

            if (rb2d.velocity.y < 0 || isMuteki)
            {
                Debug.Log("通過2");
                Destroy(transform.parent.gameObject);
            }

            Debug.Log("敵を倒した");
        }
    }
}

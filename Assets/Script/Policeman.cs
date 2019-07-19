using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Policeman : MonoBehaviour
{
    float speed = -0.05f;
    float leftOffset = -0.3f;

    void Start()
    {
       
    }

    void Update()
    {
        Vector2 pos = transform.position;
        pos.x += speed;
        transform.position = pos;

        Vector3 myViewport = Camera.main.WorldToViewportPoint(transform.position);

        //カメラ外に行くと消える
        if (myViewport.x < leftOffset)
        {
            Destroy(this.gameObject);
        }

        /*RaycastHit2D hit = Physics2D.Raycast(new Vector2(0,0),Vector2.up);
        Debug.DrawRay(pos, new Vector3(0, 0, 100), Color.blue, 1);

        if (hit.collider!=null)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                Destroy(this.gameObject);
            }
        }*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //壁にぶつかると画像が反転する
        if (collision.gameObject.CompareTag("stop")) //new
        {
            speed *= -1;
            Vector2 hanten = transform.localScale;
            hanten.x *= -1.0f;
            transform.localScale = hanten;
        }

        if (collision.gameObject.CompareTag("death"))
        {
            Destroy(this.gameObject);
        }
      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject obj = collision.gameObject;

        //上からPlayerに踏まれたら消える
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("hit");
            player player = obj.GetComponent<player>();
            bool isMuteki = player.GetMuteki();

            if (collision.relativeVelocity.y<0||isMuteki) //new
            {
                Destroy(this.gameObject);
            }
        }
        
    }

}

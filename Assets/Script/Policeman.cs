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
        /*if (myViewport.x < leftOffset)
        {
            Destroy(this.gameObject);
        }*/

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //壁にぶつかると画像が反転する
        if (collision.gameObject.CompareTag("stop_left")||collision.gameObject.CompareTag("stop_right"))
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
}

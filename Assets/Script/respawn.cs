using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject unitychan;
    Vector2 tmp;
    void Start()
    {
        /*tmp = transform.position;*/
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            tmp = GameObject.Find("player").transform.position;
        }
        if (other.gameObject.CompareTag("death"))
        {
            unitychan = GameObject.Find("player");
            unitychan.transform.position = tmp;
        }



        /*if (other.gameObject.CompareTag("death"))
        {
                foreach (ContactPoint2D deathHit in other.contacts)
                {
                    Vector2 hitPoint = deathHit.point;
                    Vector2 uni = new Vector2(hitPoint.x, hitPoint.y);
                }
            unitychan = GameObject.Find("player");
            Vector3 tmp = GameObject.Find("respawn").transform.position;
            unitychan.transform.position = tmp;
        }*/
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour
{
    GameObject player;
    Vector2 tmp;
    void Start()
    {
        /*tmp = transform.position;*/
    }

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
            player = GameObject.Find("player");
            player.transform.position = tmp;
            PlayerHP php = player.GetComponent<PlayerHP>();
            php.SetIsDamage();
        }
    }
}

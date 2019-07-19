using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death : MonoBehaviour
{
    bool f = false;
    Vector2 tmp;
    // Start is called before the first frame update
    void Start()
    {
        tmp = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (f)
        {
            this.gameObject.transform.Translate(0, 0.1f, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("respawn"))
        {
            Debug.Log("OnTriggerEnter2D: 当たったで" );
            f = false;
            transform.position = tmp;
        }
        if (other.gameObject.CompareTag("Player"))
        {
            f = true;
        }
    }
}

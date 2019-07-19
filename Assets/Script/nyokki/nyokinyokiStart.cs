using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nyokinyokiStart : MonoBehaviour
{
    /*
    bool nyokki = false;
    bool hikinyokki = false;
    bool nyokki2 = false;
    Vector2 tmp1, tmp2;
    GameObject nyoki1,nyoki2;
    // Start is called before the first frame update
    void Start()
    {
        nyoki1 = GameObject.Find("nyokinyoki");
        nyoki2 = GameObject.Find("nyokinyoki2");
    }

    // Update is called once per frame
    void Update()
    {
        tmp1 = GameObject.Find("nyokki").transform.position;
        tmp2 = GameObject.Find("nyokki2").transform.position;
        if (nyokki)
        {
            if (tmp1.y < 3.5)
            {
                nyoki1.gameObject.transform.Translate(0, 0.3f, 0);
            }
            else
            {
                nyokki = false;
            }
        }
        if (hikinyokki)
        {
            if (tmp2.y > 0)
            {
                nyoki2.gameObject.transform.Translate(0, -0.3f, 0);
            }
            else
            {
                nyokki2 = false;
            }
        }
        if (nyokki2)//初めに動く
        {
            if (tmp2.y < 3.5)
            {
                nyoki2.gameObject.transform.Translate(0, 0.3f, 0);
            }
            else
            {
                nyokki2 = false;
            }
        }

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        nyokki2 = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        nyokki = true;
        hikinyokki = true;
        nyokki2 = true;
    }
    */
}

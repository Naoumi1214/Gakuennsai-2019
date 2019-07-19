using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 screenPoint;
    // 位置座標
    private Vector3 position;

    //Kinevt関係
    Kinecter kinecter;

    Single[] righthand = null;
    void Start()
    {
        this.kinecter = new Kinecter();
    }

    // Update is called once per frame
    void Update()
    {
        if (kinecter.KinectUpdate())
        {
            Single[] righthand = kinecter.GetPosition();
            if (righthand != null)
            {
                Vector3 a = transform.position;
                a.x = righthand[0] * 10;
                a.y = righthand[1] * 10;
                //Debug.Log("a" + a.x + " " + a.y);
                transform.position = a;
                //Debug.Log("transform" + transform.position.x + " " + transform.position.y);
            }

        }
    }// void Update()

   

}

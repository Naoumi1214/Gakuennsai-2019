using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pointer : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 screenPoint;
    // 位置座標
    private Vector3 position;

    private RaycastHit Hit;

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
       /*
        //マウスの場合
        this.screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 a = new Vector3 (Input.mousePosition.x,Input.mousePosition.y,screenPoint.z);
        transform.position = Camera.main.ScreenToWorldPoint (a);*/

        //重なりの判定
        if (Physics.Raycast(transform.position, Vector3.down, out Hit))
        {

            Debug.Log(Hit.collider.name);//デバッグログにヒットした場所を出す
            if (Hit.collider.name.Equals("StartButton"))
            {
                SceneManager.LoadScene("KinectSearch");
            }

        }

      
        
        //Kinectを使用した場合
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

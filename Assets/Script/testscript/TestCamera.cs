using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCamera : MonoBehaviour
{
 
    void Start()
    {
        Vector2 cameraPos = transform.position;
        GameObject testbg = GameObject.Find("TestBackGround");
        cameraPos = testbg.transform.position;
        transform.position = cameraPos;
        
    }

    void Update()
    {
        
    }
}

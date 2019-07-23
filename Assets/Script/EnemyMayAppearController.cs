using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMayAppearController : MonoBehaviour
{
    private Vector3 emaPos;
    private float rightOffset = 1.1f;
    private GameObject enemyObj;
    private bool spawn = true; //生成されたらfalse

    void Start()
    {
        emaPos = transform.position;
        enemyObj = (GameObject)Resources.Load("Policeman");
        Debug.Log("スポーン地点"+emaPos);
    }

    void Update()
    {
        Vector3 myViewport = Camera.main.WorldToViewportPoint(emaPos);

        if (myViewport.x<rightOffset&&spawn)
        {
            Instantiate(enemyObj,emaPos, Quaternion.identity);
            spawn = false;
        }

    }
}

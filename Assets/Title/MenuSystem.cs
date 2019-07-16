using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // オブジェクトが衝突したとき
    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Enter: " + collision.gameObject.name); // 衝突先のオブジェクト名を取得
    }

    // オブジェクトが離れた時
    void OnCollisionExit(Collision collision)
    {
        Debug.Log("Exit: " + collision.gameObject.name); // 衝突していたオブジェクト名を取得
    }
}

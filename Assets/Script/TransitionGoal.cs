using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionGoal : MonoBehaviour
{
    private bool isGoal;
    private WhiteOutController WhiteOutCtl;

    private void Start()
    {
        GameObject WhiteOut = GameObject.Find("Canvas/Goal/WhiteOut");
        Debug.Log("ホワイトアウト"+WhiteOut);
        WhiteOutCtl = WhiteOut.GetComponent<WhiteOutController>();
        Debug.Log("ホワイトアウトコントローラー"+WhiteOutCtl);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isGoal = true;
            WhiteOutCtl.SetIsGoal();
            Debug.Log("脱出成功");
        }
        
    }
}

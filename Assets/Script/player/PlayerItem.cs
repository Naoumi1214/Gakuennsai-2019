using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItem : MonoBehaviour
{
    private GameObject Canvas;

    void Start()
    {
        Canvas = GameObject.Find("Canvas");
    }

    void Update()
    {
        
    }

    //各アイテムに触れた時の挙動
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject obj = other.gameObject;
        Debug.Log(obj.name);

        if (other.gameObject.CompareTag("item"))
        {
            player player;

            switch (obj.name)
            {
                case "Heal":
                    GameObject HPGauge = Canvas.transform.Find("HPGauge").gameObject;
                    HPController hpCtl = HPGauge.GetComponent<HPController>();
                    hpCtl.SetHP(hpCtl.transform.childCount+1);
                    break;
                case "Coin":
                    player = GetComponent<player>();
                    player.CoinCounter();
                    break;
                case "Muteki":
                    player = GetComponent<player>();
                    bool isMuteki = player.GetMuteki();

                    //無敵の重複はしない
                    if (!isMuteki)
                    {
                        player.MutekiTime();
                    }
                    
                    break;
            }
            Destroy(obj);
        }
    }
}

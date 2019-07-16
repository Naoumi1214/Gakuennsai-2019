using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;
    Vector2 bgPos;
    void Start()
    {
        player = GameObject.Find("player");
        GameObject Background = GameObject.Find("Background_1");
        bgPos = Background.transform.position;
    }

    void Update()
    {
        if (player.transform.position.x>bgPos.x)　//ステージ最後に当てはまらないので改良の必要あり
        {
            Vector3 p_position = player.transform.position;
            Vector3 c_position = transform.position;
            c_position.x = p_position.x;
            transform.position = c_position;
        }
    }
}

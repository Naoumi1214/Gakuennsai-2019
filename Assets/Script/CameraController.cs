using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;
    Vector2 bgPos;
    Vector2 lastMapPos;

    void Start()
    {
        player = GameObject.Find("player");
        GameObject Background = GameObject.Find("Background_1");
        bgPos = Background.transform.position;

        GameObject Mapyobidasi = GameObject.Find("Mapyobidasi");
        mapyobidasi mapyobidasi = Mapyobidasi.GetComponent<mapyobidasi>();
        lastMapPos = mapyobidasi.GetLastMapPos();
    }

    void Update()
    {
        if (player.transform.position.x>bgPos.x&&player.transform.position.x<=lastMapPos.x)
        {
            Vector3 p_position = player.transform.position;
            Vector3 c_position = transform.position;
            c_position.x = p_position.x;
            transform.position = c_position;
        }
        
    }
}

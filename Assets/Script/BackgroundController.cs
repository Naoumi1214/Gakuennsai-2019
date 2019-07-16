using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    float width; //背景のサイズ
    float leftOffset=-0.6f;
    Transform bgTfm; //背景の座標
    int spriteCount=2; //回り込む背景の枚数
    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        width = sr.bounds.size.x;
        bgTfm = transform;
    }

    void Update()
    {
        Vector3 myViewport = Camera.main.WorldToViewportPoint(bgTfm.position);

        if (myViewport.x<leftOffset)
        {
            bgTfm.position += Vector3.right * width * spriteCount;
        }
    }
}

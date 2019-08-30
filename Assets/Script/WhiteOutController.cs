using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WhiteOutController : MonoBehaviour
{
    RawImage texture;
    float red,green,blue;
    float alfa; //初期値0
    float speed = 0.007f; //濃くなっていくスピード
    bool isGoal;

    void Start()
    {
        texture = GetComponent<RawImage>();
        red = texture.color.r;
        green = texture.color.g;
        blue = texture.color.b;

    }

    void Update()
    {

        if (isGoal)
        {
            texture.color = new Color(red, green, blue, alfa);
            alfa += speed;
            //ここでゴール画面に遷移
            SceneManager.LoadScene("goal");
        }
    }

    public void SetIsGoal()
    {
        isGoal = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapyobidasi : MonoBehaviour
{
    public GameObject[] maparray;
    int number = 0;
    int count = 2;
    int i = 0,w1=100,w2=100,w3=100;
    bool f = true;
    private Vector2 lastMapPos; //最後のマップの座標

    void Awake()
    {
        Vector3 idou = new Vector3();
        Vector3 tmp = new Vector3();
        //while (this.i != maparray.Length)
        while(this.i != 8)
        {
            if (maparray.Length != 1)
            {
                do
                {
                    f = true;
                    number = Random.Range(0, maparray.Length);
                    if (!(w1 == number || w2 == number|| w3 == number))
                    {
                        f = false;
                        if ((i % 3) == 0)
                        {
                            w1 = number;
                        }
                        else if((i%3)==1)
                        {
                            w2 = number;
                        }
                        else
                        {
                            w3 = number;
                        }
                    }
                } while (f);
            }
            tmp = GameObject.Find("1").transform.position;
            idou = new Vector3(tmp.x + 32 * (count - 1), tmp.y + 20, tmp.z);
            //q消す
            Instantiate(maparray[number], idou, Quaternion.identity);
            this.count++;
            i++;
        }
        GameObject goalObj = (GameObject)Resources.Load("Goal");
        Vector3 goalPos = new Vector3(idou.x + 32, tmp.y, tmp.z);
        Instantiate(goalObj, goalPos, Quaternion.identity);
        lastMapPos = new Vector2(idou.x+32,tmp.y); //new
    }

    void Update()
    {

    }

    public Vector2 GetLastMapPos()
    {
        return lastMapPos;
    }
}

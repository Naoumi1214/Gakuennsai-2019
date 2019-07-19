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
    // Start is called before the first frame update
    void Start()
    {
        //while (this.i != maparray.Length)
        while(this.i != 30)
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
            Vector3 tmp = GameObject.Find("1").transform.position;
            Vector3 idou = new Vector3(tmp.x + 32 * (count - 1), tmp.y + 20, tmp.z);
            Quaternion q = new Quaternion();
            q = Quaternion.identity;
            Instantiate(maparray[number], idou, Quaternion.identity);
            this.count++;
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}

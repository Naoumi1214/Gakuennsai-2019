using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapyobidasi : MonoBehaviour
{
    public GameObject[] maparray;
    int number = 0;
    int count = 2;
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        //while (this.i != maparray.Length)
        while(this.i != 30)
        {
            number = Random.Range(0, maparray.Length);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Item : MonoBehaviour
{
    Vector2 item;
    public GameObject[] Itemarray;
    int number = 0;
    void Start()
    {
        item = transform.position;
        number = Random.Range(0, 10);
        if ((0 <= number) && (number <= 4))
        {
            number = 0;
        }
        else if ((5 <= number) && (number <= 6))
        {
            number = 1;
        }
        else if ((7 == number))
        {
            number = 2;
        }
        else
        {
            number = 3;
        }
        if (number != 3)
        {
            Quaternion q = new Quaternion();
            q = Quaternion.identity;
            Debug.Log(Itemarray[number].name);
            GameObject rename = Instantiate(Itemarray[number], item, Quaternion.identity);
            rename.name = Itemarray[number].name;
        }
    }
    void Update()
    {

    }
}

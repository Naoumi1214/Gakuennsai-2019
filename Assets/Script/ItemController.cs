using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    private Dictionary<string,GameObject> ItemObject=new Dictionary<string, GameObject>();

    //連想配列にアイテムの名前とGamoObjectを格納する
    void Start()
    {
        ItemObject.Add("Muteki", (GameObject)Resources.Load("Muteki"));
    }

    //触れたアイテムを表示する
    public void SetItem(string itemName)
    {
        Debug.Log(itemName);
        Instantiate(ItemObject[itemName],transform);
    }

    public void LoseItem()
    {
        Destroy(transform.GetChild(0).gameObject);
    }
}

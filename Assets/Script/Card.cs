using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    // 카드 종류 필요

    Click click;
    Inventory inventory;
    public int type = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        click = this.gameObject.GetComponent<Click>();
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if(click.mouseState)
        {
            inventory.AddItem(type, 1);
        }
    }
}

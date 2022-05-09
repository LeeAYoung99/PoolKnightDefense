using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardImage : MonoBehaviour
{
    // 카드 종류 필요

    Click click;
    Inventory inventory;
    public int type = 0;
    Drag drag;


    // Start is called before the first frame update
    void Start()
    {
        drag = this.gameObject.GetComponent<Drag>();
        click = this.gameObject.GetComponent<Click>();
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (drag.isDragged)
        {
            if (drag.MouseOverObject.tag == "Tower")
            {
                if (type == 1)
                {
                    drag.MouseOverObject.GetComponent<Tower>().MinusTimeCycle(0.4f);
                }
                else if (type == 2)
                {
                  //  drag.MouseOverObject.GetComponent<Tower>().MinusTimeCycle(0.4f);
                }
                else if (type == 3)
                {
                   // drag.MouseOverObject.GetComponent<Tower>().MinusTimeCycle(0.4f);
                }
            }
            drag.isDragged = false;
        }
    }
}

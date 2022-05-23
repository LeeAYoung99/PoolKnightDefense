using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardImage : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    // 카드 종류 필요

    Click click;
    Inventory inventory;
    public int type = 0;
    Drag drag;

    [SerializeField]
    GameObject EffectUI;


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
            if (inventory.inven[type] <= 0)
            {
            }
            else
            {
                GameObject obj = drag.MouseOverObject;
                if (obj.tag == "Tower")
                {
                    if (type == 1)
                    {
                        obj.GetComponent<Tower>().MinusTimeCycle(0.4f);
                    }
                    else if (type == 2)
                    {
                        obj.GetComponent<Tower>().multipleDamage = 2.3f;
                    }
                    else if (type == 3)
                    {
                        Transform range = obj.GetComponent<Tower>().transform.Find("TowerRange");
                        range.gameObject.GetComponent<CapsuleCollider>().radius += 0.2f;
                    }
                    inventory.inven[type]--;
                }
            }
            drag.isDragged = false;
        }
    }

    public void OnPointerEnter(PointerEventData EVENTDATA)
    {
        if (!EffectUI) return;

        if (drag.isDragging == false)
        {
            EffectUI.SetActive(true);
        }
        else
        {
            EffectUI.SetActive(false);
        }
    }

    public void OnPointerDown(PointerEventData EVENTDATA)
    {
        EffectUI.SetActive(false);
    }

    public void OnPointerExit(PointerEventData EVENTDATA)
    {
        EffectUI.SetActive(false);
    }


}

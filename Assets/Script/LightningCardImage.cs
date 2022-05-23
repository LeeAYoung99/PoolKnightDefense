using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LightningCardImage : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    // 카드 종류 필요

    Inventory inventory;

    [SerializeField]
    GameObject EffectUI;

    LightningCard lCard;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData EVENTDATA)
    {
        if (!EffectUI) return;

        EffectUI.SetActive(true);
    }

    public void OnPointerDown(PointerEventData EVENTDATA)
    {
        EffectUI.SetActive(false);
    }

    public void OnPointerExit(PointerEventData EVENTDATA)
    {
        EffectUI.SetActive(false);
    }

    public void LightningButton()
    {
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
        lCard = GameObject.Find("LightningCardEvent").GetComponent<LightningCard>();

        if (inventory.inven[4] <= 0)
        {
        }
        else
        {
            inventory.inven[4]--;
            lCard.SetState(LightningCard.States.DARKNING);
        }
    }
}

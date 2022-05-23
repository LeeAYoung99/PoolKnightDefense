using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Dictionary<int, string> itemcode = new Dictionary<int, string>();
    public Dictionary<int, int> inven = new Dictionary<int, int>(); //아이템, 개수

    [SerializeField]
    Text firstTxt;
    [SerializeField]
    Text secondTxt;
    [SerializeField]
    Text thirdTxt;
    [SerializeField]
    Text fourthTxt;

    void Awake()
    {
        itemcode.Add(1, "crown");
        itemcode.Add(2, "sword");
        itemcode.Add(3, "lion");
        itemcode.Add(4, "lightning");

        inven.Add(1, 0);
        inven.Add(2, 0);
        inven.Add(3, 0);
        inven.Add(4, 1);

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Inven();
    }

    void Inven()
    {
        firstTxt.text = inven[1].ToString();
        secondTxt.text = inven[2].ToString();
        thirdTxt.text = inven[3].ToString();
        fourthTxt.text = inven[4].ToString();
    }

    public void AddItem(int item, int count)
    {
        if (!itemcode.ContainsKey(item))
        {
            return;
        }


        if(inven.ContainsKey(item))
        {
            inven[item] += count;
            
        }
        else
        {
            inven.Add(item, count);
        }
    }
}

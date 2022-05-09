using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Dictionary<int, string> itemcode = new Dictionary<int, string>();
    Dictionary<int, int> inven = new Dictionary<int, int>(); //아이템, 개수

    [SerializeField]
    Text firstTxt;
    [SerializeField]
    Text secondTxt;
    [SerializeField]
    Text thirdTxt;

    void Awake()
    {
        itemcode.Add(1, "crown");
        itemcode.Add(2, "sword");
        itemcode.Add(3, "lion");

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
        if (inven.Count >= 1)
        {
            firstTxt.text = inven[1].ToString();
        }
        else if (inven.Count >= 2)
        {
            secondTxt.text = inven[2].ToString();
        }
        else if (inven.Count >= 3)
        {
            thirdTxt.text = inven[3].ToString();
        }
    }

    public void AddItem(int item, int count)
    {
        if (!itemcode.ContainsKey(item)) return;

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

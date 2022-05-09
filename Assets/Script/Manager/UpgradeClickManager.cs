using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeClickManager : MonoBehaviour
{
    public GameObject ClickedTower;
    ClickManager clickManager;
    
    // Start is called before the first frame update
    void Start()
    {
        clickManager = GameObject.Find("ClickManager").GetComponent<ClickManager>();
        ClickedTower = null;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject _obj = clickManager.GetLastClickedObject();
        if (_obj)
        {
            if (_obj.tag == "Tower")
            {
                ClickedTower = _obj;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public GameObject ClickUI;
    public GameObject WarningUI;
    public GameObject UpgradeUI;

    public bool isCreateTowerUIOn = false;
    public bool isUpgradeTowerUIOn = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateUpgradeTowerUI()
    {
        if (!isUpgradeTowerUIOn)
        {
            GameObject _UpgradeUI;
            _UpgradeUI = Instantiate(UpgradeUI, new Vector2(Camera.main.pixelWidth * 0.5f, Camera.main.pixelHeight * 0.5f), Quaternion.identity);
            _UpgradeUI.transform.SetParent(GameObject.Find("Canvas").transform);
            isUpgradeTowerUIOn = true;
        }
    }

    public void CreateTowerUI()
    {
        if(!isCreateTowerUIOn)
        {
            GameObject _ClickUI;
            _ClickUI = Instantiate(ClickUI, new Vector2(Camera.main.pixelWidth * 0.5f, Camera.main.pixelHeight * 0.5f), Quaternion.identity);
            _ClickUI.transform.SetParent(GameObject.Find("Canvas").transform);
            isCreateTowerUIOn = true;
        }
    }

    public void CreateWarningUI()
    {
        GameObject _WarningUI;
        _WarningUI = Instantiate(WarningUI, new Vector2(Camera.main.pixelWidth * 0.5f, Camera.main.pixelHeight * 0.5f), Quaternion.identity);
        _WarningUI.transform.SetParent(GameObject.Find("Canvas").transform);
    }
}

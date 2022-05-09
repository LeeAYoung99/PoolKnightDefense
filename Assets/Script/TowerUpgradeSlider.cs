using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerUpgradeSlider : MonoBehaviour
{
    GameObject target;
    public Slider thisSlider;
    float maxTime;
    float currentTime;
    int index = 0;

    Camera _camera;

    Tower tower;

    void Start()
    {
        tower = target.GetComponent<Tower>();
        currentTime = 0;
        maxTime = tower.maxUpgradeTime;
        _camera = Camera.main;
    }

    void Update()
    {
        if (!target) return;

        currentTime = tower.upgradeTime;
        maxTime = tower.maxUpgradeTime;

        this.gameObject.transform.position = _camera.WorldToScreenPoint(tower.transform.position) + new Vector3(0, -20.0f, 0);

        if (tower.GetState() != Tower.States.UPGRADING || target == null)
        {
            Destroy(this.gameObject);
        }

        thisSlider.value = (float)currentTime / maxTime;
    }

    public void SetTarget(GameObject obj)
    {
        target = obj;
    }

    public void SetIndex(int i)
    {
        index = i;
    }
}

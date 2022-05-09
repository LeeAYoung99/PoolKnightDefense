using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHP : MonoBehaviour
{
    GameObject target;
    public Slider hpBarSlider;
    float maxHp;
    float currentHp;
    int index = 0;

    Camera _camera;

    Enemy enemy;

    void Start()
    {
        enemy = target.GetComponent<Enemy>();
        currentHp = 0;
        maxHp = enemy.maxHealth;
        _camera = Camera.main;
    }

    void Update()
    {
        if (target == null || enemy == null)
        {
            Destroy(this.gameObject);
        }
        /*
        if (enemy == null)
        {
            enemy = target.GetComponent<Enemy>();
        }*/

        currentHp = enemy.health;
        maxHp = enemy.maxHealth;

        if (enemy) this.gameObject.transform.position = _camera.WorldToScreenPoint(enemy.transform.position) + new Vector3(0, 70.0f, 0);

        if (currentHp <= 0)
        {
            Destroy(this.gameObject);
        }

        //transform.position = target.position + new Vector3(0, 0, 0);
        hpBarSlider.value = (float)currentHp / maxHp;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHP : MonoBehaviour
{
    GameObject target;
    public Slider hpbar;
    int maxHp;
    int currentHp;

    Enemy enemy;

    void Start()
    {
        enemy = target.GetComponent<Enemy>();
        currentHp = 0;
        maxHp = enemy.maxHealth;
    }

    void Update()
    {
        currentHp = enemy.health;
        maxHp = enemy.maxHealth;

        //transform.position = target.position + new Vector3(0, 0, 0);
        hpbar.value = (float)currentHp / maxHp;
    }

    public void SetTarget(GameObject obj)
    {
        target = obj;
    }
}

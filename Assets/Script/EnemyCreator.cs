using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    int enemyCount = 3;
    float timeCycle = 3.0f;
    private float time = 0;

    public GameObject hpUI;
    public List<GameObject> enemyList;

    // Start is called before the first frame update
    void Start()
    {
       // hpbar = GameObject.Find("HPBar").GetComponent<HPBar>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (enemyCount > 0 && time > timeCycle)
        {
            EnemyCreate();
            enemyCount--;
            time = 0;
        }
    }

    void EnemyCreate()
    {
        GameObject _enemy;
        _enemy = Instantiate(enemyList[0], this.gameObject.transform.position, Quaternion.identity);

     //   int index = hpbar.obj.FindIndex(a => a == _enemy.transform);

        GameObject _hpui;
        _hpui = Instantiate(hpUI, new Vector3(0, 0, 0), Quaternion.identity);
        _hpui.transform.SetParent(GameObject.Find("Canvas").transform);
        //hpbar.hp_bar.Add(_hpui);
      //  _hpui.GetComponent<MonsterHP>().SetIndex(index);
        if(_hpui.GetComponent<MonsterHP>())
        {
            Debug.Log("settarget");
            _hpui.GetComponent<MonsterHP>().SetTarget(_enemy);
        }
    }
}

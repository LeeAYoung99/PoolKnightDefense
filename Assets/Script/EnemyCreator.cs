using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    int enemyCount = 30;
    float timeCycle = 5.0f;
    private float time = 5.0f;

    public GameObject hpUI;
    public List<GameObject> enemyList;
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.gameStart)
        {
            time += Time.deltaTime;
            if (enemyCount > 0 && time >= timeCycle)
            {
                EnemyCreate();
                enemyCount--;
                time = 0;
            }
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
        if(_hpui.GetComponent<MonsterHP>())
        {
            _hpui.GetComponent<MonsterHP>().SetTarget(_enemy);
        }
    }
}

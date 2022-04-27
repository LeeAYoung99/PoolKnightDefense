using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject target = null; //나중에 public 빼셈
    float timeCycle = 2.0f;
    private float time = 0;
    private bool findTarget = true;

    private float upgradeTime = 0;
    float maxUpgradeTime = 5.0f;

    public GameObject bullet;
    Bullet bulletScript;
    Cannon cannonScript;

    TowerManager towerManager;
    TowerManager.TowerType tType;
    UIManager uiManager;

    //
    GameObject slowObj;

    public enum States
    {
        ATTACK_COOLTIME,
        ATTACK,
        UPGRADING,
        IDLE
    }

    States currentState;

    // Start is called before the first frame update
    void Start()
    {
        tType = TowerManager.TowerType.BASIC;
        towerManager = GameObject.Find("TowerManager").GetComponent<TowerManager>();
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        time = timeCycle;
        currentState = States.ATTACK;

        slowObj = null;
    }

    // Update is called once per frame
    void Update()
    {
        //공격 주기 일때
        //target 이 null이면 range안에 있는 적을 찾고
        //target 이 존재하면 target을 우선적으로 공격한다.

        switch (currentState)
        {
            case States.IDLE:
                Idle();
                break;
            case States.ATTACK_COOLTIME:
                AttackCooltime();
                break;
            case States.UPGRADING:
                Upgrading();
                break;
            case States.ATTACK:
                Attack();
                break;
        }

        if (IsClicked())
        {
            uiManager.CreateUpgradeTowerUI();
        }

    }

    void Idle()
    {
        if(tType == TowerManager.TowerType.SLOW)
        {
            if(!slowObj)
            {
                slowObj = ObjectPoolManager.Instance.slowPool.Pop();
                slowObj.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
                slowObj.GetComponent<Slow>().SetState(Slow.State.IDLE);

            }
        }
    }

    void AttackCooltime()
    {
        time += Time.deltaTime;
        if (time >= timeCycle)
        {
            time = 0;
            currentState = States.ATTACK;

            return;
        }
    }

    void Attack()
    {
        if (tType == TowerManager.TowerType.SLOW)
        {
            currentState = States.IDLE;
            return;
        }

        if (target == null)
        {
            findTarget = true;
        }
        else
        {
            Shoot();
        }
    }


    void Shoot()
    {
        switch (tType)
        {
            case TowerManager.TowerType.BASIC:
                GameObject _bullet;

                _bullet = ObjectPoolManager.Instance.bulletPool.Pop();
                _bullet.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.7f, gameObject.transform.position.z);
                _bullet.GetComponent<Bullet>().SetState(Bullet.State.IDLE);
                bulletScript = _bullet.GetComponent<Bullet>();
                bulletScript.Target = target.transform;

                currentState = States.ATTACK_COOLTIME;

                break;

            case TowerManager.TowerType.CANNON:
                GameObject _cannon;

                _cannon = ObjectPoolManager.Instance.cannonPool.Pop();
                _cannon.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.7f, gameObject.transform.position.z);
                _cannon.GetComponent<Cannon>().SetState(Cannon.State.IDLE);
                cannonScript = _cannon.GetComponent<Cannon>();
                cannonScript.Target = target.transform;

                currentState = States.ATTACK_COOLTIME;

                break;
        }

    }

    void Upgrading()
    {
        upgradeTime += Time.deltaTime;
        if (upgradeTime >= maxUpgradeTime)
        {
            currentState = States.ATTACK;
            upgradeTime = 0;
        }
    }

    bool IsClicked()
    {
        return this.GetComponent<Click>().mouseState;
    }

    public void RequestUpgrade(TowerManager.TowerType t)
    {
        currentState = States.UPGRADING;
        tType = t;
    }

    public void RequestUpgrade(string s)
    {
        Debug.Log("REQUEST");
        currentState = States.UPGRADING;
        if(s == "BASIC")
        {
            tType = TowerManager.TowerType.BASIC;
        }
        else if (s == "SLOW")
        {
            tType = TowerManager.TowerType.SLOW;
        }
        else if (s == "CANNON")
        {
            tType = TowerManager.TowerType.CANNON;
        }
        else if (s == "FIRE")
        {
            tType = TowerManager.TowerType.FIRE;
        }
    }

    public void DeleteUpgradeTowerUI()
    {
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        uiManager.isUpgradeTowerUIOn = false;
        Destroy(GameObject.Find("Canvas").transform.Find("UI_UpgradeTower(Clone)").gameObject);
    }


    //public
    public void ChangeTarget(GameObject obj)
    {
        target = obj;
    }
     
    public bool IsFindTarget()
    {
        return findTarget;
    }

    public void ChangeFindTarget(bool t)
    {
        findTarget = t;
    }

    public bool IsMeTarget(GameObject obj)
    {
        return (obj == target);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject target = null; //���߿� public ����
    float timeCycle = 2.0f;
    private float time = 0;
    private bool findTarget = true;

    public float upgradeTime = 0;
    public float maxUpgradeTime = 5.0f;

    public GameObject UpgradeUI;

    //public GameObject bullet;
    Bullet bulletScript;
    Cannon cannonScript;

    TowerManager towerManager;
    TowerManager.TowerType tType;
    UIManager uiManager;

    //
    GameObject slowObj;
    GameObject poisonObj;

    //자식오브젝트
    GameObject Hat;
    GameObject Shooter;

    public enum States
    {
        ATTACK_COOLTIME,
        ATTACK,
        UPGRADING,
        CARD_UPGRADING,
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

        Shooter = transform.Find("Shooter").gameObject;
        Hat = transform.Find("Hat").gameObject;

        slowObj = null;
        poisonObj = null;
    }

    // Update is called once per frame
    void Update()
    {
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
            case States.CARD_UPGRADING:
                CardUpgrading();
                break;
            case States.ATTACK:
                Attack();
                break;
        }

        Appearance();

        if (IsClicked() && tType == TowerManager.TowerType.BASIC)
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
        else if (tType == TowerManager.TowerType.POISON)
        {
            if (!poisonObj)
            {
                poisonObj = ObjectPoolManager.Instance.poisonPool.Pop();
                poisonObj.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.2f, gameObject.transform.position.z);
                poisonObj.GetComponent<Poison>().SetState(Poison.State.IDLE);

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
        if (tType == TowerManager.TowerType.SLOW || tType == TowerManager.TowerType.POISON)
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

    void Appearance()
    {
        switch(tType)
        {
            case TowerManager.TowerType.BASIC:
                break;
            case TowerManager.TowerType.CANNON:
                Shooter.gameObject.SetActive(true);
                break;
            case TowerManager.TowerType.SLOW:
                break;
            case TowerManager.TowerType.POISON:
                Hat.gameObject.SetActive(true);
                break;


        }
    }

    void CardUpgrading()
    {

    }

    bool IsClicked()
    {
        return this.GetComponent<Click>().mouseState;
    }

    public void ChangeState(States s)
    {
        currentState = s;
    }

    public void ChangeTowerType(TowerManager.TowerType t)
    {
        tType = t;
    }

    public void RequestUpgrade(string s)
    {
        UpgradeClickManager upgradeClickManager;
        upgradeClickManager = GameObject.Find("UpgradeClickManager").GetComponent<UpgradeClickManager>();

        Tower tower;
        tower = upgradeClickManager.ClickedTower.GetComponent<Tower>();
        if (!tower) return;

        tower.ChangeState(States.UPGRADING);
        if(s == "BASIC")
        {
            tower.ChangeTowerType(TowerManager.TowerType.BASIC);
        }
        else if (s == "SLOW")
        {
            tower.ChangeTowerType(TowerManager.TowerType.SLOW);
        }
        else if (s == "CANNON")
        {
            tower.ChangeTowerType(TowerManager.TowerType.CANNON);
        }
        else if (s == "POISON")
        {
            tower.ChangeTowerType(TowerManager.TowerType.POISON);
        }

        DeleteUpgradeTowerUI();

        GameObject _upgradeSlider;
        _upgradeSlider = Instantiate(UpgradeUI, new Vector3(0, 0, 0), Quaternion.identity);
        _upgradeSlider.transform.SetParent(GameObject.Find("Canvas").transform);
        if (_upgradeSlider.GetComponent<TowerUpgradeSlider>())
        {
            _upgradeSlider.GetComponent<TowerUpgradeSlider>().SetTarget(tower.gameObject);
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

    public States GetState()
    {
        return currentState;
    }

    public void MinusTimeCycle(float f) //CardImage.cs
    {
        timeCycle -= f;
    }
}

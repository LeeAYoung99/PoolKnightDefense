using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRange : MonoBehaviour
{
    public GameObject target = null; //���߿� public ����
    float timeCycle = 2.0f;
    private float time = 0;
    private bool findTarget = true;

    public GameObject bullet;
    Bullet bulletScript;

    public enum States
    {
        ATTACK_COOLTIME,
        ATTACK,
        IDLE
    }

    States currentState;

    // Start is called before the first frame update
    void Start()
    {
        time = timeCycle;
        currentState = States.ATTACK;
    }

    // Update is called once per frame
    void Update()
    {
        //���� �ֱ� �϶�
        //target �� null�̸� range�ȿ� �ִ� ���� ã��
        //target �� �����ϸ� target�� �켱������ �����Ѵ�.

        switch (currentState)
        {
            case States.IDLE:
                Idle();
                break;
            case States.ATTACK_COOLTIME:
                AttackCooltime();
                break;
            case States.ATTACK:
                Attack();
                break;
        }

    }

    void Idle()
    {

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
        if (target == null)
        {
            findTarget = true;
        }
        else
        {
            Shoot();
            currentState = States.ATTACK_COOLTIME;
        }
    }


    void Shoot()
    {
        GameObject _bullet;
        _bullet = Instantiate(bullet, 
            new Vector3(gameObject.transform.position.x, gameObject.transform.position.y+ 0.7f, gameObject.transform.position.z) //+f ��ŭ ������ ��
            , Quaternion.identity);
        _bullet.transform.parent = gameObject.transform;
        bulletScript = _bullet.GetComponent<Bullet>();
        bulletScript.Target = target.transform;
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Enemy") && findTarget)
        {
            //Debug.Log("Enemy Spotted");
            target = col.gameObject;
            findTarget = false;
        }
    }

    public void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Enemy") && !findTarget)
        {
            target = col.gameObject;
            findTarget = true;
            target = null;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : Poolable
{

    public float firingAngle = 45.0f;
    public float gravity = 9.8f;
    public Transform Target;
    private Vector3 Dest;
    bool isDest;
    SoundManager soundManager;

    private Transform myTransform;

    float elapse_time = 0;


    public enum State
    {
        IDLE,
        MOVE
    }

    State state;

    void Start()
    {
        state = State.IDLE;
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    void Update()
    {

        if (state == State.IDLE)
        {
            Idle();
        }
        else if (state == State.MOVE)
        {
            Move();
        }
    }

    void Idle()
    {
        myTransform = this.gameObject.transform;
        //��ź������ �ʹݿ� ��ź�� ���������� �����ϱ�����
        //��ź�� ȸ���� ĳ������ġ���� ��ź�� ��ġ�� �������� �����ϴ�
        transform.rotation = Quaternion.LookRotation(transform.position - transform.parent.position);
        state = State.MOVE;
        isDest = false;
        elapse_time = 0;
    }

    void Move()
    {
        DiffusionMissile_Move_Operation();
    }

    public void SetState(State s)
    {
        state = s;
    }

    void DiffusionMissile_Move_Operation()
    {
        if (Target == null)
        {
            Push();
            return;
        } 

        if (!isDest)
        {
            isDest=true;
            Dest = Target.position;
        }

        // ��ü�� ������ ��ġ�� �߻�ü�� �̵���Ű�� �ʿ��� ��� �������� �߰��մϴ�.
        this.gameObject.transform.position = myTransform.position + new Vector3(0, 0.0f, 0);

        // ��ǥ�������� �Ÿ��� ����մϴ�.
        float target_Distance = Vector3.Distance(this.gameObject.transform.position, Dest);

        // ������ �������� ��ü�� ��ǥ���� ������ �� �ʿ��� �ӵ��� ����մϴ�.
        float projectile_Velocity = target_Distance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / gravity);

        // �ӵ��� XY ���� ��Ҹ� �����մϴ�.
        float Vx = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
        float Vy = Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);

        // ���� �ð��� ����մϴ�.
        // float flightDuration = target_Distance;
        float flightDuration = target_Distance + 1.0f;

        // ��ǥ���� ���ϵ��� �߻�ü�� ȸ����ŵ�ϴ�.
        this.gameObject.transform.rotation = Quaternion.LookRotation(Dest - this.gameObject.transform.position);

        //float elapse_time = 0;

        if (elapse_time < flightDuration)
        {
            this.gameObject.transform.Translate(0, (Vy - (gravity * elapse_time)) * Time.deltaTime, Vx * Time.deltaTime);

            elapse_time += Time.deltaTime;
        }

    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Plane"))
        {
            soundManager.BopPlay();

            this.Push();

            GameObject _cannonEffect;

            _cannonEffect = ObjectPoolManager.Instance.cannonEffectPool.Pop();
            _cannonEffect.transform.position = this.transform.position;
            _cannonEffect.GetComponent<CannonEffect>().SetState(CannonEffect.State.IDLE);
        }
    }

    //https://allisnothing.tistory.com/23

}

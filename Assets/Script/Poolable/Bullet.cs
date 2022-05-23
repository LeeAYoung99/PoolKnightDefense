using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Poolable
{
    private float dis;
    private float speed;
    private float waitTime;
    public Transform Target;

    public Damage damage = new Damage(1.0f, 1.0f);

    public enum State
    {
        IDLE,
        MOVE
    }

    State state;
     
    void Start()
    {
        state = State.IDLE;
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
        if(Target) dis = Vector3.Distance(gameObject.transform.position, Target.position);

        //��ź������ �ʹݿ� ��ź�� ���������� �����ϱ�����
        //��ź�� ȸ���� ĳ������ġ���� ��ź�� ��ġ�� �������� �����ϴ�
        transform.rotation = Quaternion.LookRotation(transform.position - transform.parent.position);
        state = State.MOVE;
        waitTime = 0;
        speed = 0;

        damage.SetDamage(1.0f);
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



        waitTime += Time.deltaTime;

        if (waitTime < 0.5f)
        {
            speed = Time.deltaTime;
            transform.Translate(gameObject.transform.forward * speed * 4.0f, Space.World);
        }
        else
        {
            // 0.5�� ���� Ÿ�ٹ������� lerp��ġ�̵� �մϴ�

            speed += Time.deltaTime;
            float t = speed / dis;

            gameObject.transform.position = Vector3.LerpUnclamped(gameObject.transform.position, Target.position, t);

        }

        // �������Ӹ��� Ÿ�ٹ������� ��ź�� �������ٲߴϴ�
        //Ÿ����ġ - ��ź��ġ = ��ź�� Ÿ�����׼��� ����

        Vector3 directionVec = Target.position - gameObject.transform.position;
        Quaternion qua = Quaternion.LookRotation(directionVec);
        gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, qua, Time.deltaTime * 5f);

    }

    public void MultiplyDamage(float f)
    {
        damage.MultiplyDamage(f);
    }

}

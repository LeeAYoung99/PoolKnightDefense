using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float dis;
    private float speed;
    private float waitTime;
    public Transform Target;

 
    void Start()
    {
        dis = Vector3.Distance(gameObject.transform.position, Target.position);

        //��ź������ �ʹݿ� ��ź�� ���������� �����ϱ�����
        //��ź�� ȸ���� ĳ������ġ���� ��ź�� ��ġ�� �������� �����ϴ�
        transform.rotation = Quaternion.LookRotation(transform.position - transform.parent.position);

    }

    void Update()
    {
        DiffusionMissile_Move_Operation();
    }

    void DiffusionMissile_Move_Operation()
    {
        if (Target == null) return;


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

}

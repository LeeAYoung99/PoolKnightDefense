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
        //포탄생성후 초반에 포탄이 벌어지듯이 연출하기위해
        //포탄의 회전을 캐릭터위치에서 포탄의 위치의 방향으로 놓습니다
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

        // 물체를 던지는 위치로 발사체를 이동시키고 필요한 경우 오프셋을 추가합니다.
        this.gameObject.transform.position = myTransform.position + new Vector3(0, 0.0f, 0);

        // 목표물까지의 거리를 계산합니다.
        float target_Distance = Vector3.Distance(this.gameObject.transform.position, Dest);

        // 지정된 각도에서 물체를 목표물에 던지는 데 필요한 속도를 계산합니다.
        float projectile_Velocity = target_Distance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / gravity);

        // 속도의 XY 구성 요소를 추출합니다.
        float Vx = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
        float Vy = Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);

        // 비행 시간을 계산합니다.
        // float flightDuration = target_Distance;
        float flightDuration = target_Distance + 1.0f;

        // 목표물을 향하도록 발사체를 회전시킵니다.
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

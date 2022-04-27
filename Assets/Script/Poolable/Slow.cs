using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow : Poolable
{
    private float speed = 0.6f;

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
        state = State.MOVE;
    }

    void Move()
    {
    }

    public void SetState(State s)
    {
        state = s;
    }

    public void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("Enemy"))
        {
            col.gameObject.GetComponent<EnemyWalking>().SetSpeed(speed);
        }
    }

    public void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Enemy")) 
        {
            col.gameObject.GetComponent<EnemyWalking>().ResetSpeed();
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : Poolable
{
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
            col.gameObject.GetComponent<Enemy>().isPoison = true;
            col.gameObject.GetComponent<Enemy>().InitPoisonTime();
        }
    }

    public void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Enemy"))
        {
        }
    }


}

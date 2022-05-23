using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonEffect : Poolable
{
    float time = 0;
    public Damage damage = new Damage(3.0f, 1.0f);

    public enum State
    {
        IDLE,
        MOVE
    }

    State state;

    // Start is called before the first frame update
    void Start()
    {
        state = State.IDLE;
    }

    public void SetState(State s)
    {
        state = s;
    }

    // Update is called once per frame
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
        time = 0;
        state = State.MOVE;
        this.gameObject.GetComponent<ParticleSystem>().Stop();
        this.gameObject.GetComponent<ParticleSystem>().Play();
        this.gameObject.GetComponent<CapsuleCollider>().enabled = true;
        damage.SetDamage(3.0f);
    }

    void Move()
    {
        time += Time.deltaTime;

        if(time >= 0.3f)
        {
            this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
        }

        if (time >= 1.2f)
        {
            this.Push();
        }
    }
}

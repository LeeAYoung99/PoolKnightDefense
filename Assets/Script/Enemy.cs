using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 20.0f;
    public float maxHealth = 20.0f;
    Rigidbody rb;

    int index = 0;

    float poisonTime = 1.0f;

    public bool isPoison = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GetPoisoned();

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void OnTriggerEnter(Collider col)
    {
        
        if (col.CompareTag("Bullet"))
        {
            if(col.GetComponent<Bullet>()) col.GetComponent<Bullet>().Push();
           // Destroy(col.gameObject);
            if (health >= 0) health--;
        }
        else if (col.CompareTag("CannonSplash"))
        {
            if (health >= 0) health -= 3 ;

            Vector3 Pos = this.gameObject.transform.position - col.transform.position;
            rb.AddForce(Pos * 2.0f, ForceMode.Impulse);
        }
    }

    public void SetIndex(int i)
    {
        index = i;
    }

    void GetPoisoned()
    {
        if (poisonTime <= 0)
        {
            isPoison = false;
        }

        if (isPoison)
        {
            poisonTime -= Time.deltaTime;
            health -= Time.deltaTime * 3.2f;
            return;
        }
        else
        {
            InitPoisonTime();
        }
    }

    public void InitPoisonTime()
    {
        poisonTime = 1.0f;
    }

}

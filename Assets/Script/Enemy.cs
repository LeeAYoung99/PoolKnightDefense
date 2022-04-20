using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 20;
    public int maxHealth = 20;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(this);
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
    }
}

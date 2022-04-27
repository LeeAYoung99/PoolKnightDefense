using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 20;
    public int maxHealth = 20;

    int index = 0;

    // Start is called before the first frame update
    void Start()
    {
      //  hpBar = GameObject.Find("HPBar").GetComponent<HPBar>();
    }

    // Update is called once per frame
    void Update()
    {
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
        }
    }

    public void SetIndex(int i)
    {
        index = i;
    }

}

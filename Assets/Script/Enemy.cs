using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 10.0f;
    public float maxHealth = 10.0f;
    Rigidbody rb;

    int index = 0;

    float poisonTime = 1.0f;

    public bool isPoison = false;

    [SerializeField]
    GameObject Lion;
    [SerializeField]
    GameObject Sword;
    [SerializeField]
    GameObject Crown;

    MoneyManager moneyManager;

    // Start is called before the first frame update
    void Start()
    {
        moneyManager = GameObject.Find("MoneyManager").GetComponent<MoneyManager>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GetPoisoned();

        if (health <= 0)
        {
            RandomItemDrop();
            Destroy(this.gameObject);
            moneyManager.gold += 20;
        }
    }

    public void OnTriggerEnter(Collider col)
    {
        
        if (col.CompareTag("Bullet"))
        {
            if (col.GetComponent<Bullet>())
            {
                col.GetComponent<Bullet>().Push();//Destroy
                if (health >= 0) health -= col.GetComponent<Bullet>().damage.GetFinalDamage();
            }
        }
        else if (col.CompareTag("CannonSplash"))
        {
            if (health >= 0) health -= col.GetComponent<CannonEffect>().damage.GetFinalDamage();

            Vector3 Pos = this.gameObject.transform.position - col.transform.position;
            rb.AddForce(Pos * 2.0f, ForceMode.Impulse);
        }
    }

    public void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("Destroy"))
        {
            health = 0;
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


    void RandomItemDrop()
    {
        int rand = Random.Range(0, 100);
        float height = 0.6f;

        if (rand >= 50)
        {

        }
        else if (rand >= 40 && rand < 50)
        {
            Vector3 pos = this.gameObject.transform.position;
            pos.y += height;
            Instantiate(Lion, pos, Quaternion.identity);
        }
        else if (rand >= 30 && rand < 40)
        {
            Vector3 pos = this.gameObject.transform.position;
            pos.y += height;
            Instantiate(Sword, pos, Quaternion.identity);
        }
        else if (rand >= 20 && rand < 30)
        {
            Vector3 pos = this.gameObject.transform.position;
            pos.y += height;
            Instantiate(Crown, pos, Quaternion.identity);
        }
    }

}

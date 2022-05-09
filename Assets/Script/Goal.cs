using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    [SerializeField]
    GameObject txt;
    int maxMonsterCount;
    int currentMonsterCount;

    // Start is called before the first frame update
    void Start()
    {
        Init(15);
    }

    // Update is called once per frame
    void Update()
    {
        Text _text = txt.GetComponent<Text>();
        _text.text = currentMonsterCount.ToString() + "/" + maxMonsterCount.ToString();
        if (currentMonsterCount >= maxMonsterCount)
        {
            Debug.Log("게임오버");
        }
    }

    public void Init(int m)
    {
        maxMonsterCount = m;
        currentMonsterCount = 0;
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Enemy"))
        {
            currentMonsterCount++;
            Destroy(col.gameObject);
        }
    }
}

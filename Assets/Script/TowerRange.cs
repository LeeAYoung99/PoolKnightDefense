using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRange : MonoBehaviour
{
    Tower tower;

    void Start()
    {
        tower = this.transform.parent.GetComponent<Tower>();
    }


    public void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("Enemy") && tower.IsFindTarget())
        {
            tower.ChangeTarget(col.gameObject);
            tower.ChangeFindTarget(false);
        }
    }

    public void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Enemy") && !tower.IsFindTarget()) //Enemy �� �����µ� Ÿ���� Ÿ���� �������ְ�
        {
            if(tower.IsMeTarget(col.gameObject)) //���� ���� ������ ������ Ÿ���� �����
            {
                tower.ChangeFindTarget(true);
                tower.ChangeTarget(null);
            }

        }
    }




}

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
        if (col.CompareTag("Enemy") && !tower.IsFindTarget()) //Enemy 가 나가는데 타워가 타겟이 정해져있고
        {
            if(tower.IsMeTarget(col.gameObject)) //지금 범위 밖으로 나가는 타겟이 나라면
            {
                tower.ChangeFindTarget(true);
                tower.ChangeTarget(null);
            }

        }
    }




}

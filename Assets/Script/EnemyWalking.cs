using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyWalking : MonoBehaviour
{
	Animator animator;
	NavMeshAgent nav;
	GameObject destTarget;

	void Start()
	{
		animator = GetComponent<Animator>();
		nav = GetComponent<NavMeshAgent>();

		destTarget = GameObject.Find("Wall");
		nav.SetDestination(destTarget.transform.position);
	}

	void Update()
	{
	//	nav.SetDestination(new Vector3(0, 0, 0));
	}

}
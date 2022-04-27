using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyWalking : MonoBehaviour
{
	Animator animator;
	NavMeshAgent nav;
	GameObject destTarget;

	float basicSpeed = 0.4f;
	float mySpeed;

	void Start()
	{
		animator = GetComponent<Animator>();
		nav = GetComponent<NavMeshAgent>();

		destTarget = GameObject.Find("Wall");
		nav.SetDestination(destTarget.transform.position);
		mySpeed = basicSpeed;
	}

	void Update()
	{
		nav.speed = mySpeed;
	}

	public void SetSpeed(float s)
	{
		mySpeed = s * basicSpeed;
	}

	public void ResetSpeed()
    {
		mySpeed = basicSpeed;
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Click : ClickManager
{
	private bool _mouseState;
	private GameObject target;
	private Vector3 MousePos;

	public bool mouseState = false;

	void Awake()
	{
		_mouseState = false;
	
	}

	// Update is called once per frame 
	void Update()
	{
		mouseState = _mouseState;

		//마우스가 내려갔는지?
		if (true == Input.GetMouseButtonDown(0))
		{
			//내려갔다.
			//https://sangh518.github.io/record/block-event-when-ui-click/

			if (!EventSystem.current.IsPointerOverGameObject())
			{
				//클릭 처리
				//타겟을 받아온다.
				target = GetMouseOverObject();

				//타겟이 나인가?
				if (true == target.Equals(gameObject))
				{
					//있으면 마우스 정보를 바꾼다.
					_mouseState = true;
				}
			}
			

		}
		else
        {
			_mouseState = false;
		}

	}



}
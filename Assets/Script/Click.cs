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

		//���콺�� ����������?
		if (true == Input.GetMouseButtonDown(0))
		{
			//��������.
			//https://sangh518.github.io/record/block-event-when-ui-click/

			if (!EventSystem.current.IsPointerOverGameObject())
			{
				//Ŭ�� ó��
				//Ÿ���� �޾ƿ´�.
				target = GetMouseOverObject();

				//Ÿ���� ���ΰ�?
				if (true == target.Equals(gameObject))
				{
					//������ ���콺 ������ �ٲ۴�.
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
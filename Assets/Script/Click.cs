using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Click : MonoBehaviour
{
	Camera _mainCam = null;

	private bool _mouseState;
	private GameObject target;
	private Vector3 MousePos;

	public bool mouseState = false;

	void Awake()
	{
		_mouseState = false;
		_mainCam = Camera.main;
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
				target = GetClickedObject();

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



	/// <summary>
	/// ���콺�� ������ ������Ʈ�� ������ �ɴϴ�.
	/// </summary>
	private GameObject GetClickedObject()
	{
		//�浹�� ������ ����
		RaycastHit hit;
		//ã�� ������Ʈ
		GameObject target = null;

		//���콺 ����Ʈ ��ó ��ǥ�� �����.
		Ray ray = _mainCam.ScreenPointToRay(Input.mousePosition);

		//���콺 ��ó�� ������Ʈ�� �ִ��� Ȯ��
		if (true == (Physics.Raycast(ray.origin, ray.direction * 10, out hit)))
		{
			//�ִ�!

			//������ ������Ʈ�� �����Ѵ�.
			target = hit.collider.gameObject;
		}

		return target;
	}
}
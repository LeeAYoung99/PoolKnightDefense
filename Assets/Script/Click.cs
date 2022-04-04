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

		//마우스가 내려갔는지?
		if (true == Input.GetMouseButtonDown(0))
		{
			//내려갔다.
			//https://sangh518.github.io/record/block-event-when-ui-click/

			if (!EventSystem.current.IsPointerOverGameObject())
			{
				//클릭 처리
				//타겟을 받아온다.
				target = GetClickedObject();

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



	/// <summary>
	/// 마우스가 내려간 오브젝트를 가지고 옵니다.
	/// </summary>
	private GameObject GetClickedObject()
	{
		//충돌이 감지된 영역
		RaycastHit hit;
		//찾은 오브젝트
		GameObject target = null;

		//마우스 포이트 근처 좌표를 만든다.
		Ray ray = _mainCam.ScreenPointToRay(Input.mousePosition);

		//마우스 근처에 오브젝트가 있는지 확인
		if (true == (Physics.Raycast(ray.origin, ray.direction * 10, out hit)))
		{
			//있다!

			//있으면 오브젝트를 저장한다.
			target = hit.collider.gameObject;
		}

		return target;
	}
}
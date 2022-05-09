using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickManager : MonoBehaviour
{
	Camera _mainCam = null;
	GameObject clickedTarget = null;

	// Start is called before the first frame update
	void Start()
    {
		_mainCam = Camera.main;
	}

    // Update is called once per frame
    void Update()
    {
		SetLastClickedObject();
    }


	/// <summary>
	/// 마우스가 내려간 오브젝트를 가지고 옵니다.
	/// </summary>
	public GameObject GetMouseOverObject()
	{
		//충돌이 감지된 영역
		RaycastHit hit;
		//찾은 오브젝트
		GameObject target = null;

		//마우스 포이트 근처 좌표를 만든다.
		Ray ray = _mainCam.ScreenPointToRay(Input.mousePosition);

		//마우스 근처에 오브젝트가 있는지 확인
		if (true == (Physics.Raycast(ray.origin, ray.direction * 15, out hit)))
		{
			//있다!


			//있으면 오브젝트를 저장한다.
			target = hit.collider.gameObject;
		}

		return target;
	}

	void SetLastClickedObject()
    {
		if (true == Input.GetMouseButtonDown(0))
		{
			//내려갔다.
			if (!EventSystem.current.IsPointerOverGameObject())
			{
				//클릭 처리
				//타겟을 받아온다.
				clickedTarget = GetMouseOverObject();

			}
		}
	}

	public GameObject GetLastClickedObject()
    {
		
		return clickedTarget;
	}

}

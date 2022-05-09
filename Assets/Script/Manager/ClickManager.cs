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
	/// ���콺�� ������ ������Ʈ�� ������ �ɴϴ�.
	/// </summary>
	public GameObject GetMouseOverObject()
	{
		//�浹�� ������ ����
		RaycastHit hit;
		//ã�� ������Ʈ
		GameObject target = null;

		//���콺 ����Ʈ ��ó ��ǥ�� �����.
		Ray ray = _mainCam.ScreenPointToRay(Input.mousePosition);

		//���콺 ��ó�� ������Ʈ�� �ִ��� Ȯ��
		if (true == (Physics.Raycast(ray.origin, ray.direction * 15, out hit)))
		{
			//�ִ�!


			//������ ������Ʈ�� �����Ѵ�.
			target = hit.collider.gameObject;
		}

		return target;
	}

	void SetLastClickedObject()
    {
		if (true == Input.GetMouseButtonDown(0))
		{
			//��������.
			if (!EventSystem.current.IsPointerOverGameObject())
			{
				//Ŭ�� ó��
				//Ÿ���� �޾ƿ´�.
				clickedTarget = GetMouseOverObject();

			}
		}
	}

	public GameObject GetLastClickedObject()
    {
		
		return clickedTarget;
	}

}

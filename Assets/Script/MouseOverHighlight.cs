using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverHighlight : MonoBehaviour
{

    string outlineShaderName = "Custom/OutlineShader";
    string standardShaderName = "Standard";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        MeshRenderer mr = gameObject.GetComponent<MeshRenderer>(); // �ϴ� MeshRenderer ������Ʈ�� ���

        mr.material.shader = Shader.Find(outlineShaderName); // ���̴��� ã��(�̸�����) ����
    }

    private void OnMouseExit()
    {
        MeshRenderer mr = gameObject.GetComponent<MeshRenderer>(); // �ϴ� MeshRenderer ������Ʈ�� ���

        mr.material.shader = Shader.Find(standardShaderName);  // ���̴��� ã��(�̸�����) ����
    }

}

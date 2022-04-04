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
        MeshRenderer mr = gameObject.GetComponent<MeshRenderer>(); // 일단 MeshRenderer 컴포넌트를 얻고

        mr.material.shader = Shader.Find(outlineShaderName); // 쉐이더를 찾아(이름으로) 변경
    }

    private void OnMouseExit()
    {
        MeshRenderer mr = gameObject.GetComponent<MeshRenderer>(); // 일단 MeshRenderer 컴포넌트를 얻고

        mr.material.shader = Shader.Find(standardShaderName);  // 쉐이더를 찾아(이름으로) 변경
    }

}

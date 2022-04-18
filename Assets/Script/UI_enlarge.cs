using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_enlarge : MonoBehaviour
{
    public bool isScaleMode = false;

    //This relys on rect transform.
    public int width = 200;
    public int height = 100;

    //This relys on scale.
    public float scaleWidth = 4.0f;
    public float scaleHeight = 4.0f;


    bool isActivating = true;
    float time = 0;
    const float maxTime = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isActivating)
        {
            time += Time.deltaTime;
            if(time>=maxTime)
            {
                isActivating = false;
            }

            if(!isScaleMode)
            {

                RectTransform rectTran = gameObject.GetComponent<RectTransform>();
                rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width * (time / maxTime));
                rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height * (time / maxTime));
            }
            else 
            {
                this.transform.localScale = new Vector3(scaleWidth * (time / maxTime), scaleHeight * (time / maxTime), 1.0f);
            }

        }
    }
}

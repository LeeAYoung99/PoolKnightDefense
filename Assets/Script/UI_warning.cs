using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_warning : MonoBehaviour
{
    RectTransform rt;
    float time = 0;
    public float speed = 300.0f;
    const float maxTime = 1.0f;

    private enum State
    {
        DOWN,
        STAY,
        UP
    }

    State currentState = State.DOWN;

    // Start is called before the first frame update
    void Start()
    {
        rt = this.GetComponent<RectTransform>();
        rt.anchoredPosition = new Vector2(0, Screen.height*0.5f + rt.sizeDelta.y*3.0f) ;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState == State.DOWN)
        {
            time += Time.deltaTime;
            rt.anchoredPosition = new Vector2(0, rt.anchoredPosition .y - speed * Time.deltaTime);
            if (time >= maxTime)
            {
                currentState = State.STAY;
                time = 0;
            }
        }
        else if (currentState == State.STAY)
        {
            time += Time.deltaTime;
            if (time >= maxTime)
            {
                currentState = State.UP;
                time = 0;
            }
        }
        else if (currentState == State.UP)
        {
            time += Time.deltaTime;
            rt.anchoredPosition = new Vector2(0, rt.anchoredPosition.y + speed * Time.deltaTime);
            if (time >= maxTime)
            {
                time = 0;
                Destroy(this.gameObject);
            }
        }
    }
}

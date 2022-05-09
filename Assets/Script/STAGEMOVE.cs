using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class STAGEMOVE : MonoBehaviour
{
    float deltaSpeed = 120.0f;
    float accel = 0f;
    float initialSpeed = 400.0f;
    float time = 0;

    Image image;

    public RectTransform rectTransform;
    GameManager gameManager;

    Vector2 startPos;

    void Start()
    {
        startPos = new Vector2(-742.0f, 0);
        rectTransform = this.GetComponent<RectTransform>();
        image = this.GetComponent<Image>();
        rectTransform.anchoredPosition = startPos;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        float finalSpeed = 0;
        accel += deltaSpeed * Time.deltaTime;
        finalSpeed = initialSpeed - accel;

        if (finalSpeed > 0)
        {

            rectTransform.anchoredPosition += new Vector2(finalSpeed * Time.deltaTime, 0);
        }
        else if(time < 0.6f)
        {
            time += Time.deltaTime;
        }
        else
        {
            Color color = image.color;
            if (color.a >= 0)
            {
                color.a -= (Time.deltaTime / time) * 1.5f;
                image.color = color;
            }
            else
            {
                gameManager.gameStart = true;
                Destroy(this.gameObject);
            }
        }
    }

}

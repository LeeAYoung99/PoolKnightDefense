using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Story : MonoBehaviour
{
    public List<GameObject> imageList = new List<GameObject>();
    
    int index = 0;
    float time = 0;
    float maxTime = 3.0f;

    enum States
    {
        FADEIN,
        IMAGE_ON,
        FADEOUT,
        NEXTSCENE
    }

    States state = States.FADEIN;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StoryTelling();
    }

    void StoryTelling()
    {
        switch(state)
        {
            case States.FADEIN:
                FadeIn();
                break;
            case States.IMAGE_ON:
                ImageOn();
                break;
            case States.FADEOUT:
                FadeOut();
                break;
            case States.NEXTSCENE:
                NextScene();
                break;
        }
    }

    void FadeIn()
    {
        time += Time.deltaTime;
        Color color = imageList[index].GetComponent<Image>().color;
        if (color.a < 1f)
        {
            color.a = time / maxTime;
            imageList[index].GetComponent<Image>().color = color;
        }
        else
        {
            time = 0;
            state = States.IMAGE_ON;
        }
    }

    void ImageOn()
    {
        time += Time.deltaTime;
        if (time < maxTime)
        {

        }
        else
        {
            time = 0;
            state = States.FADEOUT;
        }
    }

    void FadeOut()
    {
        time += Time.deltaTime;
        Color color = imageList[index].GetComponent<Image>().color;
        if (color.a > 0)
        {
            color.a = 1- time / maxTime;
            imageList[index].GetComponent<Image>().color = color;
        }
        else
        {
            time = 0;
            if(index >= imageList.Count - 1)
            {
                state = States.NEXTSCENE;
            }
            else
            {
                state = States.FADEIN;

                index++;
            }
        }
    }

    void NextScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningCard : MonoBehaviour
{
    public Material skyboxMat;
    float time = 0;
    float maxTime = 1.0f;
    Color skyboxC;
    Color originalSkyboxColor;

    public GameObject LightningObj;
    public GameObject DestroyObj;


    public Light dlight;
    Color lightC;
    Color originalLightColor;

    //Camera
    public float ShakeAmount;
    Vector3 initialCameraPosition;

    Camera _camera;

    public enum States
    {
        IDLE,
        DARKNING,
        LIGHTNING,
        BRIGHTENING
    }

    States state = States.IDLE;

    // Start is called before the first frame update
    void Start()
    {
        originalSkyboxColor = new Color(0.3764f, 0.3320f, 0.7148f);
        originalLightColor = new Color(0.8490566f, 0.8181654f, 0.7321111f);
        skyboxC = skyboxMat.GetColor("_SkyGradientBottom");
       _camera = Camera.main;
        Idle();

    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case States.IDLE:
                Idle();
                break;
            case States.DARKNING:
                Darkning();
                break;
            case States.LIGHTNING:
                Lightning();
                break;
            case States.BRIGHTENING:
                Brightening();
                break;
        }

    }

    void Idle()
    {
        skyboxMat.SetColor("_SkyGradientBottom", originalSkyboxColor);
        dlight.color = originalLightColor;
        initialCameraPosition = _camera.transform.position;
    }

    void Darkning()
    {
        time += Time.deltaTime;
        if (time < maxTime)
        {

            skyboxC = Color.Lerp(originalSkyboxColor, new Color(0,0,0) , time / maxTime);
            skyboxMat.SetColor("_SkyGradientBottom", skyboxC);
            RenderSettings.skybox = skyboxMat;

            dlight.color = Color.Lerp(originalLightColor, new Color(0.254183f, 0.2751412f, 0.3773585f), time / maxTime);
        }
        else
        {
            time = 0;
            state = States.LIGHTNING;
        }

    }

    void Lightning()
    {
        time += Time.deltaTime;
        if (time < maxTime)
        {
            _camera.transform.position = Random.insideUnitSphere * ShakeAmount + initialCameraPosition;
            LightningObj.SetActive(true);
            DestroyObj.SetActive(true);
        }
        else
        {
            time = 0;
            LightningObj.SetActive(false);
            DestroyObj.SetActive(false);
            _camera.transform.position = initialCameraPosition;
            state = States.BRIGHTENING;
        }
    }

    void Brightening()
    {
        time += Time.deltaTime;
        if (time < maxTime)
        {
            skyboxC = Color.Lerp(new Color(0, 0, 0), originalSkyboxColor, time / maxTime);
            skyboxMat.SetColor("_SkyGradientBottom", skyboxC);
            RenderSettings.skybox = skyboxMat;

            dlight.color = Color.Lerp(new Color(0.254183f, 0.2751412f, 0.3773585f), originalLightColor, time / maxTime);
        }
        else
        {
            time = 0;
            state = States.IDLE;
        }
    }

    public void SetState(States s)
    {
        state = s;
    }
}

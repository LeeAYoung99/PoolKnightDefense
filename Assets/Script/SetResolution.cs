using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetResolution : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep; // ȭ���� �� ������ �ϴ� �Լ�

        Screen.SetResolution(1920, 1080, true);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
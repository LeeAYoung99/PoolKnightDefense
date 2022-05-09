using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //static var

    public static int currentClickedButtonWidth = 0;
    public static int currentClickedButtonHeight = 0;

    public bool gameStart = false;
    Dictionary<int, bool> currentStageBool = new Dictionary<int, bool>();
    int currentStage = 1;

    [SerializeField]
    GameObject transparentObj;
    [SerializeField]
    GameObject StageOne;


    // Start is called before the first frame update
    void Start()
    {
        currentStageBool.Add(1, false);
    }

    // Update is called once per frame
    void Update()
    {
        switch(currentStage)
        {
            case 1:
                if (!currentStageBool[1])
                {
                    GameObject obj = Instantiate(StageOne, StageOne.transform.position, StageOne.transform.rotation);
                    obj.transform.SetParent(GameObject.Find("Canvas").transform);
                    currentStageBool[1] = true;
                }
                else
                {
                }
                break;
        }
    }
}

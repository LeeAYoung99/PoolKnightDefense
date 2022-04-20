using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FieldCube : MonoBehaviour
{
    int width = 0;
    int height = 0;

    Click click;
    UIManager uiManager;
    GameField gameField;

    public GameObject Tower;

    BFS bfs;

    //private Vector2 ScreenCentor;

    // Start is called before the first frame update
    void Start()
    {
        click = gameObject.GetComponent<Click>();
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        gameField = GameObject.Find("GameField").GetComponent<GameField>();
    }

    // Update is called once per frame
    void Update()
    {
        if(click.mouseState == true)
        {
           
            GameManager.currentClickedButtonWidth = width;
            GameManager.currentClickedButtonHeight = height;

            uiManager.CreateTowerUI();
        }
    }

    public void SetWidthHeight(int w, int h)
    {
        width = w;
        height = h;
    }

    public void CreateTower()
    {
        gameField = GameObject.Find("GameField").GetComponent<GameField>();
        bfs = GameObject.Find("BFS").GetComponent<BFS>();

        if (gameField.GetTowerType(GameManager.currentClickedButtonWidth, GameManager.currentClickedButtonHeight) == GameField.TowerType.NONE)
        {
            gameField.ChangeTowerType(GameManager.currentClickedButtonWidth, GameManager.currentClickedButtonHeight, GameField.TowerType.BASIC_TYPE);


            if(bfs.BFS_FindPath()==false)
            {
                gameField.ChangeTowerType(GameManager.currentClickedButtonWidth, GameManager.currentClickedButtonHeight, GameField.TowerType.NONE);
                uiManager.CreateWarningUI();

            }
            else
            {
                GameObject _tower;
                _tower = Instantiate(Tower,
                    new Vector3(GameManager.currentClickedButtonWidth * 1.0f, gameObject.transform.position.y + 0.1f, GameManager.currentClickedButtonHeight * 1.0f)
                    , Quaternion.identity);
            }

          
        }

        DeleteCreateTowerUI();
    }

    public void DeleteCreateTowerUI()
    {
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        uiManager.isCreateTowerUIOn = false;
        Destroy(GameObject.Find("Canvas").transform.Find("UI_BuildTower(Clone)").gameObject);
    }
}

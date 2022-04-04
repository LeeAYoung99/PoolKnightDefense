using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameField : MonoBehaviour
{
    public int Width = 1;
    public int Height = 1;

    public GameObject target;

    FieldCube fieldCubeScript;

    public enum TowerType
    {
        NONE,
        BASIC_TYPE
    }

    struct Field
    {
        public GameObject fieldTarget;
        public int fieldWidth;
        public int fieldHeight;
        public TowerType towerType;
    }

    List<Field> fieldArray = new List<Field>();


    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < Width; i++)
        {
            for (int j = 0; j < Height; j++)
            {
                Field _field;

                _field.fieldTarget = Instantiate(target, new Vector3(i * 1.0f, 0, j * 1.0f), Quaternion.identity);
                _field.fieldTarget.transform.parent = GameObject.Find("GameField").transform;

                _field.fieldWidth = i;
                _field.fieldHeight = j;

                _field.towerType = TowerType.NONE;

                fieldCubeScript = _field.fieldTarget.GetComponent<FieldCube>();

                fieldCubeScript.SetWidthHeight(i, j);

                fieldArray.Add(_field);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeTowerType(int _width, int _height, TowerType _type)
    {
        Field _field;
        _field = fieldArray[Width * _height + _width];
        _field.towerType = _type;
        fieldArray[Width * _height + _width] = _field;
    }

    public TowerType GetTowerType(int _width, int _height)
    {
        return fieldArray[Width * _height + _width].towerType;
    }

}

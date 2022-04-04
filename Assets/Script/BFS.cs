using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BFS : MonoBehaviour
{
    //���� �������� �� �� �ִ� �Լ��Դϴ�.

    Queue<Edge> que = new Queue<Edge>();
    class Edge
    {
        public int x, y;
        public Edge(int _x, int _y)
        {
            x = _x; y = _y; 
        }
    };

    GameField gameField;
    int N, M;

    public bool BFS_FindPath()
    {

        gameField = GameObject.Find("GameField").GetComponent<GameField>();
        N = gameField.Width + 2;
        M = gameField.Height;
        //int _width = gameField.Width+2-1;
        //int _height = gameField.Height-1;
        int _width = 0;
        int _height = 0;

        int[,] map = new int[N,M]; //���� ���� 0
        bool[,] isVisited = new bool[N,M];

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < M; j++)
            {
                map[i,j] = 1;
                isVisited[i,j] = false;
                //���� �� ����
                if (i != 0 && i != N - 1 && gameField.GetTowerType(i - 1, j) != GameField.TowerType.NONE)
                {
                    map[i, j] = 0;
                }
            }
        }
        /*
        Debug.Log("dafa");
        for (int i = 0; i < N; i++)
        {
            Debug.Log(map[i, 0].ToString()+ map[i, 1].ToString() + map[i, 2].ToString() + map[i, 3].ToString() + map[i, 4].ToString());
        }
        */
        int[] posX = new int[4] { -1, 0, 1, 0 };
        // ����, ��, ������, �Ʒ� 
        int[] posY = new int[4] { 0, 1, 0, -1 };
        // ����, ��, ������, �Ʒ� 

        //

        Edge edge= new Edge(_width, _height);
        que.Enqueue(edge);
       
        // ���� ��ġ push 

        while (que.Count != 0)
        {
            Edge cur = que.Peek();
            que.Dequeue();

            if (isVisited[cur.x, cur.y]) //���� �湮�� �����
            {
                continue;
            }
            isVisited[cur.x, cur.y] = true; //�� ���� �湮�ߴ�!

            if (cur.x == N-1 && cur.y == M-1) //���� �������� �����ߴٸ�
            {
                return true;
            } // �������� 

            /*
            //���� ť�� ����ִµ� �ʱ� ���� �ƴϰ� ��ǥ ������ �������� �ʾҴٸ�
            if (que.Count == 0 && !(isVisited[N-1, M-1]) && !(cur.x == 0 && cur.y == 0))
            {
                return false;
            }*/

            for (int i = 0; i < 4; i++)
            {
                // ����, ��, ������, �Ʒ��� �� �� �ִ��� ���� 
                int next_width = cur.x + posX[i];
                int next_height = cur.y + posY[i];


                if (next_width < 0 || next_width >= N || next_height < 0 || next_height >= M)
                {
                    continue;
                } // map ������ ����� pass 
                if (map[next_width, next_height] == 0)//map[next_width, next_height] == 0
                {
                    continue;
                } // �̵� �Ұ��ϸ� pass 

                Edge _edge;
                _edge = new Edge(next_width, next_height);// �̵� ������ ĭ ����(Edge)�� que�� �ִ´� 
                que.Enqueue(_edge);
            }
        }
        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


//https://sweetday-alice.tistory.com/177
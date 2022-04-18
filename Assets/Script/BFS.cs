using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BFS : MonoBehaviour
{
    //길이 막혔는지 알 수 있는 함수입니다.

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
        Queue<Edge> que = new Queue<Edge>();

        gameField = GameObject.Find("GameField").GetComponent<GameField>();
        N = gameField.Width + 2;
        M = gameField.Height;

        int _width = 0;
        int _height = 0;

        int[,] map = new int[N,M]; //막힌 길이 0
        bool[,] isVisited = new bool[N,M];

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < M; j++)
            {
                map[i,j] = 1;
                isVisited[i,j] = false;
                //막힌 길 설정
                if (i != 0 && i != N - 1 && gameField.GetTowerType(i - 1, j) != GameField.TowerType.NONE)
                {
                    map[i, j] = 0;
                }
            }
        }
        int[] posX = new int[4] { -1, 0, 1, 0 };
        // 왼쪽, 위, 오른쪽, 아래 
        int[] posY = new int[4] { 0, 1, 0, -1 };
        // 왼쪽, 위, 오른쪽, 아래 

        //

        Edge edge= new Edge(_width, _height);
        que.Enqueue(edge);
       
        // 시작 위치 push 

        while (que.Count != 0)
        {
            Edge cur = que.Peek();
            que.Dequeue();
            

            if (isVisited[cur.x, cur.y]) //내가 방문한 노드라면
            {
                continue;
            }
            isVisited[cur.x, cur.y] = true; //이 노드는 방문했다!

            if (cur.x == N-1 && cur.y == M-1) //최종 목적지에 도달했다면
            {
                return true;
            } // 종료조건 

            for (int i = 0; i < 4; i++)
            {
                // 왼쪽, 위, 오른쪽, 아래로 갈 수 있는지 조사 
                int next_width = cur.x + posX[i];
                int next_height = cur.y + posY[i];


                if (next_width < 0 || next_width >= N || next_height < 0 || next_height >= M)
                {
                    continue;
                } // map 영역을 벗어나면 pass 
                if (map[next_width, next_height] == 0)//map[next_width, next_height] == 0
                {
                    continue;
                } // 이동 불가하면 pass 

                Edge _edge;
                _edge = new Edge(next_width, next_height);// 이동 가능한 칸 정보(Edge)를 que에 넣는다 
                que.Enqueue(_edge);
            }
        }
        que.Clear();

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
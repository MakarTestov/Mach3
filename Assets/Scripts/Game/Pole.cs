using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Game
{
    /// <summary>
    /// Для заполнения поля
    /// </summary>
    class Pole : MonoBehaviour
    {
        /// <summary>
        /// Разнообразные блоки для генерации
        /// </summary>
        public GameObject[] blocks;
        /// <summary>
        /// Игровое поле блоков
        /// </summary>
        public GameObject[,] boardblock;

        /// <summary>
        /// Размер поля
        /// </summary>
        [SerializeField]
        private Vector2Int CountWH;

        private float Size;

        private void Start()
        {
            boardblock = new GameObject[CountWH.x, CountWH.y];
            Size = blocks[0].GetComponent<RectTransform>().rect.width;
            GenerateBoard();
            SetNeighbour();
        }

        private void SetNeighbour()
        {
            for (int i = 0; i < boardblock.GetLength(0); i++)
            {
                for (int j = 0; j < boardblock.GetLength(1); j++)
                {
                    if(i > 0)
                        boardblock[i, j].GetComponent<Ball>().linkNeighbouгs.Add(boardblock[i-1, j].GetComponent<Ball>());
                    if(i< boardblock.GetLength(0) - 1)
                        boardblock[i, j].GetComponent<Ball>().linkNeighbouгs.Add(boardblock[i+1, j].GetComponent<Ball>());
                    if(j > 0)
                        boardblock[i, j].GetComponent<Ball>().linkNeighbouгs.Add(boardblock[i, j-1].GetComponent<Ball>());
                    if(j < boardblock.GetLength(1) - 1)
                        boardblock[i, j].GetComponent<Ball>().linkNeighbouгs.Add(boardblock[i, j+1].GetComponent<Ball>());
                }
            }
        }

        public void GenerateBoard()
        {
            float board = Size / 2;
            for(int i = 0; i < boardblock.GetLength(0); i++)
            {
                for(int j = 0; j < boardblock.GetLength(1); j++)
                {
                    int r = Random.Range(0, blocks.Length);
                    GameObject ob = Instantiate(blocks[r], new Vector3(i * Size + board, j * Size + board, 0), Quaternion.identity, transform);
                    ob.name = "Block [" + i + "," + j + "]: " + r;

                    Ball b = ob.GetComponent<Ball>();
                    b.i = i;
                    b.j = j;
                    b.ID = r;
                    boardblock[i, j] = ob;
                }
            }
        }

        /*#region My Methods
        #region GameObject[,] FillPole(GameObject prefabs, Transform parent, Vector2 CountWH)
        /// <summary>
        /// Заполнить поле игровыми объектами
        /// </summary>
        /// <param name="prefabs"></param>
        /// <param name="parent"></param>
        /// <param name="CountWH"></param>
        public static GameObject[,] FillPole(GameObject prefabs, Transform parent, Vector2Int CountWH)
        {
            RectTransform rect = prefabs.GetComponent<RectTransform>();

            float size = parent.GetComponent<RectTransform>().rect.width / CountWH.x;
            rect.sizeDelta = new Vector2(size, size);

            float x = rect.rect.width / 2;
            float y = rect.rect.height / 2;

            GameObject[,] Balls = new GameObject[CountWH.y, CountWH.x];
            for (int i = 0; i < CountWH.y; i++)
            {
                for(int j = 0; j < CountWH.x; j++)
                {
                    Vector2 pos = new Vector2(j * rect.rect.width + x, i * rect.rect.height + y);
                    Balls[i,j] = GameObject.Instantiate(prefabs, pos, Quaternion.identity, parent);
                }
            }
            return Balls;
        }
        #endregion
        #endregion*/
    }
}

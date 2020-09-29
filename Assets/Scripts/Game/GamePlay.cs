using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Game
{
    class GamePlay : MonoBehaviour
    {
        #region Parameters
        #region Links
        #region Prefabs
        /// <summary>
        /// Ссылка на prefab шарика
        /// </summary>
        [SerializeField]
        private GameObject Prefabs;
        #endregion

        #region ParentPrefabs
        /// <summary>
        /// Ссылка на Transfer поля игры
        /// </summary>
        [SerializeField]
        private Transform ParentPrefabs;
        #endregion

        #region CountWH
        /// <summary>
        /// Размер поля игры
        /// </summary>
        [SerializeField]
        private Vector2Int CountWH;
        #endregion

        #region GameBall
        /// <summary>
        /// Ссылка на все поле шариков
        /// </summary>
        private GameObject[,] GameBall;
        #endregion
        #endregion

        private bool isSelect = true;

        private float Size;
        #endregion

        #region Unity Methods
        public void Start()
        {
            GameBall = Pole.FillPole(Prefabs, ParentPrefabs, CountWH);
            Size = GameBall[0,0].GetComponent<RectTransform>().rect.width;
            SetIndexBall_AndIventClick();
        }
        #endregion

        private void SetIndexBall_AndIventClick()
        {
            for(byte i = 0; i< GameBall.GetLength(0);i++)
            {
                for(byte j = 0; j < GameBall.GetLength(1); j++)
                {
                    BallWithCoordinate bwc = GameBall[i, j].GetComponent<BallWithCoordinate>();
                    bwc.SetIJ(i, j);
                    GameBall[i, j].GetComponent<Button>().onClick.AddListener(() => this.TouchBall(bwc));
                }
            }
        }

        public void TouchBall(BallWithCoordinate ballTouch)
        {
            int x = ballTouch.I;
            int y = ballTouch.J;
            List<GameObject> l = new List<GameObject>();
            l.Add(GameBall[x, y]);
            l = DeleteBallColor(ballTouch.GetComponent<Image>().color, x, y, l);
            Debug.Log(l.Count);
            foreach(var r in l)
            {
                r.SetActive(false);
            }
        }

        public List<GameObject> DeleteBallColor(Color color, int x, int y, List<GameObject> wasball)
        {
            for(int i = x - 1; i <= x + 1; i++)
            {
                for(int j = y - 1; j <= y + 1; j++)
                {
                    if((i == x && j == y) || wasball.Find(k => k == GameBall[x,y]) != null || x < 0 || y < 0 || x >= GameBall.GetLength(0) || y >= GameBall.GetLength(1))
                    {
                        Debug.Log("1 if");
                        continue;
                    }
                    if(GameBall[x,y].GetComponent<Image>().color == color)
                    {
                        wasball.Add(GameBall[x, y]);
                        DeleteBallColor(color, x, y, wasball);
                    }
                }
            }
            return wasball;
        }
    }
}

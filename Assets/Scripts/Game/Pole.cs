using System;
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
    static class Pole
    {
        #region My Methods
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
        #endregion
    }
}

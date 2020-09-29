using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Game
{
    /// <summary>
    /// Основной класс шара
    /// </summary>
    [RequireComponent(typeof(Image))]
    class Ball : Ball_Abstract
    {
        #region Parameters
        #region image
        /// <summary>
        /// Ссылка на текущий компонент Image
        /// </summary>
        private Image image;
        #endregion
        #endregion

        #region Unity Methods
        public void Start()
        {
            image = GetComponent<Image>();
            image.color = GetRandomColor();
        }
        #endregion

        #region My Methods
        #region Color GetRandomColor()
        /// <summary>
        /// Получить случайный цвет
        /// </summary>
        /// <returns></returns>
        public Color GetRandomColor()
        {
            switch(UnityEngine.Random.Range(0, 5))
            {
                case 0:
                    {
                        return Color.red;
                    }
                case 1:
                    {
                        return Color.green;
                    }
                case 2:
                    {
                        return Color.blue;
                    }
                case 3:
                    {
                        return Color.yellow;
                    }
                case 4:
                    {
                        return Color.cyan;
                    }
                default:
                    {
                        return Color.white;
                    }
            }
        }
        #endregion
        #endregion
    }
}

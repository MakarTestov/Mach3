using Assets.Scripts.Effects;
using Assets.Scripts.Loading;
using Assets.Scripts.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.MenuControllers
{
    /// <summary>
    /// Управление меню игры
    /// </summary>
    class Game_Controller : MonoBehaviour
    {
        #region My Methods
        #region Clicks
        #region Back_Click()
        /// <summary>
        /// Нажатие на кнопку возвращения в главное меню
        /// </summary>
        public void Back_Click()
        {
            Loading_Controller.LoadScene(AllNameScene.GetName_MineMenu());
        }
        #endregion

        #region ShowHide(GameObject show)
        /// <summary>
        /// Показать скрыть панель
        /// </summary>
        /// <param name="show"></param>
        public void ShowHide(GameObject show)
        {
            ShowHideObject.ShowHide(show);
        }
        #endregion
        #endregion
        #endregion
    }
}

using Assets.Scripts.Loading;
using Assets.Scripts.Tags;
using UnityEngine;

namespace Assets.Scripts.MenuControllers
{
    /// <summary>
    /// Класс управления кнопками на сцене Records
    /// </summary>
    class Record_Controller : MonoBehaviour
    {
        #region My Methods
        #region Cliks
        #region Back_Click()
        /// <summary>
        /// Нажатие на кнопку возвращение в меню
        /// </summary>
        public void Back_Click()
        {
            Loading_Controller.LoadScene(AllNameScene.GetName_MineMenu());
        }
        #endregion
        #endregion
        #endregion
    }
}

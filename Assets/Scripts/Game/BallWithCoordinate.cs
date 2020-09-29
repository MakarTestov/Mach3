using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Game
{
    /// <summary>
    /// Класс шара с координатоми по сетке
    /// </summary>
    class BallWithCoordinate : Ball
    {
        #region Parameters
        #region I
        /// <summary>
        /// Индекс I по сетке
        /// </summary>
        public byte I;
        #endregion

        #region J
        /// <summary>
        /// Индекс J по сетке
        /// </summary>
        public byte J;
        #endregion
        #endregion

        #region My methods
        #region SetIJ(byte i, byte j)
        /// <summary>
        /// Установить координаты по сетке
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        public void SetIJ(byte i, byte j)
        {
            I = i;
            J = j;
        }
        #endregion
        #endregion
    }
}

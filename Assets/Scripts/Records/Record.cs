using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Records
{
    /// <summary>
    /// Класс для хранения информации о рекорде
    /// </summary>
    class Record : IComparer<Record>
    {
        #region Parameters
        #region Name
        /// <summary>
        /// Имя рекордсмена
        /// </summary>
        public string Name { get; set; }
        #endregion

        #region Date
        /// <summary>
        /// Дата рекорда
        /// </summary>
        public DateTime Date { get; set; }
        #endregion

        #region Points
        /// <summary>
        /// Набранные очки
        /// </summary>
        public int Points { get; set; }
        #endregion
        #endregion

        #region My Methods
        #region string ToStringCSV()
        /// <summary>
        /// Получить текстовый формат класса в CSV
        /// </summary>
        /// <returns></returns>
        public string ToStringCSV()
        {
            return Name + ";" + Points.ToString() + ";" + Date.ToString("d");
        }
        #endregion

        #region ToString()
        public override string ToString()
        {
            return Name + " - " + Points.ToString() + " - " + Date.ToString("d");
        }
        #endregion

        #region int Compare(Record x, Record y)
        /// <summary>
        /// Метод для сортировок
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(Record x, Record y)
        {
            if(x.Points > y.Points)
            {
                return -1;
            }
            if(x.Points < y.Points)
            {
                return 1;
            }
            return 0;
        }
        #endregion
        #endregion
    }
}

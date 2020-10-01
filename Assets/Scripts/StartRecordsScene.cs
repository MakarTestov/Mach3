using Assets.Scripts.Patterns;
using Assets.Scripts.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    /// <summary>
    /// Класс для дел при запуске сцены About
    /// </summary>
    class StartRecordsScene : MonoBehaviour
    {
        #region Parameters
        #region TextRecords
        /// <summary>
        /// Ссылка на компонент текста для рекорда
        /// </summary>
        [SerializeField]
        private Text TextRecords;
        #endregion
        #endregion

        #region Unity Methods
        private void Start()
        {
            TableRecord record = Singleton<TableRecord>.GetSingleton().TObject;
            record.LoadRecord();
            TextRecords.text = GetTextTableRecord(record.Records);
        }
        #endregion

        #region My Methods
        #region string GetTextTableRecord(List<Record> records)
        /// <summary>
        /// Сформировать текст рекорда
        /// </summary>
        /// <param name="records"></param>
        /// <returns></returns>
        public static string GetTextTableRecord(List<Record> records)
        {
            Record r = Singleton<Record>.GetSingleton().TObject;
            string text = "";
            for (byte i = 0; i < records.Count; i++)
            {
                if (r != records[i])
                { 
                    text += records[i].ToString() + "\n";
                }
                else
                {
                    string n = "<color=red>new</color>";
                    text += n + records[i].ToString() + n + "\n";
                }
                text += "-------------\n";
            }
            return text;
        }
        #endregion
        #endregion
    }
}

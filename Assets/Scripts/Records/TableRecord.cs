using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Records
{
    /// <summary>
    /// Класс таблицы рекордов игры
    /// </summary>
    class TableRecord
    {
        #region Parameters
        #region Path
        /// <summary>
        /// Путь к файлу сохранения рекордов
        /// </summary>
        private string Path = @"E:\Record.csv";
        #endregion

        #region Records
        /// <summary>
        /// Таблица рекордов
        /// </summary>
        private List<Record> records;
        /// <summary>
        /// Таблица рекордов
        /// </summary>
        public List<Record> Records
        {
            get { return records; }
            set { records = value; }
        }
        #endregion

        #region CountRecords
        /// <summary>
        /// Количество строк в таблице
        /// </summary>
        private byte CountRecords = 10;
        #endregion
        #endregion

        #region Constructors
        #region TableRecord()
        public TableRecord()
        {

        }
        #endregion

        #region TableRecord(byte count)
        public TableRecord(byte count)
        {
            CountRecords = count;
        }
        #endregion
        #endregion

        #region My Methods
        #region LoadRecord()
        /// <summary>
        /// Загрузить таблицу рекордов
        /// </summary>
        public void LoadRecord()
        {
            records = new List<Record>(CountRecords);
            if (File.Exists(Path))
            {
                using (StreamReader sr = new StreamReader(Path, Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] t = line.Split(';');
                        if (t != null)
                        {
                            Record r = new Record { Name = t[0], Points = Convert.ToInt32(t[1]), Date = DateTime.Parse(t[2]) };
                            records.Add(r);
                        }
                    }
                }
            }
            else
            {
                records = CreatedefaultRecords(CountRecords);
                SaveFileRecordsCSV_Async(records, Path);
            }
        }
        #endregion

        #region AddRecord(Record record)
        /// <summary>
        /// Добавить новый рекорд
        /// </summary>
        /// <param name="record"></param>
        public void AddRecord(Record record)
        {
            records.Add(record);
            records.Sort(record);
            if(records.Count > CountRecords)
            {
                records.RemoveAt(CountRecords);
            }
            SaveFileRecordsCSV_Async(records, Path);//SaveFileRecordsCSV(records, Path);
        }
        #endregion

        #region List<Record> CreatedefaultRecords(byte count)
        /// <summary>
        /// Создать таблицу рекордов
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        private static List<Record> CreatedefaultRecords(byte count)
        {
            List<Record> tr = new List<Record>(count);

            DateTime date = DateTime.MinValue;
            string d = date.ToString("d");
            date = DateTime.Parse(d);

            for(byte i = 1; i <= tr.Capacity; i++)
            {
                Record r = new Record { Name = "Name " + i.ToString(), Points = tr.Capacity * 10 -  i * 10 + 10, Date = date };
                tr.Add(r);
            }
            return tr;
        }
        #endregion

        #region SaveFileRecordsCSV(List<Record> tr, string Path)
        /// <summary>
        /// Сохранить файл таблицы рекордов
        /// </summary>
        /// <param name="tr"></param>
        public static void SaveFileRecordsCSV(List<Record> tr, string Path)
        {
            string text = "";
            for (byte i = 0; i < tr.Count; i++)
            {
                if(i > 0)
                {
                    text += "\n";
                }
                text += tr[i].ToStringCSV();
            }
            using (StreamWriter sw = new StreamWriter(Path, false, Encoding.Default))
            {
                sw.WriteLine(text);
            }
        }
        #endregion

        #region SaveFileRecordsCSV_Async(List<Record> tr, string Path)
        /// <summary>
        /// Сохранить файл таблицы рекордов асинхронно
        /// </summary>
        /// <param name="tr"></param>
        public static async void SaveFileRecordsCSV_Async(List<Record> tr, string Path)
        {
            await Task.Run(() => SaveFileRecordsCSV(tr, Path));
        }
        #endregion
        #endregion
    }
}

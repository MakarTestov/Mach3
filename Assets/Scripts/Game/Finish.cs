using Assets.Scripts.Loading;
using Assets.Scripts.Patterns;
using Assets.Scripts.Records;
using Assets.Scripts.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Game
{
    /// <summary>
    /// Класс для управлением состоянием концовки
    /// </summary>
    class Finish : MonoBehaviour
    {
        #region Parameters
        #region GamePole
        /// <summary>
        /// Ссылка на генератор поля
        /// </summary>
        [SerializeField]
        private Pole GamePole;
        #endregion

        #region NameInput
        /// <summary>
        /// Ссылка на объект ввода имени
        /// </summary>
        [SerializeField]
        private GameObject NameInput;
        #endregion

        #region TextEndGame
        /// <summary>
        /// Ссылка на текст конца игры
        /// </summary>
        [SerializeField]
        private Text TextEndGame;

        #region ButtonText
        /// <summary>
        /// Ссылка на текст кнопки выхода из Gamezone
        /// </summary>
        [SerializeField]
        private Text ButtonText;
        #endregion
        #endregion

        #region isGoodEnd
        /// <summary>
        /// Хорошая сейчас концовка
        /// </summary>
        [SerializeField]
        private bool isGoodEnd = true;
        #endregion
        #endregion

        #region Unity Methods
        private void Start()
        {
            TableRecord tableRecord = Singleton<TableRecord>.GetSingleton().TObject;
            isGoodEnd = tableRecord.CheckRecordAdded(GamePole.Score);
            if(isGoodEnd)
            {
                LoadGoodEnd();
            }
            else
            {
                LoadBadend();
            }
        }
        #endregion

        #region My Methods
        #region LoadBadend()
        /// <summary>
        /// Загрузка плохой концовки
        /// </summary>
        private void LoadBadend()
        {
            NameInput.SetActive(false);
            TextEndGame.text = "К сожалению вы не смогли побить рекорд :(";
            ButtonText.text = "Жаль";
        }
        #endregion

        #region LoadGoodEnd()
        /// <summary>
        /// Загрузка хорошей концовки
        /// </summary>
        private void LoadGoodEnd()
        {
            NameInput.SetActive(true);
            TextEndGame.text = "--Новый рекорд!--\nПоздравлюем! Вы набрали: " + GamePole.Score + ". Урааа!";
            ButtonText.text = "К рекордам";
        }
        #endregion

        #region ClickEnd()
        /// <summary>
        /// Событие при нажатии кнопки выхода
        /// </summary>
        public void ClickEnd()
        {
            if(isGoodEnd)
            {
                #region Create Record
                Record r = Singleton<Record>.GetSingleton().TObject;
                r.AddDate(DateTime.Now);
                string name = NameInput.GetComponent<InputField>().text;
                if(name == "")
                {
                    name = "NamePlayer1";
                }
                r.Name = name;
                r.Points = GamePole.Score;
                Singleton<TableRecord>.GetSingleton().TObject.AddRecord(r);
                #endregion

                Loading_Controller.LoadScene(AllNameScene.GetName_Records());
            }
            else
            {
                Loading_Controller.LoadScene(AllNameScene.GetName_MineMenu());
            }
            this.enabled = false;
        }
        #endregion
        #endregion
    }
}

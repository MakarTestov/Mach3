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
    /// Класс секундомер
    /// </summary>
    [RequireComponent(typeof(Text))]
    class Timer : MonoBehaviour
    {
        #region Parameters
        #region sec
        /// <summary>
        /// Секунды
        /// </summary>
        private int sec = 0;
        #endregion

        #region milisec
        /// <summary>
        /// Миллисекунды
        /// </summary>
        private float milisec = 0;
        #endregion

        #region LimitTimeMilliSec
        /// <summary>
        /// Лимит времени
        /// </summary>
        public float LimitTimeMilliSec = 2.0f;
        #endregion

        /// <summary>
        /// Работает ли сейчас таймер
        /// </summary>
        [SerializeField]
        private bool isTick = false;

        #region timer
        /// <summary>
        /// Ссылка на текст для таймера
        /// </summary>
        private Text timer;
        #endregion

        #region TimerOver
        public delegate void EndTime(Timer timer);
        /// <summary>
        /// Вызывается, когда время прошло
        /// </summary>
        public event EndTime TimerOver;
        #endregion
        #endregion

        #region Unity Methods
        private void Start()
        {
            timer = GetComponent<Text>();
        }

        private void Update()
        {
            if (isTick)
            {
                milisec += Time.deltaTime;
                if (milisec >= 1)
                {
                    sec++;
                    milisec -= 1;
                }
                string tmp = "";
                if (sec < 10)
                {
                    tmp += "0" + sec.ToString();
                }
                else
                {
                    tmp += sec.ToString();
                }
                tmp += ":";
                int m = ((int)(milisec * 100));
                if (m < 10)
                {
                    tmp += "0" + m.ToString();
                }
                else
                {
                    tmp += m.ToString();
                }
                timer.text = tmp;
                if(milisec + sec > LimitTimeMilliSec)
                {
                    StopTimer();
                    TimerOver?.Invoke(this);
                }
            }
        }
        #endregion

        #region My methods
        #region ClearTimer()
        /// <summary>
        /// Обнулить время
        /// </summary>
        public void ClearTimer()
        {
            sec = 0;
            milisec = 0;
        }
        #endregion

        #region StartTimer()
        /// <summary>
        /// Запустить таймер
        /// </summary>
        public void StartTimer()
        {
            isTick = true;
        }
        #endregion

        #region StopTimer()
        /// <summary>
        /// Остановить таймер
        /// </summary>
        public void StopTimer()
        {
            isTick = false;
        }
        #endregion
        #endregion
    }
}

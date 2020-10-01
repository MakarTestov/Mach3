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

        private int sec;
        private int mill;

        #region nowmil
        /// <summary>
        /// Оставшееся время
        /// </summary>
        private float nowmil;
        #endregion

        #region LimitTimeMilliSec
        /// <summary>
        /// Лимит времени
        /// </summary>
        public float LimitTimeMilliSec = 2.0f;
        #endregion

        #region isTick
        /// <summary>
        /// Работает ли сейчас таймер
        /// </summary>
        public static bool isTick = false;
        #endregion

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
            SetTimeStart();
        }

        private void Update()
        {
            if (isTick)
            {
                string tmp = "";
                nowmil -= Time.deltaTime;
                sec = (int)(nowmil);
                mill = (int)((nowmil - sec) * 100);
                if(sec < 10)
                {
                    tmp += "0";
                }
                tmp += sec + ":";
                if(mill < 10)
                {
                    tmp += "0";
                }
                tmp += mill;
                timer.text = tmp;
                if(nowmil < 0)
                {
                    StopTimer();
                    TimerOver?.Invoke(this);
                }
            }
        }
        #endregion

        #region My methods
        #region SetTimeStart()
        /// <summary>
        /// Установить начальное значение таймера
        /// </summary>
        public void SetTimeStart()
        {
            nowmil = LimitTimeMilliSec;
            sec = (int)LimitTimeMilliSec;
            mill = (int)((LimitTimeMilliSec - sec) * 100);
            timer.text = "";
            if (sec < 10)
            {
                timer.text += "0";
            }
            timer.text += sec + ":";
            if (mill < 10)
            {
                timer.text += "0";
            }
            timer.text += mill;
        }
        #endregion

        #region ClearTimer()
        /// <summary>
        /// Обнулить время
        /// </summary>
        public void ClearTimer()
        {
            nowmil = LimitTimeMilliSec;
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

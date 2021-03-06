﻿using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Game
{
    class ResizeBall : MonoBehaviour
    {
        #region Parameters
        #region size
        /// <summary>
        /// Минимальный размер объекта
        /// </summary>
        public float size = 0.5f;
        #endregion

        public static bool nonstop = true;
        #region speed
        /// <summary>
        /// Скорость изменения
        /// </summary>
        public float speed = 2.0f;
        #endregion
        #endregion

        #region unity Methods
        private void Start()
        {
            StartCoroutine(Resize(true));
        }
        #endregion

        #region Resize 
        /// <summary>
        /// Корутин изменения объекта
        /// </summary>
        /// <param name="up"></param>
        /// <returns></returns>
        public IEnumerator Resize(bool up)
        {
            float t = speed * Time.deltaTime;
            if (up)
            {
                while (size < 1.0f)
                {
                    size += t;
                    transform.localScale = new Vector3(size, size, 1);
                    yield return new WaitForFixedUpdate();
                }
            }
            else
            {
                while (size > 0.5f)
                {
                    size -= t;
                    transform.localScale = new Vector3(size, size, 1);
                    yield return new WaitForFixedUpdate();
                }
            }
            yield return null;
        }
        #endregion
    }
}

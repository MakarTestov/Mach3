using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Game
{
    [RequireComponent(typeof(Button))]
    class Ball : MonoBehaviour
    {
        #region Parameters
        public int ID;
        public int i;
        public int j;

        public static GameObject select;
        public static GameObject moveTo;

        public static int IDColor;
        #endregion

        #region EndClick
        public delegate void EventClick(Ball ball);
        /// <summary>
        /// Событие вызываемое при завершении обработки клика
        /// </summary>
        public event EventClick EndClick;
        #endregion

        #region Unity Methods
        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(Click);
        }
        #endregion

        #region Click()
        /// <summary>
        /// Событие при клике на мяч
        /// </summary>
        public void Click()
        {
             EndClick?.Invoke(this);
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Game
{
    [RequireComponent(typeof(Button))]
    class Ball : MonoBehaviour
    {
        public int ID;
        public int i;
        public int j;

        public static GameObject select;
        public static GameObject moveTo;

        public List<Ball> linkNeighbouгs;

        public static Color ClickColor;
        public Color myColor;

        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(Click);
            myColor = GetComponent<Image>().color;
        }

        public void Click()
        {
            ClickColor = myColor;
            List<Ball> nb = new List<Ball>();
            nb.Add(this);
            SetNeighbourColor(nb);
        }

        #region List<Ball> SetNeighbourColor(List<Ball> nb)
        /// <summary>
        /// Установить список соседей того же цвета
        /// </summary>
        /// <param name="nb"></param>
        /// <returns></returns>
        public List<Ball> SetNeighbourColor(List<Ball> nb)
        {
            foreach(var r in linkNeighbouгs)
            {
                if(r.myColor == ClickColor && nb.Find(x => x == r) == null)
                {
                    nb.Add(r);
                    r.SetNeighbourColor(nb);
                }
            }
            return nb;
        }
        #endregion
    }
}

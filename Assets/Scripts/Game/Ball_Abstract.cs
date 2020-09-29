using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Game
{
    /// <summary>
    /// Все объекты шаров поля должны наследовать от него
    /// </summary>
    [RequireComponent(typeof(RectTransform))]
    class Ball_Abstract : MonoBehaviour
    {
    }
}

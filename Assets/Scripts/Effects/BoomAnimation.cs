using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomAnimation : MonoBehaviour
{
    #region My Methods
    #region EndAnimationBoom()
    /// <summary>
    /// Событие при окончании анимации взрыва
    /// </summary>
    public void EndAnimationBoom()
    {
        Destroy(gameObject);
    }
    #endregion
    #endregion
}

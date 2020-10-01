using Assets.Scripts.Loading;
using Assets.Scripts.Tags;
using UnityEngine;

/// <summary>
/// Для управлением взаимодействием кнопками меню
/// </summary>
public class About_Controller : MonoBehaviour
{
    #region My Methods
    #region Clicks
    #region Back_Click()
    /// <summary>
    /// Нажатие на кнопку возвращения в меню
    /// </summary>
    public void Back_Click()
    {
        Loading_Controller.LoadScene(AllNameScene.GetName_MineMenu());
    }
    #endregion

    #region Vk_Click()
    /// <summary>
    /// Для перехода к страничке разработчика
    /// </summary>
    public void Vk_Click()
    {
        Application.OpenURL(AllLink.VK());
    }
    #endregion
    #endregion
    #endregion
}

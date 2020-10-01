using Assets.Scripts.Effects;
using Assets.Scripts.Loading;
using Assets.Scripts.Tags;
using UnityEngine;

/// <summary>
/// Для управлением взаимодействием кнопками меню
/// </summary>
public class Menu_Controller : MonoBehaviour
{
    #region My Methods
    #region Clicks
    #region Play_Click()
    /// <summary>
    /// Нажатие на кноку начала игры
    /// </summary>
    public void Play_Click()
    {
        Loading_Controller.LoadScene(AllNameScene.GetName_GameScene());
    }
    #endregion

    #region About_Click()
    /// <summary>
    /// Нажатие на кнопку о програамме
    /// </summary>
    public void About_Click()
    {
        Loading_Controller.LoadScene(AllNameScene.GetName_About());
    }
    #endregion

    #region Records_Click()
    /// <summary>
    /// Нажатие на кнопку рекордов
    /// </summary>
    public void Records_Click()
    {
        Loading_Controller.LoadScene(AllNameScene.GetName_Records());
    }
    #endregion

    #region Exit_Click()
    /// <summary>
    /// Нажатие на кнопку выхода из игры
    /// </summary>
    public void Exit_Click()
    {
        Application.Quit();
    }
    #endregion
    #endregion

    #region ShowHide(GameObject ob)
    /// <summary>
    /// Скрыть показать окно
    /// </summary>
    /// <param name="ob"></param>
    public void ShowHide(GameObject ob)
    {
        ShowHideObject.ShowHide(ob);
    }
    #endregion
    #endregion
}

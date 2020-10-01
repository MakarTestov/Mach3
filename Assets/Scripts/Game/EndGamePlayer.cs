using Assets.Scripts.Patterns;
using Assets.Scripts.Records;
using UnityEngine;

namespace Assets.Scripts.Game
{
    /// <summary>
    /// Класс для управлением концом игры
    /// </summary>
    class EndGamePlayer : MonoBehaviour
    {
        #region Parameters
        #region GamePole
        /// <summary>
        /// Ссылка на генератор поля
        /// </summary>
        [SerializeField]
        private Pole GamePole;
        #endregion

        #region GoodEnd
        /// <summary>
        /// Ссылка на объект концовки
        /// </summary>
        [SerializeField]
        private GameObject End;
        #endregion
        #endregion

        #region Unity Methods
        private void Start()
        {
            GamePole.EndGame += Finish;
        }
        #endregion

        #region My Methods
        private void Finish(Pole pole, TypeEnd typeEnd)
        {
            TableRecord tablerecord = Singleton<TableRecord>.GetSingleton().TObject;
            if(!tablerecord.IsTableLoad)
            {
                tablerecord.LoadRecord();
            }
            End.SetActive(true);
        }
        #endregion
    }
}

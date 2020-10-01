using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Game
{
    public enum TypeEnd { TimeOver, StepOver };
    /// <summary>
    /// Для заполнения поля
    /// </summary>
    class Pole : MonoBehaviour
    {
        #region Parameters
        #region blocks
        /// <summary>
        /// Разнообразные блоки для генерации. Индекс блока - ID
        /// </summary>
        public GameObject[] blocks;
        #endregion

        #region boardblock
        /// <summary>
        /// Игровое поле блоков
        /// </summary>
        public GameObject[,] boardblock;
        #endregion

        #region Pointer
        /// <summary>
        /// Ссылка на объект указателя
        /// </summary>
        [SerializeField]
        private GameObject Pointer;
        #endregion

        #region timer
        /// <summary>
        /// Ссылка на таймер
        /// </summary>
        [SerializeField]
        private Timer timer;
        #endregion

        #region CountWH
        /// <summary>
        /// Размер поля
        /// </summary>
        [SerializeField]
        private Vector2Int CountWH;
        #endregion

        #region CountSteps
        /// <summary>
        /// Количество ходов игры
        /// </summary>
        [SerializeField]
        private int CountSteps = 10;
        #endregion

        #region CountStepsText
        /// <summary>
        /// Ссылка на текс количества ходов
        /// </summary>
        [SerializeField]
        private Text CountStepsText;
        #endregion

        #region Score
        /// <summary>
        /// Текущий счет игры
        /// </summary>
        [SerializeField]
        private int score = 0;
        /// <summary>
        /// Текущий счет игры
        /// </summary>
        public int Score
        {
            get { return score; }
        }
        #endregion

        #region ScoreText
        /// <summary>
        /// Ссылка на текст счета очков
        /// </summary>
        [SerializeField]
        private Text ScoreText;
        #endregion

        #region Size
        /// <summary>
        /// Размер одного блока
        /// </summary>
        private float Size;
        #endregion

        #region CanClick
        /// <summary>
        /// Можно ли сейчас кликать
        /// </summary>
        private bool CanClick = true;
        #endregion

        #region isend
        /// <summary>
        /// Сейчас конец игры?
        /// </summary>
        private bool isend = false;
        #endregion

        #region EndType
        /// <summary>
        /// Тип окончания игры
        /// </summary>
        private TypeEnd endType;
        /// <summary>
        /// Тип окончания игры
        /// </summary>
        public TypeEnd EndType
        {
            get { return endType; }
        }
        #endregion

        #region EndGame
        public delegate void EventPole(Pole pole, TypeEnd typeEnd);
        /// <summary>
        /// Вызывается при завершении игры
        /// </summary>
        public event EventPole EndGame;
        #endregion
        #endregion

        #region Unity Methods
        private void Start()
        {
            SetStepCountText();
            boardblock = new GameObject[CountWH.y, CountWH.x];
            Size = blocks[0].GetComponent<RectTransform>().rect.width;
            GenerateBoard();

            timer.TimerOver += EndTime;
        }
        #endregion

        #region My Methods
        #region SetStepCountText()
        /// <summary>
        /// Установить текст количество имеющихся шагов для игрока
        /// </summary>
        private void SetStepCountText()
        {
            CountStepsText.text = CountSteps.ToString();
        }
        #endregion

        #region End_Game()
        /// <summary>
        /// Метод вызывается при завершении игры
        /// </summary>
        private void End_Game()
        {
            isend = true;
            EndGame?.Invoke(this, endType);
        }
        #endregion

        #region GenerateBoard()
        /// <summary>
        /// Сгенерировать игровое поле
        /// </summary>
        public void GenerateBoard()
        {
            float board = Size / 2;
            for (int i = 0; i < boardblock.GetLength(0); i++)
            {
                for (int j = 0; j < boardblock.GetLength(1); j++)
                {
                    int r = Random.Range(0, blocks.Length);
                    GameObject ob = Instantiate(blocks[r], new Vector3(j * Size + board, i * Size + board, 0), Quaternion.identity, transform);
                    ob.name = "Block [" + i + "," + j + "]: " + r;

                    Ball b = ob.GetComponent<Ball>();
                    b.i = i;
                    b.j = j;
                    b.ID = r;
                    b.EndClick += BallDelete;
                    boardblock[i, j] = ob;
                }
            }
            Pointer.transform.position = boardblock[Random.Range(0, boardblock.GetLength(0)), Random.Range(0, boardblock.GetLength(1))].transform.position;
        }
        #endregion

        #region EndTime(Timer timer)
        /// <summary>
        /// Событие при завершении времени
        /// </summary>
        /// <param name="timer"></param>
        private void EndTime(Timer timer)
        {
            endType = TypeEnd.TimeOver;
            End_Game();
        }
        #endregion

        #region ChangeScore(int plusScore)
        /// <summary>
        /// Изменить количество очков
        /// </summary>
        /// <param name="plusScore">Количество шаров, которое нужно приплюсовать</param>
        private void ChangeScore(int plusScore)
        {
            score += plusScore;
            ScoreText.text = "Score: " + score;
        }
        #endregion

        #region ChangeCountStep(int countBall)
        /// <summary>
        /// Изменить количество шагов
        /// </summary>
        /// <param name="countBall">Количество одинаковых шаров рядом</param>
        private void ChangeCountStep(int countBall)
        {
            if (countBall < 3)
            {
                CountSteps--;
            }
            else
            {
                if (countBall == 3)
                {
                    CountSteps += 2;
                }
                else
                {
                    if (countBall == 4)
                    {
                        CountSteps += 3;
                    }
                    else
                    {
                        CountSteps += 4;
                    }
                }
            }
            SetStepCountText();
            if (CountSteps <= 0)
            {
                endType = TypeEnd.StepOver;
                End_Game();
            }
        }
        #endregion

        #region ChangeBlock(Ball ball)
        /// <summary>
        /// Изменить блок
        /// </summary>
        /// <param name="ball"></param>
        private void ChangeBlock(Ball ball)
        {
            int r = Random.Range(0, blocks.Length);
            ball.GetComponent<Image>().color = blocks[r].GetComponent<Image>().color;
            ball.ID = r;
        }
        #endregion

        #region BallDelete(Ball ball)
        /// <summary>
        /// Событие при клике на шар
        /// </summary>
        /// <param name="ball"></param>
        private void BallDelete(Ball ball)
        {
            StartCoroutine(DeleteBall(ball));
        }
        #endregion

        #region IEnumerator DeleteBall(Ball ball)
        /// <summary>
        /// Корутин для удаления шаров при завершении клика
        /// </summary>
        /// <param name="ball"></param>
        private IEnumerator DeleteBall(Ball ball)
        {
            timer.StopTimer();
            if (CanClick)
            {
                if (Pointer.activeSelf)
                {
                    Pointer.SetActive(false);
                    timer.StartTimer();
                }
                CanClick = false;

                #region Sourch Balls by ID
                List<Ball> nball = new List<Ball>();
                nball.Add(ball);
                Ball.IDColor = ball.ID;
                CheckBallColor(ball.i, ball.j, nball);
                #endregion

                #region Change Text for Player
                ChangeCountStep(nball.Count);
                ChangeScore(nball.Count);
                #endregion

                if (!isend)
                {
                    #region Shifting blocks
                    foreach (var r in nball)
                    {
                        yield return StartCoroutine(r.GetComponent<ResizeBall>().Resize(false));
                        DownCollum(r.i, r.j, r);
                        ChangeBlock(r);
                    }
                    #endregion
                }
                CanClick = true;

                timer.ClearTimer();
                timer.StartTimer();
            }
            yield return null;
        }
        #endregion

        #region CheckBallColor(int i, int j, List<Ball> nb)
        /// <summary>
        /// Собрать в список имеющиеся шары одного цвета
        /// </summary>
        /// <param name="i">Координта по оси y шара клика</param>
        /// <param name="j">Координта по оси х шара клика</param>
        /// <param name="nb">Список шаров одного цвета</param>
        public void CheckBallColor(int i, int j, List<Ball> nb)
        {
            if (i > 0)
            {
                Ball b = boardblock[i - 1, j].GetComponent<Ball>();
                if (nb.Find(x => x == b) == null && b.ID == Ball.IDColor)
                {
                    nb.Add(b);
                    CheckBallColor(i - 1, j, nb);
                }
            }
            if (i < boardblock.GetLength(0) - 1)
            {
                Ball b = boardblock[i + 1, j].GetComponent<Ball>();
                if (nb.Find(x => x == b) == null && b.ID == Ball.IDColor)
                {
                    nb.Add(b);
                    CheckBallColor(i + 1, j, nb);
                }
            }
            if (j > 0)
            {
                Ball b = boardblock[i, j - 1].GetComponent<Ball>();
                if (nb.Find(x => x == b) == null && b.ID == Ball.IDColor)
                {
                    nb.Add(b);
                    CheckBallColor(i, j - 1, nb);
                }
            }
            if (j < boardblock.GetLength(1) - 1)
            {
                Ball b = boardblock[i, j + 1].GetComponent<Ball>();
                if (nb.Find(x => x == b) == null && b.ID == Ball.IDColor)
                {
                    nb.Add(b);
                    CheckBallColor(i, j + 1, nb);
                }
            }
        }
        #endregion

        #region DownCollum(int iCollum, int jCollum, Ball ball)
        /// <summary>
        /// Сдвинуть шары вниз
        /// </summary>
        /// <param name="iCollum"></param>
        /// <param name="jCollum"></param>
        /// <param name="ball"></param>
        private void DownCollum(int iCollum, int jCollum, Ball ball)
        {
            int imax = boardblock.GetLength(0);
            for (int i = iCollum; i < imax - 1; i++)
            {
                GameObject g = boardblock[i, jCollum];

                #region Swap i and i + 1 blocks
                Vector3 pos = boardblock[i, jCollum].transform.position;
                boardblock[i, jCollum].transform.position = boardblock[i + 1, jCollum].transform.position;
                boardblock[i + 1, jCollum].transform.position = pos;
                #endregion

                #region Change link i and i + 1 blocks
                boardblock[i, jCollum].GetComponent<Ball>().i++;
                boardblock[i + 1, jCollum].GetComponent<Ball>().i--;

                boardblock[i, jCollum] = boardblock[i + 1, jCollum];
                boardblock[i + 1, jCollum] = g;
                #endregion
            }
            StartCoroutine(ball.GetComponent<ResizeBall>().Resize(true));

        }
        #endregion
        #endregion
    }
}

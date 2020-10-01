using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Loading
{
    class Loading_Controller : MonoBehaviour
    {
        private static Loading_Controller loading;
        public static Loading_Controller Loading { get { return loading; } }

        [HideInInspector]
        public Animator animator;

        public AsyncOperation asynload = new AsyncOperation();

        public void Start()
        {
            loading = this;
            animator = GetComponent<Animator>();
        }

        public static void LoadScene(string nameScene)
        {
            Loading.animator.SetTrigger("EndScene");
            Loading.asynload = SceneManager.LoadSceneAsync(nameScene);
            loading.asynload.allowSceneActivation = false;
        }

        public void OnAnimationEnd()
        {
            asynload.allowSceneActivation = true;
        }
    }
}

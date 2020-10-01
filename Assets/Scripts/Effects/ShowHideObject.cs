using UnityEngine;

namespace Assets.Scripts.Effects
{
    static class ShowHideObject
    {
        private static GameObject old;

        public static void ShowNew_HideOld(GameObject newob)
        {
            if(old != null)
            {
                old.SetActive(false);
            }
            newob.SetActive(true);

            old = newob;
        }

        public static void ShowHide(GameObject ob)
        {
            ob.SetActive(!ob.activeSelf);
        }
    }
}

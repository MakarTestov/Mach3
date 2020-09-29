using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Patterns
{
    class Singleton<T> where T : new()
    {
        public T TObject;
        private Singleton()
        {
            TObject = new T();
        }

        private static Singleton<T> singleton;
        public static Singleton<T> GetSingleton()
        {
            if(singleton == null)
            {
                singleton = new Singleton<T>();
            }
            return singleton;
        }
    }
}

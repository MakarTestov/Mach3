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

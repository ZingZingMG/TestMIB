using System;
using System.Reflection;


public class Singleton<T> where T : class
{
    private static object _Syncobj = new object();
    private static volatile T _Instance = null;

    public static T Instance
    {
        get
        {
            if (_Instance == null)
            {
                CreateInstance();
            }
            return _Instance;
        }
    }

    private static void CreateInstance()
    {
        lock (_Syncobj)
        {
            if (_Instance == null)
            {
                Type t = typeof(T);

                // Ensure there are no public constructors...  
                ConstructorInfo[] ctors = t.GetConstructors();
                if (ctors.Length > 0)
                {
                    throw new InvalidOperationException(String.Format("{0} has at least one accesible ctor making it impossible to enforce singleton behaviour", t.Name));
                }

                // Create an instance via the private constructor  
                _Instance = (T)Activator.CreateInstance(t, true);
            }
        }
    }
}

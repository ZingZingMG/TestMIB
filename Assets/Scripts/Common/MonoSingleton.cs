using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{

    private static T _Instance = null;
    private static object Syncobj = new object();
    private static bool ApplsClosing = false;
    
    public static T Instance
    {
        get
        {
            if(ApplsClosing)
            {
                return null;
            }

            lock(Syncobj)
            {
                if( _Instance == null)
                {
                    T[] Objs = FindObjectsOfType<T>();

                    if( Objs.Length > 0)
                    {
                        _Instance = Objs[0];
                    }

                    if( Objs.Length > 1)
                    {
                        Debug.LogError("There is more than one " + typeof(T).Name + " in the scene.");
                    }

                    if( _Instance == null)
                    {
                        string GoName = typeof(T).ToString();
                        GameObject Go = GameObject.Find(GoName);
                        if(Go == null)
                        {
                            Go = new GameObject(GoName);
                        }

                        _Instance = Go.AddComponent<T>();
                    }
                }

                return _Instance;
            }
        }

    }
    	
    // Use this for initialization
	void Start () {
        
	}
    	
	// Update is called once per frame

	void Update () {

    }

    protected virtual void OnApplicationQuit()
    {
        // release reference on exit
        ApplsClosing = true;
    }
}

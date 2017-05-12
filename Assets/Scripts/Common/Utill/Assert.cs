﻿
using UnityEngine;
using System.Collections;

#if !UNITY_EDITOR
    #define RELEASE
#endif


#if RELEASE

#if !UNITY_EDITOR 
public static class Debug 
{ 
    [System.Diagnostics.Conditional("UNITY_EDITOR")] 
    public static void Log(object message) { } 
    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    public static void LogError(object message) { }
    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    public static void LogError(object message, Object context) { }
    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    public static void LogWarning(object message) { }    
    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    public static void Assert(bool Is) {}
    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    public static void Assert(bool Is, object message) { }
    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    public static void LogException(System.Exception exception) { }
    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    public static void LogException(System.Exception exception, Object context) { }

    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    public static void DrawLine(Vector3 start, Vector3 end) { }
    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    public static void DrawLine(Vector3 start, Vector3 end, Color color) { }
    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    public static void DrawLine(Vector3 start, Vector3 end, Color color, float duration) { }
    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    public static void DrawLine(Vector3 start, Vector3 end, Color color, float duration, bool depthTest) { }
    [System.Diagnostics.Conditional("UNITY_EDITOR")]        
    public static void DrawRay(Vector3 start, Vector3 dir) { }
    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    public static void DrawRay(Vector3 start, Vector3 dir, Color color) { }
    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    public static void DrawRay(Vector3 start, Vector3 dir, Color color, float duration) { }
    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    public static void DrawRay(Vector3 start, Vector3 dir, Color color, float duration, bool depthTest) { }
} 
#endif

public class assert
{
    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    public static void set(bool comparison, string message)
    {
    }

    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    public static void set(bool comparison)
    {
    }

    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    public static void set(object comparison, string message)
    {
    }

    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    public static void set(object comparison)
    {
    }

    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    public static void msg(string message)
    {
    }

    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    public static void msg()
    {
    }
}

#else


public class assert
{
    public static void set(bool comparison, string message)
    {
        if (comparison == false)
        {
#if UNITY_EDITOR
            Debug.LogError("Assert : " + message);
#else
            Debug.LogError("Assert : " + message + " [" + System.Environment.StackTrace + "]");
#endif
            Debug.Break();
        }
    }

    public static void set(bool comparison)
    {
        if (comparison == false)
        {
#if UNITY_EDITOR
            Debug.LogError("Assert !!");
#else
            Debug.LogError("Assert !!" + " [" + System.Environment.StackTrace + "]");
#endif
            Debug.Break();
        }
    }

    public static void set(object comparison, string message)
    {
        if (comparison == null)
        {
#if UNITY_EDITOR
            Debug.LogError("Assert : " + message);
#else
            Debug.LogError("Assert : " + message + " [" + System.Environment.StackTrace + "]");
#endif
            Debug.Break();
        }
    }

    public static void set(object comparison)
    {
        if (comparison == null)
        {
#if UNITY_EDITOR
            Debug.LogError("Assert !!");
#else
            Debug.LogError("Assert !!" + " [" + System.Environment.StackTrace + "]");
#endif
            Debug.Break();
        }
    }

    public static void msg(string message)
    {
#if UNITY_EDITOR
        Debug.LogError(message);
#else
        Debug.LogError(message + " [" + System.Environment.StackTrace + "]");
#endif
        Debug.Break();
    }

    public static void msg()
    {
#if UNITY_EDITOR
        Debug.LogError("Error~!!");
#else
        Debug.LogError("Error~!!" + " [" + System.Environment.StackTrace + "]");
#endif
        Debug.Break();
    }
}

#endif
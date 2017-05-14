using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class GlobalFunc
{
    public static GameObject Load(string path)
    {
        GameObject obj = Resources.Load<GameObject>("Prefabs/" + path);
        assert.set(obj);
        return obj;
    }

    public static void SetAlpha(Image img, float alpha)
    {
        Color c = img.color;
        c.a = alpha;
        img.color = c;
    }
}

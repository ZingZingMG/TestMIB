using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayScene : MonoBehaviour
{
    public string CardPackPath;

    [System.NonSerialized]
    protected Sprite[] CardSpriteArray;
    

    public void Init()
    {

    }

    void Awake()
    {
        CardSpriteArray = Resources.LoadAll<Sprite>(CardPackPath);
        assert.set(CardSpriteArray.Length > 0);
    }
}
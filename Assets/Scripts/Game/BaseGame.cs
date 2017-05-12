using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGame : MonoBehaviour
{
    public string CardPackPath;

    [System.NonSerialized]
    protected Sprite[] CardSpriteArray;

    void Awake()
    {
        CardSpriteArray = Resources.LoadAll<Sprite>(CardPackPath);
        assert.set(CardSpriteArray.Length > 0);
    }
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    virtual protected void Update()
    {
    }
}

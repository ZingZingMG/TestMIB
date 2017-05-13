using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SevenPokerGame : PlayScene
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
    void Start () {
		
	}
}

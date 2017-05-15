using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

abstract public class Card_Base : MonoBehaviour
{
    // Use this for initialization
    virtual protected void Start()
    {
        RectTransform rt = GetComponent<RectTransform>();
        rt.sizeDelta = GameSingleton.GetPlay().CardSize;
        
        Image img = GetComponent<Image>();
        img.sprite = GameSingleton.GetPlay().GetCardSprite(GetCardInfo());
    }

    public void SetInfo( CardInfoBase info )
    {
        GetCardInfo().Clone(info);

        Image img = GetComponent<Image>();
        img.sprite = GameSingleton.GetPlay().GetCardSprite(GetCardInfo());
    }

    abstract public CardInfoBase GetCardInfo();

    [System.NonSerialized]
    public PlayerBase TargetPlayer = null;
}

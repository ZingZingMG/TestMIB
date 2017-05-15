using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card_Trump : Card_Base
{
    public CardInfo_Trump CardInfo = new CardInfo_Trump();

    // Use this for initialization
    override protected void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {

    }

    override public CardInfoBase GetCardInfo() { return CardInfo; }
}

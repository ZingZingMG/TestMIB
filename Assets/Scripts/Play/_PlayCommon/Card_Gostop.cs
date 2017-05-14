using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_Gostop : Card_Base
{
    public CardInfo_Gostop CardInfo = new CardInfo_Gostop();

    // Use this for initialization
    override protected void Start ()
    {
        base.Start();		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    override public CardInfoBase GetCardInfo() { return CardInfo; }
}

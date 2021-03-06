﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInfoBase
{
    public CardInfo_Trump ToTrump()
    {
        assert.set(this is CardInfo_Trump);
        return this as CardInfo_Trump;
    }
    public CardInfo_Gostop ToGostop()
    {
        assert.set(this is CardInfo_Gostop);
        return this as CardInfo_Gostop;
    }    

    public bool EnableSelectBtn = false;    
    public PlayTypes.CardView CardView = PlayTypes.CardView.Back;
    public int Number = 0;


    virtual public void Clone(CardInfoBase src)
    {
        CardView = src.CardView;
        Number = src.Number;
        EnableSelectBtn = src.EnableSelectBtn;
    }   
           
}

public class CardInfo_Trump : CardInfoBase
{
    public bool EnableBackBtn = false;
    public PlayTypes.TrumpMark Mark;

    override public void Clone(CardInfoBase src)
    {
        base.Clone(src);
                
        Mark = src.ToTrump().Mark;
        EnableBackBtn = src.ToTrump().EnableBackBtn;
    }

    
}

public class CardInfo_Gostop : CardInfoBase
{
    override public void Clone(CardInfoBase src)
    {
        base.Clone(src);
    }    
}


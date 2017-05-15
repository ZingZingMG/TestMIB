using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInfoBase
{
    public bool FrontView = true;
    public int Number = 1;

    virtual public void Clone(CardInfoBase src)
    {
        FrontView = src.FrontView;
        Number = src.Number;
    }       
}

public class CardInfo_Trump : CardInfoBase
{
    public PlayTypes.TrumpMark Mark;

    override public void Clone(CardInfoBase src)
    {
        base.Clone(src);

        assert.set(src is CardInfo_Trump);
        CardInfo_Trump TrumpInfo = src as CardInfo_Trump;
        Mark = TrumpInfo.Mark;
    }

    
}

public class CardInfo_Gostop : CardInfoBase
{
    override public void Clone(CardInfoBase src)
    {
        base.Clone(src);

        assert.set(src is CardInfo_Gostop);
        CardInfo_Gostop GostopInfo = src as CardInfo_Gostop;
    }    
}


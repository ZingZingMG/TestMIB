using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInfoBase
{
    public bool FrontView = true;
    public int Number = 1;

    virtual public void Clone(CardInfoBase info)
    {
        FrontView = info.FrontView;
        Number = info.Number;
    }       
}

public class CardInfo_Trump : CardInfoBase
{
    public PlayTypes.TrumpMark Mark;

    override public void Clone(CardInfoBase info)
    {
        base.Clone(info);

        assert.set(info is CardInfo_Trump);
        CardInfo_Trump TrumpInfo = info as CardInfo_Trump;
        Mark = TrumpInfo.Mark;
    }

    
}

public class CardInfo_Gostop : CardInfoBase
{
    override public void Clone(CardInfoBase info)
    {
        base.Clone(info);

        assert.set(info is CardInfo_Gostop);
        CardInfo_Gostop GostopInfo = info as CardInfo_Gostop;
    }    
}


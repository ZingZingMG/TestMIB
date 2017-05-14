using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SevenPokerPlayer : PlayerBase
{
    

    

    override public void JoinPlayer()
    {
        base.JoinPlayer();
    }

    override public void LeavePlayer()
    {
        base.LeavePlayer();
    }

    override public void ResetPlay()
    {
        base.ResetPlay();
    }

    public void SetMode_Choice()
    {
        GetSevenPokerPlayerUI().SetMode_ChoiceUI();
    }

    public void SetMode_Play()
    {
        GetSevenPokerPlayerUI().SetMode_PlayUI();
    }

    public void SetMode_Die()
    {
        GetSevenPokerPlayerUI().SetMode_DieUI();
    }    
}

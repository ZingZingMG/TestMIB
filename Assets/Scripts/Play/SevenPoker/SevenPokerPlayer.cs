using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SevenPokerPlayer : PlayerBase
{
    public bool IsMyPlayer()
    {
        return (GameSingleton.GetPlay().ToSevenPoker().GetMyPlayer() == this);
    }

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

    public void SetStep_Player(PlayTypes.SevenPokerStep step)
    {
        GetPlayerUI().ToSevenPoker().SetStep_PlayerUI(step);
    }
}

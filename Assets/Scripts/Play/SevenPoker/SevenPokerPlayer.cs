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

    public void SetMode_Start()
    {
        GetPlayerUI().ToSevenPoker().SetMode_StartUI();
    }

    public void SetMode_Choice()
    {
        GetPlayerUI().ToSevenPoker().SetMode_ChoiceUI();
    }

    public void SetMode_Play()
    {
        GetPlayerUI().ToSevenPoker().SetMode_PlayUI();
    }

    public void SetMode_Die()
    {
        GetPlayerUI().ToSevenPoker().SetMode_DieUI();
    }    
}

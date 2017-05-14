using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SevenPokerPlayerUI : PlayerUIBase
{
    public void SetMode_StartUI()
    {
        CardSet.spacing = GameSingleton.GetPlay().GetBoard().ToSevenPoker().CardSpacing_Choice;
    }

    public void SetMode_ChoiceUI()
    {
        if( GetPlayer().ToSevenPoker().IsMyPlayer() == true )
        {
            gameObject.SetActive(false);
        }        
    }

    public void SetMode_PlayUI()
    {
        if (GetPlayer().ToSevenPoker().IsMyPlayer() == true)
        {
            gameObject.SetActive(true);
        }
        CardSet.spacing = GameSingleton.GetPlay().GetBoard().ToSevenPoker().CardSpacing_Play;
    }

    public void SetMode_DieUI()
    {
        CardSet.spacing = GameSingleton.GetPlay().GetBoard().ToSevenPoker().CardSpacing_Die;
    }
}

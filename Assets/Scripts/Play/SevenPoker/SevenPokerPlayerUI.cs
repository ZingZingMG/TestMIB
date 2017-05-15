using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SevenPokerPlayerUI : PlayerUIBase
{
    PlayTypes.SevenPokerStep CurStep = PlayTypes.SevenPokerStep.None;

    override public void AddCardClass(Card_Base cardClas)
    {
        base.AddCardClass(cardClas);
        
        if( GetPlayer().ToSevenPoker().IsMyPlayer() == true )
        {
            switch( CurStep )
            {
                case PlayTypes.SevenPokerStep.Begin:
                    {                        
                        cardClas.SetFrontView(true);
                    }
                    break;
            }
        }
    }


    public void SetMode_StartUI()
    {        
        CardSet.spacing = GameSingleton.GetPlay().GetBoard().ToSevenPoker().CardSpacing_Choice;

        CurStep = PlayTypes.SevenPokerStep.Begin;
    }

    public void SetMode_ChoiceUI()
    {
        if( GetPlayer().ToSevenPoker().IsMyPlayer() == true )
        {
            gameObject.SetActive(false);
        }

        CurStep = PlayTypes.SevenPokerStep.Choice;
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

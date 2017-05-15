using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SevenPokerPlayerUI : PlayerUIBase
{
    override protected void Awake()
    {
        base.Awake();

        MasterObject = transform.Find("CardSetBG/Master").gameObject;
        assert.set(MasterObject);
        MasterObject.SetActive(false);
    }


    // ===========================================================================
    //
    //  Card
    //
    // ===========================================================================
    override public void AddCardClass(Card_Base cardClas)
    {
        base.AddCardClass(cardClas);
        
        if( GetPlayer().ToSevenPoker().IsMyPlayer() == true )
        {
            switch( CurStep )
            {
                case PlayTypes.SevenPokerStep.Begin:
                    {
                        cardClas.SetCardView(PlayTypes.CardView.Front);
                    }
                    break;
            }
        }
    }

    // ===========================================================================
    //
    //  게임 스탭
    //
    // ===========================================================================
    PlayTypes.SevenPokerStep CurStep;

    public void SetStep_PlayerUI(PlayTypes.SevenPokerStep step)
    {
        CurStep = step;
        switch ( step )
        {
            case PlayTypes.SevenPokerStep.Begin:
                {
                    CardSet.spacing = GameSingleton.GetPlay().GetBoard().ToSevenPoker().CardSpacing_Choice;
                }
                break;
            case PlayTypes.SevenPokerStep.ChoiceCardShare_Complete:
                {
                    if (GetPlayer().ToSevenPoker().IsMyPlayer() == true)
                    {
                        gameObject.SetActive(false);
                    }
                }
                break;
            case PlayTypes.SevenPokerStep.ChoiceCardSelect:
                {
                    if (GetPlayer().ToSevenPoker().IsMyPlayer() == true)
                    {
                        gameObject.SetActive(true);

                        CardUIList[0].SetCardView(PlayTypes.CardView.Dual);
                        CardUIList[1].SetCardView(PlayTypes.CardView.Dual);
                        CardUIList[2].SetCardView(PlayTypes.CardView.Dual);
                    }

                    CardSet.spacing = GameSingleton.GetPlay().GetBoard().ToSevenPoker().CardSpacing_Play;
                }
                break;
            case PlayTypes.SevenPokerStep.CardShare_4:
                {
                    CardUIList[2].SetCardView(PlayTypes.CardView.Front);
                }
                break;
        }
    }    
}

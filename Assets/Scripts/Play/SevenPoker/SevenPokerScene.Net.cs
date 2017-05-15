using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class SevenPokerScene : PlayScene
{
    public delegate void CardShareCompleteDelegate();
    protected CardShareCompleteDelegate OnCardShareCompleteDG = null;

    Queue<CardInfo_Trump> RecvCardShareQueue = new Queue<CardInfo_Trump>();

    public void Send_PlayReady()
    {
        if( IsOnline() == false )
        {   
            List<CardInfo_Trump> cardList = new List<CardInfo_Trump>();

            for( int cardNum=0; cardNum<4; ++cardNum)
            {
                foreach(PlayerBase player in PlayerList)
                {
                    if( player.IsPlay() )
                    {
                        CardInfo_Trump cardInfo = new CardInfo_Trump();
                        cardInfo.FrontView = false;
                        cardInfo.Number = Random.Range(1, 14);
                        cardInfo.Mark = (PlayTypes.TrumpMark)Random.Range(0, 4);
                        cardList.Add(cardInfo);
                    }
                }
            }

            RecvChoiceCard(cardList);
        }
    }    

    public void RecvChoiceCard(List<CardInfo_Trump> cardList)
    {
        foreach(CardInfo_Trump info in cardList)
        {
            RecvCardShareQueue.Enqueue(info);
        }

        OnCardShareCompleteDG = Play_Choice;
        StartCoroutine("CardShareCoroutine");
    }
    
    public void Send_ChoiceComplete( int ThrowCardIndex, int OpenCardIndex )
    {
        if (IsOnline() == false)
        {
            int PlayerIndex = GameSingleton.GetPlay().ToSevenPoker().GetMyPlayer().GetPlayerIndex();
            Recv_UserChoiceComplete(PlayerIndex, ThrowCardIndex, OpenCardIndex);
        }
        else
        {

        }
    }
    
    public void Recv_UserChoiceComplete(int PlayerIndex, int ThrowCardIndex, int OpenCardIndex)
    {
        SevenPokerPlayer player = GameSingleton.GetPlay().GetPlayer(PlayerIndex).ToSevenPoker();
        if ( player.IsMyPlayer() == true )
        {
            player.CardMoveToTail(OpenCardIndex);
            player.RemoveCard_ByIndex(ThrowCardIndex);
            GameSingleton.GetPlay().GetBoard().ToSevenPoker().SetMode_Play();
        }
        else
        {
            player.RemoveCard_ByIndex(0);
        }

        player.SetMode_Play();
    }
}
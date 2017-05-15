using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class SevenPokerScene : PlayScene
{
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
                        cardInfo.CardView = PlayTypes.CardView.Back;
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
        
        StartCoroutine("CardShareCoroutine", PlayTypes.SevenPokerStep.ChoiceCardShare_Complete);
    }

    // OpenCardIndex 는 ThrowCardIndex 버리고 나서의 인덱스 계산
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


    // OpenCardIndex 는 ThrowCardIndex 버리고 나서의 인덱스 계산
    public void Recv_UserChoiceComplete(int PlayerIndex, int ThrowCardIndex, int OpenCardIndex)
    {
        SevenPokerPlayer player = GameSingleton.GetPlay().GetPlayer(PlayerIndex).ToSevenPoker();
        if ( player.IsMyPlayer() == true )
        {
            // 버림 계산 후에
            player.RemoveCard_ByIndex(ThrowCardIndex);
            // 뒤로갈 카드 계산
            player.CardMoveToTail(OpenCardIndex);            

            GameSingleton.GetPlay().GetBoard().ToSevenPoker().SetStep_Board(PlayTypes.SevenPokerStep.ChoiceCardSelect);
            player.SetStep_Player(PlayTypes.SevenPokerStep.ChoiceCardSelect);

        }
        else
        {
            player.RemoveCard_ByIndex(0);
            player.SetStep_Player(PlayTypes.SevenPokerStep.ChoiceCardSelect);
        }

        
    }
}
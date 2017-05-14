using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class SevenPokerScene : PlayScene
{
    public delegate void CardShareCompleteDelegate();
    protected CardShareCompleteDelegate OnCardShareCompleteDG = null;

    Queue<CardInfo_Trump> RecvCardShareQueue = new Queue<CardInfo_Trump>();

    public void SendReadyPlay()
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

        OnCardShareCompleteDG = OnCompleteChoiceCardShare;
        StartCoroutine("CardShareCoroutine");
    }

    public void OnCompleteChoiceCardShare()
    {
        int d = 0;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class SevenPokerScene : PlayScene
{
    
        
    IEnumerator CardShareCoroutine()
    {
        assert.set(MasterPlayer != null);
        PlayerBase CurPlayer = MasterPlayer;
        while (RecvCardShareQueue.Count>0)
        {
            CardInfo_Trump info = RecvCardShareQueue.Dequeue();

            _CardShareToPlayer(info, CurPlayer, GetSevenPokerBoard().GetDealerPosition(), 0.3f);

            yield return new WaitForSeconds(0.2f);
            CurPlayer = CurPlayer.GetNextPlayPlayer();
        }

        if( OnCardShareCompleteDG != null )
        {
            yield return new WaitForSeconds(0.1f);

            OnCardShareCompleteDG();
            OnCardShareCompleteDG = null;
        }
    }

    // ===========================================================================
    //
    //  게임 플레이
    //
    // ===========================================================================
    IEnumerator StartPlay()
    {
        // ===========================================================================
        // 게임 준비
        // ===========================================================================        
        // 카드 선택화면 비활성화
        //ChoiceCard.gameObject.SetActive(false);
        foreach (PlayerBase player in PlayerList)
        {
            assert.set(player is SevenPokerPlayer);
            player.StartPlay();

            if( player.IsPlay() )
            {                
                SevenPokerPlayer spPlayer = player as SevenPokerPlayer;
                spPlayer.SetMode_Choice();
            }            
        }

        // 1초 후에 시작
        yield return new WaitForSeconds(1.0f);

        SendReadyPlay();
    }

    //IEnumerator StartPlay()
    //{
    //    // ===========================================================================
    //    // 게임 준비
    //    // ===========================================================================        
    //    // 카드 선택화면 비활성화
    //    ChoiceCard.gameObject.SetActive(false);
    //    // User 정리 - 초기화
    //    foreach( SevenPokerUser user in UserArrayByIndex )
    //    {
    //        if (user.GetUserType() == PlayTypes.UserType.None)
    //            continue;

    //        user.ResetPlay();
    //    }

    //    // 1초 후에 시작
    //    yield return new WaitForSeconds(1.0f);

    //    // ===========================================================================
    //    // 카드 초이스         
    //    // ===========================================================================
    //    foreach (SevenPokerUser user in UserArrayByIndex)
    //    {
    //        if (user.GetUserType() == PlayTypes.UserType.None)
    //            continue;

    //        user.SetMode_Choice();
    //    }



    //    // 내가 플레이 중이라면 초이스 모드로
    //    if (IsMyTake() == true)
    //    {
    //        // 카드를 다 받을때 까지 대기
    //        //GetUser

    //        //ChoiceCard.SetMode_Choice();
    //    }

    //    // 초이스 대기
    //}
}

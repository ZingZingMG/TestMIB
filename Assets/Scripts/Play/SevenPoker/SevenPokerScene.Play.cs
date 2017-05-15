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

            _CardShareToPlayer(info, CurPlayer, GetBoard().ToSevenPoker().GetDealerPosition(), 0.3f);

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
    //  게임 플레이 : 시작
    //
    // ===========================================================================
    IEnumerator Play_Start_Coroutine()
    {
        // ===========================================================================
        // 게임 준비
        // ===========================================================================
        foreach (PlayerBase player in PlayerList)
        {
            assert.set(player is SevenPokerPlayer);
            player.StartPlay();            
        }

        GetBoard().ToSevenPoker().SetMode_Start();        

        // 1초 후에 시작
        yield return new WaitForSeconds(1.0f);

        Send_PlayReady();
    }

    // ===========================================================================
    //
    //  게임 플레이 : 4장 완료 초이스 시작
    //
    // ===========================================================================
    IEnumerator OfflineChoiceAI_Coroutine(int PlayerIndex)
    {
        float rand = Random.Range(1.0f, 3.0f);
        yield return new WaitForSeconds(rand);
        Recv_UserChoiceComplete(PlayerIndex, -1, -1);
    }

    void Play_Choice()
    {
        // 기존 다른 유저들을 랜덤하게 완료 시키자
        if( IsOnline() == false )
        {
            foreach (PlayerBase player in PlayerList)
            {
                if (player.IsPlay() && (player.ToSevenPoker().IsMyPlayer() == false))
                {
                    StartCoroutine("OfflineChoiceAI_Coroutine", player.GetPlayerIndex());                    
                }
            }
        }

        GetBoard().ToSevenPoker().SetMode_Choice();
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

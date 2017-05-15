using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class SevenPokerScene : PlayScene
{
    bool RunStepCoroutine = false;

    public void SetStep_Scene(PlayTypes.SevenPokerStep step)
    {
        // 스텝 코루틴은 한번에 하나의 코루틴만 동작하게 하자
        assert.set(RunStepCoroutine == false);
        StartCoroutine("SetStep_Scene_Coroutine", step);
    }

    IEnumerator OfflineChoiceAI_Coroutine(int PlayerIndex)
    {
        float rand = Random.Range(1.0f, 3.0f);
        yield return new WaitForSeconds(rand);
        Recv_UserChoiceComplete(PlayerIndex, -1, -1);
    }

    void _BroadCastStep(PlayTypes.SevenPokerStep step, bool Board = true, bool Player = true)
    {
        // 게임 보드 셋팅
        GetBoard().ToSevenPoker().SetStep_Board(step);
        // 플레이어들 셋팅
        foreach (PlayerBase player in PlayerList)
        {
            assert.set(player is SevenPokerPlayer);
            if (player.IsPlay())
            {
                SevenPokerPlayer spPlayer = player as SevenPokerPlayer;
                spPlayer.SetStep_Player(step);
            }
        }
    }

    IEnumerator SetStep_Scene_Coroutine( PlayTypes.SevenPokerStep step )
    {
        RunStepCoroutine = true;

        switch ( step )
        {
        // ===========================================================================
        // 게임 준비
        // ===========================================================================                   
        case PlayTypes.SevenPokerStep.Begin:
            {
                // 기존 유저를 시작 상태로 변경                
                foreach (PlayerBase player in PlayerList)
                {
                    assert.set(player is SevenPokerPlayer);
                    player.StartPlay();
                }

                _BroadCastStep(step);

                yield return new WaitForSeconds(1.0f);
                Send_PlayReady();
            }
            break;

        // ===========================================================================
        // 선택카드 배분완료
        // ===========================================================================  
        case PlayTypes.SevenPokerStep.ChoiceCardShare_Complete:
            {
                // 내가 아닌 기존 다른 유저들을 랜덤하게 완료 시키자
                if (IsOnline() == false)
                {
                    foreach (PlayerBase player in PlayerList)
                    {
                        if (player.IsPlay() && (player.ToSevenPoker().IsMyPlayer() == false))
                        {
                            StartCoroutine("OfflineChoiceAI_Coroutine", player.GetPlayerIndex());
                        }
                    }
                }

                _BroadCastStep(step);
            }
            break;

        // ===========================================================================
        // 선택카드 선택 완료
        // ===========================================================================          
        case PlayTypes.SevenPokerStep.ChoiceCardSelect:
            // Recv_UserChoiceComplete 에서 플레이어 개별적인 셋팅
            assert.set(false);
            break;

        }

        RunStepCoroutine = false;
    }

    // ===========================================================================
    //
    //  카드 배분
    //
    // ===========================================================================
    IEnumerator CardShareCoroutine(PlayTypes.SevenPokerStep CompleteStep)
    {
        PlayerBase CurPlayer = GetMasterPlayer();
        while (RecvCardShareQueue.Count > 0)
        {
            CardInfo_Trump info = RecvCardShareQueue.Dequeue();

            _CardShareToPlayer(info, CurPlayer, GetBoard().ToSevenPoker().GetDealerPosition(), 0.3f);

            yield return new WaitForSeconds(0.2f);
            CurPlayer = CurPlayer.GetNextPlayPlayer();
        }

        if (CompleteStep != PlayTypes.SevenPokerStep.None)
        {
            yield return new WaitForSeconds(0.1f);

            SetStep_Scene(CompleteStep);
        }
    }
}

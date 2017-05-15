using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBase
{
    public SevenPokerPlayer ToSevenPoker()
    {
        assert.set(this is SevenPokerPlayer);
        return this as SevenPokerPlayer;
    }

    // ===========================================================================
    //
    //  Master
    //
    // ===========================================================================
    public void SetMaster(bool master)
    {
        GetPlayerUI().SetMasterUI(master);
    }

    // ===========================================================================
    //
    //  카드
    //
    // ===========================================================================
    [System.NonSerialized]
    public List<CardInfoBase> CardList = new List<CardInfoBase>();

    //public void AddCard_ByInfo(CardInfoBase cardInfo, Transform cardSet = null)
    //{
    //    CardList.Add(cardInfo);

    //    // 카드 오브젝트 생성
    //    if( cardSet == null )
    //    {
    //        cardSet = GetPlayerUI().GetCardSet();
    //    }
    //    Card_Base cardClass = GameSingleton.GetPlay().CreateCard(cardSet, cardInfo);
    //    assert.set(cardClass);

    //    GetPlayerUI().AddCardClass(cardClass);
    //}

    public void AddCard_ByClass(Card_Base cardClass)
    {
        // 부모 연결
        cardClass.transform.SetParent(GetPlayerUI().GetCardSet());
        // 알파 변동
        GlobalFunc.SetAlpha(cardClass.GetCardImage(), 1.0f);

        CardList.Add(cardClass.GetCardInfo());
        GetPlayerUI().AddCardClass(cardClass);
    }

    public void CardMoveToTail(int CardIndex)
    {
        assert.set(CardList.Count > CardIndex && CardIndex >= 0);
        CardInfoBase info = CardList[CardIndex];
        CardList.RemoveAt(CardIndex);
        CardList.Add(info);

        GetPlayerUI().CardMoveToTail(CardIndex);
    }

    public void RemoveCard_ByIndex(int CardIndex )
    {
        assert.set(CardList.Count > CardIndex && CardIndex >= 0);
        CardList.RemoveAt(CardIndex);

        GetPlayerUI().RemoveCard_ByIndex(CardIndex);
    }

    // ===========================================================================
    //
    //  기본 플레이어 정보
    //
    // ===========================================================================
    protected int PlayerIndex = -1;
    protected PlayTypes.PlayPositionType PlayPosType = PlayTypes.PlayPositionType.None;

    public void SetPlayerIndex(int playerIndex) { PlayerIndex = playerIndex; }
    public int GetPlayerIndex() { assert.set(PlayerIndex >= 0); return PlayerIndex; }    
    public PlayTypes.PlayPositionType GetPlayPositionType() { return PlayPosType; }

    // ===========================================================================
    //
    //  UI
    //
    // ===========================================================================
    // 수동 연결 해줘야함
    protected PlayerUIBase UI = null;
    
    public void SetPlayerUI( PlayerUIBase ui) { UI = ui; UI.SetPlayer(this); }
    public PlayerUIBase GetPlayerUI() { assert.set(UI); return UI; }
    


    // ===========================================================================
    //
    //  링크 정보 : 원형으로 관리
    //
    // ===========================================================================
    protected PlayerBase NextPlayer = null;
    protected PlayerBase PrevPlayer = null;
    public void SetNextPlayer(PlayerBase next) { NextPlayer = next; }
    public void SetPrevPlayer(PlayerBase prev) { PrevPlayer = prev; }
    public PlayerBase GetNextPlayPlayer()
    {
        assert.set(NextPlayer);
        if( NextPlayer.IsPlay() == false )
        {
            return NextPlayer.GetNextPlayPlayer();
        }
        return NextPlayer;
    }

    public bool IsPlay() { return (PlayPosType == PlayTypes.PlayPositionType.Play); }

    // ===========================================================================
    //
    //  유저
    //
    // ===========================================================================

    virtual public void StartPlay()
    {
        switch(PlayPosType)
        {
        case PlayTypes.PlayPositionType.Wait:
        case PlayTypes.PlayPositionType.Die:
            PlayPosType = PlayTypes.PlayPositionType.Play;
            break;
        }
    }

    virtual public void JoinPlayer()
    {
        assert.set(PlayPosType == PlayTypes.PlayPositionType.None);
        PlayPosType = PlayTypes.PlayPositionType.Wait;

        GetPlayerUI().gameObject.SetActive(true);
        ResetPlay();
    }

    virtual public void LeavePlayer()
    {
        PlayPosType = PlayTypes.PlayPositionType.None;
        GetPlayerUI().gameObject.SetActive(false);
        GetPlayerUI().SetPlayer(null);
        UI = null;
    }

    // 한판이 종료되면 호출
    virtual public void ResetPlay()
    {
        CardList.Clear();
        GetPlayerUI().ResetPlayUI();
    }
}

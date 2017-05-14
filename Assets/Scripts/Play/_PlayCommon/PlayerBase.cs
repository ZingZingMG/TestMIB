using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBase
{
    // ===========================================================================
    //
    //  카드
    //
    // ===========================================================================
    List<CardInfoBase> CardList = new List<CardInfoBase>();

    public void AddCard_ByInfo(CardInfoBase cardInfo)
    {
        CardList.Add(cardInfo);

        // 카드 오브젝트 생성        
        GameObject cardObject = GameSingleton.GetBasePlayScene().CreateCard(GetPlayerUI().GetCardSet(), cardInfo);
        assert.set(cardObject);

        GetPlayerUI().AddCardObject(cardObject);
    }

    public void AddCard_ByGameObject(GameObject cardObject)
    {
        // 부모 연결
        cardObject.transform.SetParent(GetPlayerUI().GetCardSet());
        // 알파 변동
        GlobalFunc.SetAlpha(cardObject.GetComponent<Image>(), 1.0f);

        Card_Base card = cardObject.GetComponent<Card_Base>();
        assert.set(card);
        CardList.Add(card.GetCardInfo());

        GetPlayerUI().AddCardObject(cardObject);
    }

    // ===========================================================================
    //
    //  기본 플레이어 정보
    //
    // ===========================================================================
    protected int PositionIdx = -1;
    protected PlayTypes.PlayPositionType PlayPosType = PlayTypes.PlayPositionType.None;

    public void SetPositionIndex(int positionIdx) { PositionIdx = positionIdx; }
    public int GetPositionIndex() { assert.set(PositionIdx >= 0); return PositionIdx; }    
    public PlayTypes.PlayPositionType GetPlayPositionType() { return PlayPosType; }

    // ===========================================================================
    //
    //  UI
    //
    // ===========================================================================
    // 수동 연결 해줘야함
    protected PlayerUIBase UI = null;
    
    public void SetPlayerUI( PlayerUIBase ui) { UI = ui; }
    public PlayerUIBase GetPlayerUI() { assert.set(UI); return UI; }
    public SevenPokerPlayerUI GetSevenPokerPlayerUI() { assert.set(UI); assert.set(UI is SevenPokerPlayerUI); return UI as SevenPokerPlayerUI; }


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
        UI = null;
    }

    // 한판이 종료되면 호출
    virtual public void ResetPlay()
    {
        CardList.Clear();
        GetPlayerUI().ResetPlayUI();
    }
}

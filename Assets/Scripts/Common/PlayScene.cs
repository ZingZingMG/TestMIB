using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public abstract class PlayScene : MonoBehaviour
{    
    public void Init()
    {

    }

    virtual protected void Awake()
    {
        GameSingleton.SetPlayScene(this);

        // 보드 존재 하는지 체크
        assert.set(Board);

        // 카드팩 생성
        CardSpriteArray = Resources.LoadAll<Sprite>(CardPackPath);
        assert.set(CardSpriteArray.Length > 0);

        // 해당 플레이들을 맥스 플레이어 수만큼 미리 생성후 링크(원형)연결해둠
        PlayerBase first = null;
        PlayerBase last = null;
        for( int i=0; i<GetMaxPlayer(); ++i)
        {
            PlayerBase newPlayer = _CreatePlayer();
            PlayerList.Add(newPlayer);

            newPlayer.SetPositionIndex(i);
            if(last != null )
            {
                last.SetNextPlayer(newPlayer);
                newPlayer.SetPrevPlayer(last);
            }
            if( i == 0 )
            {
                first = newPlayer;
            }
            last = newPlayer;
        }
        assert.set(first != null);
        assert.set(last != null);
        assert.set(GetMaxPlayer() > 1);
        last.SetNextPlayer(first);
        first.SetPrevPlayer(last);

        // 일단 첫유저를 마스터 셋팅 : 서버에서 정보 받아 변경
        MasterPlayer = first;        
    }

    void OnDestroy()
    {
        GameSingleton.SetPlayScene(null);
    }

    // ===========================================================================
    //
    //  Abstract
    //
    // ===========================================================================
    abstract public int GetMaxPlayer();
    abstract protected PlayerBase _CreatePlayer();

    // ===========================================================================
    //
    //  Board
    //
    // ===========================================================================
    // MainCanvas 에 붙여서 해당 보드를 관리 - Editor에서 연결
    public BoardBase Board;

    public BoardBase GetBoardBase() { assert.set(Board); return Board; }
    public SevenPokerBoard GetSevenPokerBoard() { assert.set(Board); assert.set(Board is SevenPokerBoard); return Board as SevenPokerBoard; }

    // ===========================================================================
    //
    //  Player
    //
    // ===========================================================================
    // 게임에 참여 중인 유저 ( 관전자, 중도참가 관전자 미포함 )
    protected List<PlayerBase> PlayerList = new List<PlayerBase>();
    // 마스터플레이어 (선)
    protected PlayerBase MasterPlayer = null;
    // 내가 관전 중인가
    public bool ObserverMode = false;

    // 내가 플레이 중이라면
    public bool IsObserverMode() { return ObserverMode; }
    public PlayerBase GetPlayer(int PlayerIndex) { return PlayerList[PlayerIndex]; }
    public SevenPokerPlayer GetSevenPokerPlayer(int PlayerIndex) { assert.set(PlayerList[PlayerIndex] is SevenPokerPlayer); return PlayerList[PlayerIndex] as SevenPokerPlayer; }


    // ===========================================================================
    //
    //  Card
    //
    // ===========================================================================
    // 로드해야하는 카드팩 경로
    [SerializeField]
    protected string CardPackPath;

    // 해당 카드팩으로 부터 배열로 이미지 저장
    [System.NonSerialized]
    protected Sprite[] CardSpriteArray;

    // 해당 카드의 사이즈 - 이 사이즈에 맞춰서 모든 인터페이스 사이즈를 조절해준다.
    public Vector2 CardSize;

    public GameObject CreateCard(Transform parent, CardInfoBase cardInfo)
    {
        GameObject CardObject = null;
        if (cardInfo is CardInfo_Trump)
        {
            GameObject prefab = GlobalFunc.Load("Play/_PlayCommon/TrumpCard");
            CardObject = Instantiate<GameObject>(prefab, parent);
            assert.set(CardObject);

            Card_Trump newCardClass = CardObject.GetComponent<Card_Trump>();
            newCardClass.CardInfo.Clone(cardInfo);
        }
        else
        {
            assert.set(cardInfo is CardInfo_Gostop);
            GameObject prefab = GlobalFunc.Load("Play/_PlayCommon/GostopCard");
            CardObject = Instantiate<GameObject>(prefab, parent);
            assert.set(CardObject);

            Card_Gostop newCardClass = CardObject.GetComponent<Card_Gostop>();
            newCardClass.CardInfo.Clone(cardInfo);
        }

        assert.set(CardObject);
        return CardObject;
    }

    public GameObject CreateBoardCard(CardInfoBase cardInfo, Vector3 Position, float Alpha = 1.0f)
    {        
        GameObject CardObject = CreateCard(GetBoardBase().transform, cardInfo);
        assert.set(CardObject);
        CardObject.transform.position = Position;
        if(Alpha < 1.0f )
        {
            GlobalFunc.SetAlpha(CardObject.GetComponent<Image>(), Alpha);
        }

        return CardObject;
    }

    public Sprite GetCardSprite(CardInfoBase cardInfo)
    {
        assert.set(cardInfo.Number != 0);
        int SpriteIdx = 0;
        if( cardInfo is CardInfo_Trump )
        {
            CardInfo_Trump TrumpInfo = cardInfo as CardInfo_Trump;
            SpriteIdx = (int)TrumpInfo.Mark * 13 + TrumpInfo.Number - 1;
        }
        else
        {
            assert.set(cardInfo is CardInfo_Gostop);
            assert.set(false);
        }

        assert.set(SpriteIdx >= 0);
        assert.set(SpriteIdx < CardSpriteArray.Length);
        return CardSpriteArray[SpriteIdx];
    }

    // ===========================================================================
    //
    //  Card
    //
    // ===========================================================================

    virtual public void OnCompleteCardShareToPlayer(Card_Base cardObject)
    {
        assert.set(cardObject.TargetPlayer);
        cardObject.TargetPlayer.AddCard_ByGameObject(cardObject.gameObject);
    }
    
    protected void _CardShareToPlayer( CardInfoBase info, PlayerBase player, Vector3 Start, float time, iTween.EaseType easeType = iTween.EaseType.easeOutQuad)
    {
        GameObject newCardObject = CreateBoardCard(info, GetSevenPokerBoard().GetDealerPosition(), 0.3f);
        Card_Base newCard = newCardObject.GetComponent<Card_Base>();
        newCard.TargetPlayer = player;

        iTween.MoveTo(newCardObject,
                        iTween.Hash("position", player.GetPlayerUI().GetNextCardPosition(),
                                    "easetype", easeType,
                                    "oncomplete", "OnCompleteCardShareToPlayer",
                                    "oncompletetarget", gameObject,
                                    "oncompleteparams", newCard,
                                    "time", time)
                       );
    }    
}
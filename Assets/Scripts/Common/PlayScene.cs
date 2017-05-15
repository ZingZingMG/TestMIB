using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public abstract class PlayScene : MonoBehaviour
{
    public SevenPokerScene ToSevenPoker()
    {
        assert.set(this is SevenPokerScene);
        return this as SevenPokerScene;
    }


    public void Init()
    {

    }

    virtual protected void Awake()
    {
        GameSingleton.SetPlay(this);

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

            newPlayer.SetPlayerIndex(i);
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
    }

    void OnDestroy()
    {
        GameSingleton.SetPlay(null);
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
    public BoardBase GetBoard() { assert.set(Board); return Board; }    

    // ===========================================================================
    //
    //  Player
    //
    // ===========================================================================
    // 게임에 참여 중인 유저
    protected List<PlayerBase> PlayerList = new List<PlayerBase>();
    // 마스터플레이어 (선)
    private PlayerBase MasterPlayer = null;
    // 내가 관전 중인가
    public bool ObserverMode = false;

    // 내가 플레이 중이라면
    public bool IsObserverMode() { return ObserverMode; }
    public PlayerBase GetPlayer(int PlayerIndex) { return PlayerList[PlayerIndex]; }
    public List<PlayerBase> GetPlayerList() { return PlayerList; }

    public PlayerBase GetMasterPlayer()
    {
        assert.set(MasterPlayer);
        return MasterPlayer;
    }
    public void SetMasterPlayer( PlayerBase masterPlayer )
    {
        if( MasterPlayer != null )
        {
            MasterPlayer.SetMaster(false);
        }
        MasterPlayer = masterPlayer;
        MasterPlayer.SetMaster(true);
    }

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

    public Card_Base CreateCard(Transform parent, CardInfoBase cardInfo)
    {
        Card_Base CardClass = null;
        if (cardInfo is CardInfo_Trump)
        {
            GameObject prefab = GlobalFunc.Load("Play/_PlayCommon/TrumpCard");
            GameObject CardObject = Instantiate<GameObject>(prefab, parent);
            assert.set(CardObject);

            Card_Trump newCardClass = CardObject.GetComponent<Card_Trump>();
            newCardClass.CardInfo.Clone(cardInfo);

            CardClass = newCardClass;
        }
        else
        {
            assert.set(cardInfo is CardInfo_Gostop);
            GameObject prefab = GlobalFunc.Load("Play/_PlayCommon/GostopCard");
            GameObject CardObject = Instantiate<GameObject>(prefab, parent);
            assert.set(CardObject);

            Card_Gostop newCardClass = CardObject.GetComponent<Card_Gostop>();
            newCardClass.CardInfo.Clone(cardInfo);

            CardClass = newCardClass;
        }

        assert.set(CardClass);
        return CardClass;
    }

    public Card_Base CreateBoardCard(CardInfoBase cardInfo, Vector3 Position, float Alpha = 1.0f)
    {
        Card_Base CardClass = CreateCard(GetBoard().transform, cardInfo);
        assert.set(CardClass);
        CardClass.transform.position = Position;
        if(Alpha < 1.0f )
        {
            GlobalFunc.SetAlpha(CardClass.GetCardImage(), Alpha);
        }

        return CardClass;
    }

    public Sprite GetCardSprite(CardInfoBase cardInfo)
    {
        assert.set(cardInfo.Number != 0);
        int SpriteIdx = 0;
        if( cardInfo is CardInfo_Trump )
        {
            if( cardInfo.CardView == PlayTypes.CardView.Back )
            {
                SpriteIdx = 12; 
            }
            else
            {
                // 정면을 보여주기로 하였지만 카드내용이 기입되지 아니함
                assert.set(cardInfo.ToTrump().Number > 0);
                SpriteIdx = (int)cardInfo.ToTrump().Mark * 13 + cardInfo.ToTrump().Number - 1;
            }            
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

    virtual public void OnCompleteCardShareToPlayer(Card_Base cardClass)
    {
        assert.set(cardClass.TargetPlayer);
        cardClass.TargetPlayer.AddCard_ByClass(cardClass);
    }
    
    protected void _CardShareToPlayer( CardInfoBase info, PlayerBase player, Vector3 Start, float time, iTween.EaseType easeType = iTween.EaseType.easeOutQuad)
    {
        Card_Base newCardClass = CreateBoardCard(info, Start, 0.3f);
        newCardClass.TargetPlayer = player;

        iTween.MoveTo(  newCardClass.gameObject,
                        iTween.Hash("position", player.GetPlayerUI().GetNextCardPosition(),
                                    "easetype", easeType,
                                    "oncomplete", "OnCompleteCardShareToPlayer",
                                    "oncompletetarget", gameObject,
                                    "oncompleteparams", newCardClass,
                                    "time", time)
                       );
    }    
}
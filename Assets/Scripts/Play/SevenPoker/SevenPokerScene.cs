using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class OfflineUserInfo
{
    public int PositionIndex;
    public int ID;
    public string Name;
}

public partial class SevenPokerScene : PlayScene
{
    // ===========================================================================
    //
    //  Offline
    //
    // ===========================================================================
    public bool Online = false;
    public OfflineUserInfo[] UserInfoArray;
    public OfflineUserInfo MyInfo;    

    public bool IsOnline() { return Online; }

    // ===========================================================================
    //
    //  Abstract
    //
    // ===========================================================================
    override public int GetMaxPlayer() { return (int)GlobalTypes.MaxPlayer.SevenPoker; }
    override protected PlayerBase _CreatePlayer()
    {
        return new SevenPokerPlayer();
    }

    

    override protected void Awake()
    {
        base.Awake();
    }

    void OnDestroy()
    {
        OnCardShareCompleteDG = null;
    }

    // Use this for initialization
    void Start ()
    {
        // 입장 후 내 Player 셋팅
        if (IsObserverMode() == false)
        {
            GetSevenPokerBoard().LinkPlayerUI(MyInfo.PositionIndex);

            MyPlayer = GetSevenPokerPlayer(MyInfo.PositionIndex);
            MyPlayer.JoinPlayer();
        }
        else
        {
            GetSevenPokerBoard().LinkPlayerUI(0);
            assert.set(MyPlayer == null);
        }

        // 다른 유저 플레이어 셋팅
        foreach (OfflineUserInfo info in UserInfoArray)
        {
            GetPlayer(info.PositionIndex).JoinPlayer();
        }

        StartCoroutine("StartPlay");
	}

    // ===========================================================================
    //
    //  플레이어
    //
    // ===========================================================================
    SevenPokerPlayer MyPlayer = null;
    public SevenPokerPlayer GetMyPlayer() { return MyPlayer; }
}

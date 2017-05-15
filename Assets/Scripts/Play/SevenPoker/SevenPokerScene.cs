using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class OfflineUserInfo
{
    public int PlayerIndex;
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

    
    // Use this for initialization
    void Start ()
    {
        // 입장 후 내 Player 셋팅
        if (IsObserverMode() == false)
        {
            GetBoard().ToSevenPoker().LinkPlayerUI(MyInfo.PlayerIndex);

            MyPlayer = GetPlayer(MyInfo.PlayerIndex).ToSevenPoker();
            MyPlayer.JoinPlayer();
        }
        else
        {
            GetBoard().ToSevenPoker().LinkPlayerUI(0);
            assert.set(MyPlayer == null);
        }

        // 다른 유저 플레이어 셋팅
        foreach (OfflineUserInfo info in UserInfoArray)
        {
            GetPlayer(info.PlayerIndex).JoinPlayer();
        }

        // 일단 첫유저를 마스터 셋팅 : 서버에서 정보 받아 변경
        foreach(PlayerBase player in PlayerList )
        {
            if(player.GetPlayPositionType() == PlayTypes.PlayPositionType.Wait)
            {
                SetMasterPlayer(player);
                break;
            }
        }


        SetStep_Scene(PlayTypes.SevenPokerStep.Begin);
	}

    // ===========================================================================
    //
    //  플레이어
    //
    // ===========================================================================
    SevenPokerPlayer MyPlayer = null;
    public SevenPokerPlayer GetMyPlayer() { return MyPlayer; }
}

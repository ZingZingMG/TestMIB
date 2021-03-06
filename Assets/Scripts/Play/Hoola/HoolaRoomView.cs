﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HoolaRoomView : PokerRoomView
{
    public override void OnClickTotalRoom()
    {
        Debug.Log("OnClickTotalRoom");
    }

    public override void OnClickDirectJoinAbleRoom()
    {
        Debug.Log("OnClickDirectJoinAbleRoom");
    }


    // Room Filter Menu
    public override void OnClickRoomFilterTitle()
    {
        Debug.Log("OnClickRoomFilterTitle");
    }

    public override void OnClickRoomFilterRule()
    {
        Debug.Log("OnClickRoomFilterRule");
    }

    public override void OnClickRoomFilterUserCnt()
    {
        Debug.Log("OnClickRoomFilterUserCnt");
    }

    public void OnClickRoomFilterGamePrice()
    {
        Debug.Log("OnClickRoomFilterGamePrice");
    }

    public void OnClickRoomFilterBetting()
    {
        Debug.Log("OnClickRoomFilterBetting");
    }
}
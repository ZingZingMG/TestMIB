using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PokerRoomView : MonoBehaviour
{
    public virtual void OnClickTotalRoom()
    {
        Debug.Log("OnClickTotalRoom");
    }

    public virtual void OnClickDirectJoinAbleRoom()
    {
        Debug.Log("OnClickDirectJoinAbleRoom");
    }


    // Room Filter Menu
    public virtual void OnClickRoomFilterTitle()
    {
        Debug.Log("OnClickRoomFilterTitle");
    }

    public virtual void OnClickRoomFilterRule()
    {
        Debug.Log("OnClickRoomFilterRule");
    }

    public virtual void OnClickRoomFilterUserCnt()
    {
        Debug.Log("OnClickRoomFilterUserCnt");
    }
}
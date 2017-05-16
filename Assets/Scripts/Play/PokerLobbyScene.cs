using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PokerLobbyScene : LobbyScene
{
    public GameObject ChannelViewGameObj;

    void Awake()
    {
        if( ChannelViewGameObj != null)
        {
            ChannelViewGameObj.SetActive(false);
        }
    }

    public virtual void OnClickChangeChannel()
    {
        Debug.Log("OnClickChangeChannel");

        if( ChannelViewGameObj != null)
        {
            ChannelViewGameObj.SetActive(true);
            PokerChannelView View = GetComponent<PokerChannelView>();
            assert.set(View, "View");
            View.Open();
        }
    }

    public virtual void OnClickDirectJoinRoom()
    {
        Debug.Log("OnClickDirectJoinRoom");
    }

    public virtual void OnClickSelectJoinRoom()
    {
        Debug.Log("OnClickSelectJoinRoom");
    }
}
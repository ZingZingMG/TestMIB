using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PokerLobbyScene : LobbyScene
{
    public GameObject ChannelViewGameObj;

    void Awake()
    {
        assert.set(ChannelViewGameObj, "ChannelViewGameObj");
        ChannelViewGameObj.SetActive(false);
    }

    public virtual void OnClickChangeChannel()
    {
        Debug.Log("OnClickChangeChannel");

        ChannelViewGameObj.SetActive(!ChannelViewGameObj.activeSelf);
        PokerChannelView View = GetComponent<PokerChannelView>();
        assert.set(View, "View");

        if (ChannelViewGameObj.activeSelf)
        {
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
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

    
}
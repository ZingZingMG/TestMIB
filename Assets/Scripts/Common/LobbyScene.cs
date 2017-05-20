using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LobbyScene : MonoBehaviour
{
    public MakeRoomDlg MakeRoomDialog;
    public SelectRoomDlg SelectRoomDialog;

    void Awake()
    {
        assert.set(MakeRoomDialog, "MakeRoomDialog");
        MakeRoomDialog.gameObject.SetActive(false);

        assert.set(SelectRoomDialog, "SelectRoomDialog");
        SelectRoomDialog.gameObject.SetActive(false);
    }

    public void Init()
    {

    }

    public virtual void OnClickMakeRoom()
    {
        MakeRoomDialog.Open();
    }

    public virtual void OnClickDirectJoinRoom()
    {
        Debug.Log("OnClickDirectJoinRoom");
    }

    public virtual void OnClickSelectJoinRoom()
    {
        SelectRoomDialog.Open();
    }
}
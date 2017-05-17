using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LobbyScene : MonoBehaviour
{
    public MakeRoomDlg MakeRoomDialog;

    void Awake()
    {
        assert.set(MakeRoomDialog, "MakeRoomDialog");
        MakeRoomDialog.gameObject.SetActive(false);
    }

    public void Init()
    {

    }

    public void OnClickMakeRoom()
    {
        MakeRoomDialog.Open();
    }
}
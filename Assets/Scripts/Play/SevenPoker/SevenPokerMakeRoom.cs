using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class SevenPokerMakeRoom : MakeRoomDlg
{
    public InputField RoomTitleInputFiled;
    public Dropdown RoomTitleDropdownList;

    void Awake()
    {
        assert.set(RoomTitleInputFiled, "RoomTitleInputFiled");

        assert.set(RoomTitleDropdownList, "RoomTitleDropdownList");
        RoomTitleDropdownList.gameObject.SetActive(true);
    }

    public void OnRoomTitleEditChange(string Value)
    {

    }

    public void OnRoomTitleEditChangeEnd(string Value)
    {

    }

    public void OnClickRoomTitleDropdownList()
    {
        RoomTitleDropdownList.Show();
    }

    public void OnRoomTitleDropdownListValueChange(int Index)
    {
        Dropdown.OptionData SelectOptionData = RoomTitleDropdownList.options[Index];
        if( SelectOptionData.text != "")
        {
            RoomTitleInputFiled.text = SelectOptionData.text;
        }
    }

    public void OnUserCntDropdownListValueChange(int Index)
    {

    }

    public void OnJoinGradeDropdownListValueChange(int Index)
    {

    }

    public void OnBBingValueDropdownListValueChange(int Index)
    {

    }

    public void OnGameRuleDropdownListValueChange(int Index)
    {

    }

    public void OnClickMakeOK()
    {

    }

    public void OnClickMakeCancel()
    {
        Close();
    }
}
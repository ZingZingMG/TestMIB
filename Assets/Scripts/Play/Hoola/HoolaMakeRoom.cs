using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class HoolaMakeRoom : PokerMakeRoom
{
    public Dropdown CalculateTypeDowndownList;
    public Dropdown GameMoneyRankTypeDropdownList;
    public Dropdown GameMoneyPointTypeDropdownList;

    void Awake()
    {
        assert.set(CalculateTypeDowndownList, "GameMoneyRankTypeDropdownList");
        assert.set(GameMoneyRankTypeDropdownList, "GameMoneyRankTypeDropdownList");
        GameMoneyRankTypeDropdownList.gameObject.SetActive(true);
        assert.set(GameMoneyPointTypeDropdownList, "GameMoneyPointTypeDropdownList");
        GameMoneyPointTypeDropdownList.gameObject.SetActive(false);
    }

    public void OnUserCntDropdownListValueChange(int Index)
    {

    }

    public void OnCalcuateTypeDropdownListValueChange(int Index)
    {
        GameMoneyRankTypeDropdownList.gameObject.SetActive(false);
        GameMoneyRankTypeDropdownList.Hide();
        GameMoneyPointTypeDropdownList.gameObject.SetActive(false);
        GameMoneyPointTypeDropdownList.Hide();
        if ( Index == 0 )
        {
            GameMoneyRankTypeDropdownList.gameObject.SetActive(true);
        }
        else if (Index == 1)
        {
            GameMoneyPointTypeDropdownList.gameObject.SetActive(true);
        }
    }

    public void OnGameMoneyDropdownListValueChange(int Index)
    {

    }

    public void OnJoinGradeDropdownListValueChange(int Index)
    {

    }

    public void OnRoomTypeDropdownListValueChange(int Index)
    {

    }

    public void OnPlayTypeDropdownListValueChange(int Index)
    {

    }

    public void OnJokerTypeDropdownListValueChange(int Index)
    {

    }
}
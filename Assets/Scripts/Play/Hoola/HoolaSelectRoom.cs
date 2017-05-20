using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class HoolaSelectRoom : SelectRoomDlg
{
    public Dropdown GradeDropdownList;
    public Text GradeSelectText;

    public Dropdown RoomTypeDropdownList;
    public Text RoomTypeSelectText;

    public Dropdown CalculateTypeDropdownList;
    public Text CalculateTypeSelectText;

    public Dropdown GameMoneyRankDropdownList;
    public Dropdown GameMoneyPointDropdownList;
    public Text GameMoneySelectText;

    public Dropdown GameRuleDropdownList;
    public Text GameRuleSelectText;

    public Dropdown JokerDowndownList;
    public Text JokerSelectText;

    void Awake()
    {
        assert.set(GradeDropdownList, "GradeDropdownList");
        assert.set(GradeSelectText, "GradeSelectText");
        GradeSelectText.text = GradeDropdownList.options[0].text;

        assert.set(RoomTypeDropdownList, "RoomTypeDropdownList");
        assert.set(RoomTypeSelectText, "RoomTypeSelectText");
        RoomTypeSelectText.text = RoomTypeDropdownList.options[0].text;

        assert.set(CalculateTypeDropdownList, "CalculateTypeDropdownList");
        assert.set(CalculateTypeSelectText, "CalculateTypeSelectText");
        CalculateTypeSelectText.text = CalculateTypeDropdownList.options[0].text;

        assert.set(GameMoneyRankDropdownList, "GameMoneyRankDropdownList");
        assert.set(GameMoneyPointDropdownList, "GameMoneyPointDropdownList");
        assert.set(GameMoneySelectText, "GameMoneySelectText");
        GameMoneyPointDropdownList.gameObject.SetActive(false);
        GameMoneySelectText.text = GameMoneyRankDropdownList.options[0].text;

        assert.set(GameRuleDropdownList, "GameRuleDropdownList");
        assert.set(GameRuleSelectText, "GameRuleSelectText");
        GameRuleSelectText.text = GameRuleDropdownList.options[0].text;

        assert.set(JokerDowndownList, "JokerDowndownList");
        assert.set(JokerSelectText, "JokerSelectText");
        JokerSelectText.text = JokerDowndownList.options[0].text;
    }

    public void OnClickGrade()
    {
        GradeDropdownList.gameObject.SetActive(true);
        GradeDropdownList.Show();
    }

    public void OnGradeDropdownListValueChange(int Index)
    {
        GradeSelectText.text = GradeDropdownList.options[Index].text;
    }

    public void OnClickRoomType()
    {
        RoomTypeDropdownList.gameObject.SetActive(true);
        RoomTypeDropdownList.Show();
    }

    public void OnRoomTypeDropdownListValueChange(int Index)
    {
        RoomTypeSelectText.text = RoomTypeDropdownList.options[Index].text;
    }

    public void OnClickCalculateTyp()
    {
        CalculateTypeDropdownList.gameObject.SetActive(true);
        CalculateTypeDropdownList.Show();
    }

    public void OnCalculateTypDropdownListValueChange(int Index)
    {
        CalculateTypeSelectText.text = CalculateTypeDropdownList.options[Index].text;

        if( Index == 0 )
        {
            GameMoneyRankDropdownList.gameObject.SetActive(true);
            GameMoneyPointDropdownList.gameObject.SetActive(false);
            GameMoneySelectText.text = GameMoneyRankDropdownList.options[GameMoneyRankDropdownList.value].text;
        }
        else if (Index == 1)
        {
            GameMoneyRankDropdownList.gameObject.SetActive(false);
            GameMoneyPointDropdownList.gameObject.SetActive(true);
            GameMoneySelectText.text = GameMoneyPointDropdownList.options[GameMoneyPointDropdownList.value].text;
        }
    }

    public void OnClickGameMoney()
    {
        if (CalculateTypeDropdownList.value == 0)
        {
            GameMoneyRankDropdownList.Show();
        }
        else if (CalculateTypeDropdownList.value == 1)
        {
            GameMoneyPointDropdownList.Show();
        }
            
    }

    public void OnGameMoneyDropdownListValueChange(int Index)
    {
        if (CalculateTypeDropdownList.value == 0)
        {
            GameMoneySelectText.text = GameMoneyRankDropdownList.options[Index].text;
        }
        else if (CalculateTypeDropdownList.value == 1)
        {
            GameMoneySelectText.text = GameMoneyPointDropdownList.options[Index].text;
        }
    }

    public void OnClickGameRule()
    {
        GameRuleDropdownList.gameObject.SetActive(true);
        GameRuleDropdownList.Show();
    }

    public void OnGameRuleDropdownListValueChange(int Index)
    {
        GameRuleSelectText.text = GameRuleDropdownList.options[Index].text;
    }

    public void OnClickJoker()
    {
        JokerDowndownList.gameObject.SetActive(true);
        JokerDowndownList.Show();
    }

    public void OnJokerDropdownListValueChange(int Index)
    {
        JokerSelectText.text = JokerDowndownList.options[Index].text;
    }
}
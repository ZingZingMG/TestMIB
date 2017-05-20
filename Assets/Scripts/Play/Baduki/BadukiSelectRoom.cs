using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class BadukiSelectRoom : SelectRoomDlg
{
    public Dropdown GradeDropdownList;
    public Text GradeSelectText;

    public Dropdown BBingValueDropdownList;
    public Text BBingValueSelectText;

    public Dropdown GameRuleDropdownList;
    public Text GameRuleSelectText;

    public Dropdown JoinUserCntDowndownList;
    public Text JoinUserCntSelectText;


    void Awake()
    {
        assert.set(GradeDropdownList, "GradeDropdownList");
        assert.set(GradeSelectText, "GradeSelectText");
        GradeSelectText.text = GradeDropdownList.options[0].text;

        assert.set(BBingValueDropdownList, "BBingValueDropdownList");
        assert.set(BBingValueSelectText, "BBingValueSelectText");
        BBingValueSelectText.text = BBingValueDropdownList.options[0].text;

        assert.set(GameRuleDropdownList, "GameRuleDropdownList");
        assert.set(GameRuleSelectText, "GameRuleSelectText");
        GameRuleSelectText.text = GameRuleDropdownList.options[0].text;

        assert.set(JoinUserCntDowndownList, "JoinUserCntDowndownList");
        assert.set(JoinUserCntSelectText, "JoinUserCntSelectText");
        JoinUserCntSelectText.text = JoinUserCntDowndownList.options[0].text;
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

    public void OnClickBBingValue()
    {
        BBingValueDropdownList.gameObject.SetActive(true);
        BBingValueDropdownList.Show();
    }

    public void OnBBingValueDropdownListValueChange(int Index)
    {
        BBingValueSelectText.text = BBingValueDropdownList.options[Index].text;
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

    public void OnClickJoinUserCnt()
    {
        JoinUserCntDowndownList.gameObject.SetActive(true);
        JoinUserCntDowndownList.Show();
    }

    public void OnJoinUserCntDropdownListValueChange(int Index)
    {
        JoinUserCntSelectText.text = JoinUserCntDowndownList.options[Index].text;
    }
}
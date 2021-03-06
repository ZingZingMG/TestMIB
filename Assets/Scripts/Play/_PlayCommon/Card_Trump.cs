﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card_Trump : Card_Base
{    
    public CardInfo_Trump CardInfo = new CardInfo_Trump();
    GameObject BackBtn;
    GameObject CardMask;

    override protected void Awake()
    {
        base.Awake();

        BackBtn = transform.Find("Image/BackBtn").gameObject;
        assert.set(BackBtn);

        CardMask = transform.Find("Image/Mask").gameObject;
        assert.set(CardMask);
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();

        OnBackBtn = null;
    }

    public void SetEnableBackBtn(bool enable)
    {
        if (GetCardInfo().ToTrump().EnableBackBtn == enable)
        {
            return;
        }

        GetCardInfo().ToTrump().EnableBackBtn = enable;
        _ApplyCardInfo();
    }


    override public CardInfoBase GetCardInfo() { return CardInfo; }
    override protected void _ApplyCardInfo()
    {
        base._ApplyCardInfo();

        BackBtn.SetActive(GetCardInfo().ToTrump().EnableBackBtn);
        CardMask.SetActive(GetCardInfo().CardView == PlayTypes.CardView.Dual);
    }

   

    // ===========================================================================
    //
    //  Button
    //
    // ===========================================================================
    public delegate void DelegateBackBtn(int value);
    DelegateBackBtn OnBackBtn = null;
    int BackBtnValue;

    public void SetBackBtnDelegate(DelegateBackBtn dg, int val)
    {
        OnBackBtn = new DelegateBackBtn(dg);
        BackBtnValue = val;
    }

    public void OnClick_BackBtn()
    {
        if (OnBackBtn != null)
        {
            OnBackBtn(BackBtnValue);
        }
    }
}

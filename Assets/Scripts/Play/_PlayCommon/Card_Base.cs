using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

abstract public class Card_Base : MonoBehaviour
{
    public Card_Trump ToTrump()
    {
        assert.set(this is Card_Trump);
        return this as Card_Trump;
    }
    public Card_Gostop ToGostop()
    {
        assert.set(this is Card_Gostop);
        return this as Card_Gostop;
    }    

    Image CardImage;
    Button SelectBtn;

    virtual protected void Awake()
    {
        CardImage = transform.Find("Image").GetComponent<Image>();
        assert.set(CardImage);

        SelectBtn = transform.Find("SelectBtn").GetComponent<Button>();
        assert.set(SelectBtn);
    }

    // Use this for initialization
    virtual protected void Start()
    {
        RectTransform rt = GetComponent<RectTransform>();
        rt.sizeDelta = GameSingleton.GetPlay().CardSize;

        _ApplyCardInfo();
    }

    virtual protected void OnDestroy()
    {
        OnSelectBtn = null;
    }

    public void SetInfo( CardInfoBase info )
    {
        GetCardInfo().Clone(info);

        _ApplyCardInfo();
    }

    public void SetFrontView(bool frontView)
    {
        if( GetCardInfo().FrontView == frontView )
        {
            return;
        }

        GetCardInfo().FrontView = frontView;
        _ApplyCardInfo();        
    }

    public void SetEnableSelectBtn(bool enable)
    {
        if (GetCardInfo().EnableSelectBtn == enable)
        {
            return;
        }

        GetCardInfo().EnableSelectBtn = enable;
        _ApplyCardInfo();
    }

    public Image GetCardImage() { return CardImage; }
    abstract public CardInfoBase GetCardInfo();
    virtual protected void _ApplyCardInfo()
    {
        CardImage.sprite = GameSingleton.GetPlay().GetCardSprite(GetCardInfo());

        if (GetCardInfo().EnableSelectBtn == true)
        {
            SelectBtn.gameObject.SetActive(true);
            GetCardImage().raycastTarget = false;
        }
        else
        {
            SelectBtn.gameObject.SetActive(false);
            GetCardImage().raycastTarget = true;
        }        
    }

    [System.NonSerialized]
    public PlayerBase TargetPlayer = null;


    // ===========================================================================
    //
    //  Button
    //
    // ===========================================================================
    public delegate void DelegateSelectBtn(int value);
    DelegateSelectBtn OnSelectBtn = null;
    int SelectBtnValue;

    public void SetSelectBtnDelegate(DelegateSelectBtn dg, int val)
    {
        OnSelectBtn = new DelegateSelectBtn(dg);
        SelectBtnValue = val;
    }

    public void OnClick_SelectBtn()
    {
        if(OnSelectBtn != null)
        {
            OnSelectBtn(SelectBtnValue);
        }
    }
}

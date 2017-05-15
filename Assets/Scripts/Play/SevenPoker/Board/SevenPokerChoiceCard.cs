using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SevenPokerChoiceCard : MonoBehaviour
{
    GameObject ThrowText;
    GameObject OpenText;
    Transform CardSetTr;

    enum eCHOICE_STEP
    {
        None,
        ThrowSelect,
        ViewSelect,
    }
    eCHOICE_STEP CurStep;
    int ThrowSelectIndex;
    int ViewSelectIndex;

    List<Card_Base> CardList = new List<Card_Base>();

    void Awake()
    {
        ThrowText = transform.Find("ThrowText").gameObject;
        OpenText = transform.Find("OpenText").gameObject;
        CardSetTr = transform.Find("CardSet");
    }

    public void EnableChoice()
    {
        CurStep = eCHOICE_STEP.None;
        ViewSelectIndex = -1;
        ThrowSelectIndex = -1;
        gameObject.SetActive(true);
        ThrowText.SetActive(true);
        OpenText.SetActive(false);

        for( int i=CardList.Count-1; i>=0; --i )
        {
            Destroy(CardList[i].gameObject);
        }
        CardList.Clear();

        PlayerBase player = GameSingleton.GetPlay().ToSevenPoker().GetMyPlayer();
        var list = player.CardList;
        assert.set(list.Count == 4);
        for( int i=0; i<list.Count; ++i )
        {
            CardInfo_Trump info = new CardInfo_Trump();
            info.Clone(list[i]);
            info.EnableSelectBtn = true;
                                    
            Card_Base cardClass = GameSingleton.GetPlay().CreateCard(CardSetTr, info);
            cardClass.SetSelectBtnDelegate(OnClick_ChoiceCard, i);
            cardClass.ToTrump().SetBackBtnDelegate(OnClick_ChoiceCard, i);                        
            CardList.Add(cardClass);
        }              
    }

    public void DisableChoice()
    {
        gameObject.SetActive(false);
    }

    public void OnClick_ChoiceCard(int ChoiceIndex)
    {
        assert.set(ChoiceIndex < 4);
        assert.set(ChoiceIndex >= 0);

        switch (CurStep)
        {
            case eCHOICE_STEP.None:
                {
                    CurStep = eCHOICE_STEP.ThrowSelect;
                    ThrowSelectIndex = ChoiceIndex;

                    Card_Base cardClass = CardList[ChoiceIndex];

                    cardClass.SetFrontView(false);
                    cardClass.SetEnableSelectBtn(false);
                    cardClass.ToTrump().SetEnableBackBtn(true);

                    ThrowText.SetActive(false);
                    OpenText.SetActive(true);
                }
                break;
            case eCHOICE_STEP.ThrowSelect:
                {
                    if( ThrowSelectIndex == ChoiceIndex )
                    {
                        Card_Base cardClass = CardList[ChoiceIndex];
                        cardClass.SetFrontView(true);
                        cardClass.SetEnableSelectBtn(true);
                        cardClass.ToTrump().SetEnableBackBtn(false);

                        ThrowText.SetActive(true);
                        OpenText.SetActive(false);

                        CurStep = eCHOICE_STEP.None;
                        ThrowSelectIndex = -1;
                    }
                    else
                    {
                        CurStep = eCHOICE_STEP.ViewSelect;
                        ViewSelectIndex = ChoiceIndex;
                        GameSingleton.GetPlay().ToSevenPoker().Send_ChoiceComplete( ThrowSelectIndex, ViewSelectIndex);
                    }
                }
                break;
        }
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIBase : MonoBehaviour
{
    public SevenPokerPlayerUI ToSevenPoker()
    {
        assert.set(this is SevenPokerPlayerUI);
        return this as SevenPokerPlayerUI;
    }

    void Awake()
    {
        assert.set(CardSet);
        CardSet.cellSize = GameSingleton.GetPlay().CardSize;
    }    

    virtual public void ResetPlayUI()
    {
        int num = CardUIList.Count;
        for (int i = 0; i < num; ++i)
        {
            Destroy(CardUIList[i].gameObject);
        }
    }

    public Vector3 GetNextCardPosition()
    {
        Vector3 res = transform.position;
        float deltaX = CardSet.cellSize.x + CardSet.spacing.x;
        res.x += (CardSet.cellSize.x * 0.5f);
        res.x += (CardSet.transform.childCount * deltaX);
        return res;
    }

    // ===========================================================================
    //
    //  Player
    //
    // ===========================================================================
    protected PlayerBase Player = null;
    public void SetPlayer(PlayerBase player) { Player = player; }
    public PlayerBase GetPlayer() { assert.set(Player); return Player; }    

    // ===========================================================================
    //
    //  카드
    //
    // ===========================================================================
    // 카드들 리스트
    List<Card_Base> CardUIList = new List<Card_Base>();

    virtual public void AddCardClass(Card_Base cardClass)
    {        
        CardUIList.Add(cardClass);
    }

    public void CardMoveToTail(int CardIndex)
    {
        assert.set(CardUIList.Count > CardIndex && CardIndex >= 0);
        Card_Base cardClass = CardUIList[CardIndex];
        CardUIList.RemoveAt(CardIndex);
        CardUIList.Add(cardClass);

        cardClass.transform.SetAsLastSibling();
    }

    public void RemoveCard_ByIndex(int CardIndex)
    {
        assert.set(CardUIList.Count > CardIndex && CardIndex >= 0);
        Destroy(CardUIList[CardIndex].gameObject);
        CardUIList.RemoveAt(CardIndex);
    }

    // ===========================================================================
    //
    //  CardSet
    //
    // ===========================================================================
    // 카드들이 들어갈 Gameobject 의 GridLayoutGroup
    public GridLayoutGroup CardSet;

    public Transform GetCardSet() { return CardSet.transform; }
}

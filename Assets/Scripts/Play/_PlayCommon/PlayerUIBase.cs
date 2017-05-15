using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIBase : MonoBehaviour
{
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

    public void AddCardObject(GameObject cardObject)
    {
        Card_Base card = cardObject.GetComponent<Card_Base>();
        assert.set(card);
        CardUIList.Add(card);
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

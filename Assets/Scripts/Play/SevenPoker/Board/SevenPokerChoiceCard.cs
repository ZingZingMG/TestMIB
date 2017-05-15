using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SevenPokerChoiceCard : MonoBehaviour
{
    [System.NonSerialized]
    GameObject ThrowText;
    [System.NonSerialized]
    GameObject OpenText;
    [System.NonSerialized]
    Transform CardSetTr;

    void Awake()
    {
        ThrowText = transform.Find("ThrowText").gameObject;
        OpenText = transform.Find("OpenText").gameObject;
        CardSetTr = transform.Find("CardSet");
    }

    public void EnableChoice()
    {
        gameObject.SetActive(true);
        ThrowText.SetActive(true);
        OpenText.SetActive(false);

        var list = GameSingleton.GetPlay().ToSevenPoker().GetMyPlayer().CardList;
        assert.set(list.Count == 4);
        for( int i=0; i<list.Count; ++i )
        {
            string cardpath = string.Format("Card{0:00}/Front/TrumpCard", i+1);
            Card_Trump card = CardSetTr.Find(cardpath).GetComponent<Card_Trump>();
            card.SetInfo(list[i]);
        }
    }

    public void DisableChoice()
    {
        gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SevenPokerBoard : BoardBase
{
    // Use this for initialization
    void Start()
    {
        assert.set(ChoiceCard);
    }

    public Vector2 CardSpacing_Choice;
    public Vector2 CardSpacing_Play;
    public Vector2 CardSpacing_Die;

    // ===========================================================================
    //
    //  Choise Card
    //
    // ===========================================================================
    public SevenPokerChoiceCard ChoiceCard;


    // ===========================================================================
    //
    //  PlayerUI
    //
    // ===========================================================================
    public void LinkPlayerUI( int MyPositionIndex )
    {
        for( int i=0; i< GameSingleton.GetBasePlayScene().GetMaxPlayer(); ++i )
        {
            PlayerBase player = GameSingleton.GetBasePlayScene().GetPlayer(i);

            // 내 위치는 0 으로 맞추고 상대적인 위치로 셋팅
            int RelativePositionIndex = i - MyPositionIndex;
            if (RelativePositionIndex < 0)
            {
                RelativePositionIndex += GameSingleton.GetBasePlayScene().GetMaxPlayer();
            }
            assert.set(RelativePositionIndex >= 0 && RelativePositionIndex < GameSingleton.GetBasePlayScene().GetMaxPlayer());

            SevenPokerPlayerUI ui = transform.Find(string.Format("User{0:00}", RelativePositionIndex + 1)).GetComponent<SevenPokerPlayerUI>();
            ui.gameObject.SetActive(false);

            assert.set(ui);
            player.SetPlayerUI(ui);            
        }
    }

    // ===========================================================================
    //
    //  Etc
    //
    // ===========================================================================
    [SerializeField]
    protected GameObject DealerPosition;
    public Vector3 GetDealerPosition() { return DealerPosition.transform.position; }
}

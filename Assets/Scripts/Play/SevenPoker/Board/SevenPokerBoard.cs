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

    public void SetMode_Start()
    {
        ChoiceCard.DisableChoice();
    }

    public void SetMode_Choice()
    {
        if( GameSingleton.GetPlay().IsObserverMode() == false )
        {
            ChoiceCard.EnableChoice();
        }        
    }

    public void SetMode_Play()
    {
        ChoiceCard.DisableChoice();
    }

    // ===========================================================================
    //
    //  Choise Card
    //
    // ===========================================================================
    [SerializeField]
    protected SevenPokerChoiceCard ChoiceCard;  
    


    // ===========================================================================
    //
    //  PlayerUI
    //
    // ===========================================================================
    public void LinkPlayerUI( int MyPositionIndex )
    {
        for( int i=0; i< GameSingleton.GetPlay().GetMaxPlayer(); ++i )
        {
            PlayerBase player = GameSingleton.GetPlay().GetPlayer(i);

            // 내 위치는 0 으로 맞추고 상대적인 위치로 셋팅
            int RelativePositionIndex = i - MyPositionIndex;
            if (RelativePositionIndex < 0)
            {
                RelativePositionIndex += GameSingleton.GetPlay().GetMaxPlayer();
            }
            assert.set(RelativePositionIndex >= 0 && RelativePositionIndex < GameSingleton.GetPlay().GetMaxPlayer());

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

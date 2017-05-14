using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SevenPokerPlayerUI : PlayerUIBase
{
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void SetMode_ChoiceUI()
    {
        CardSet.spacing = GameSingleton.GetBasePlayScene().GetSevenPokerBoard().CardSpacing_Choice;
    }

    public void SetMode_PlayUI()
    {
        CardSet.spacing = GameSingleton.GetBasePlayScene().GetSevenPokerBoard().CardSpacing_Play;
    }

    public void SetMode_DieUI()
    {
        CardSet.spacing = GameSingleton.GetBasePlayScene().GetSevenPokerBoard().CardSpacing_Die;
    }
}

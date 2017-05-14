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

	// Use this for initialization
	void Start ()
    {
        		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void SetMode_Choice()
    {
        gameObject.SetActive(true);
        ThrowText.SetActive(true);
        OpenText.SetActive(false);

        //SevenPokerUser user = GameSingleton.GetSevenPokerPlayScene().MainCavasClass.GetUser(0);
        //assert.set(user.IsMyUser());        
    }

    public void SetMode_Play()
    {
        gameObject.SetActive(false);
    }
}

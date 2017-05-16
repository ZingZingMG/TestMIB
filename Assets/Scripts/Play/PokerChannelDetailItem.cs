using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class PokerChannelDetailItem : MonoBehaviour
{
    public RectTransform RectTransform;
    public Text TitleUIText;
    public Text RoomCntUIText;
    public Text UserCntUIText;
    public Button CurrentChannlUIButton;
    public Button ChannelMoveUIButton;

    [System.NonSerialized]
    public GamePlayData.PokerChannelInfo CachedPokerChannelInfo;

    public void InvalidCheck()
    {
        assert.set(RectTransform);
        assert.set(TitleUIText);
        assert.set(RoomCntUIText);
        assert.set(UserCntUIText);
        assert.set(CurrentChannlUIButton);
        assert.set(ChannelMoveUIButton);
    }
}
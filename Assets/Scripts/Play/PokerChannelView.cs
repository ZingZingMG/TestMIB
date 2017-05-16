using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class PokerChannelView : MonoBehaviour
{
    [System.Serializable]
    public class ChannelButtonInfo
    {
        public Button SelectUIButton;
        public Text NameUIText;
        public Text GradeUIText;

        [System.NonSerialized]
        public GamePlayData.PokerChannel Channel;

        public void InvalidCheck()
        {
            assert.set(SelectUIButton, "SelectUIButton");
            assert.set(NameUIText, "NameUIText");
            assert.set(GradeUIText, "GradeUIText");
        }
    }

    public Text ChannelNameGUIText;
    public ChannelButtonInfo[] ChannelButtonInfos;

    [System.Serializable]
    public class ChannelDetailInfo
    {
        public RectTransform ScrollContentRect;
        public PokerChannelDetailItem ScrollContnetItem;

        [System.NonSerialized]
        public PokerChannelDetailItem[] CachedScrollContentItems;

        public void InvalidCheck()
        {
            assert.set(ScrollContentRect, "ScrollContentRect");
            assert.set(ScrollContnetItem, "ScrollContnetItem");

            ScrollContnetItem.InvalidCheck();
        }
    }

    public ChannelDetailInfo ScrollContentDetailChannelItem;

    public void OnClickChannelType(GlobalTypes.PokerChannelType Type)
    {
        // 서버에 요청.
        GameSingleton.Instance.GameData.PokerChannelType = Type;
        OpenChannelDetailInfo();
    }

    public void OnClickMoveToChannel(int ChannelID)
    {

    }

    void Start()
    {
        Init();
    }

    public void Init()
    {
        GamePlayData.PokerChannel[] Channels = GameSingleton.Instance.GameData.GetChannelInfos();

        if (Channels != null)
        {
            List<GamePlayData.PokerChannel> UseChannelList = new List<GamePlayData.PokerChannel>();

            for (int i = 0; i < Channels.Length; ++i)
            {
                if (Channels[i].Type != GlobalTypes.PokerChannelType.Invalid)
                {
                    UseChannelList.Add(Channels[i]);
                }
            }

            for (int i = 0; i < ChannelButtonInfos.Length; ++i)
            {
                ChannelButtonInfos[i].InvalidCheck();
                ChannelButtonInfos[i].SelectUIButton.gameObject.SetActive(false);
            }

            for (int i = 0; i < ChannelButtonInfos.Length; ++i)
            {
                if (ChannelButtonInfos[i].SelectUIButton != null && UseChannelList.Count > 0)
                {
                    GamePlayData.PokerChannel Channel = UseChannelList[0];

                    if (Channel != null)
                    {
                        UseChannelList.RemoveAt(0);

                        ChannelButtonInfos[i].SelectUIButton.gameObject.SetActive(true);
                        ChannelButtonInfos[i].SelectUIButton.onClick.RemoveAllListeners();
                        ChannelButtonInfos[i].SelectUIButton.onClick.AddListener(delegate { OnClickChannelType(Channel.Type); });


                        ChannelButtonInfos[i].NameUIText.text = Channel.TypeName;
                        if(Channel.Highlight == true)
                        {
                            ChannelButtonInfos[i].NameUIText.color = Color.blue;
                        }
                        ChannelButtonInfos[i].GradeUIText.text = Channel.GradeName;
                        ChannelButtonInfos[i].Channel = Channel;
                    }
                }
            }

            assert.set(ScrollContentDetailChannelItem, "ScrollContentDetailChannelItem");
            ScrollContentDetailChannelItem.InvalidCheck();
            
            GamePlayData.PokerChannelInfo[] PokerChannelInfos = Channels[0].GetChannelInfos();

            int ItemCnt = 0;
            ScrollContentDetailChannelItem.CachedScrollContentItems = new PokerChannelDetailItem[PokerChannelInfos.Length];

            ScrollContentDetailChannelItem.ScrollContnetItem.CurrentChannlUIButton.gameObject.SetActive(false);
            ScrollContentDetailChannelItem.ScrollContnetItem.ChannelMoveUIButton.gameObject.SetActive(false);
            ScrollContentDetailChannelItem.CachedScrollContentItems[ItemCnt++] = ScrollContentDetailChannelItem.ScrollContnetItem;

            for ( int i = 0; i < PokerChannelInfos.Length-1; ++i)
            {
                GameObject NewObj = Instantiate(ScrollContentDetailChannelItem.ScrollContnetItem.gameObject, ScrollContentDetailChannelItem.ScrollContentRect.transform);
                PokerChannelDetailItem NewItem = NewObj.GetComponent<PokerChannelDetailItem>();

                NewItem.CurrentChannlUIButton.gameObject.SetActive(false);
                NewItem.ChannelMoveUIButton.gameObject.SetActive(false);
                ScrollContentDetailChannelItem.CachedScrollContentItems[ItemCnt++] = NewItem;
            }

            ScrollContentDetailChannelItem.ScrollContentRect.offsetMax = new Vector2(ScrollContentDetailChannelItem.ScrollContnetItem.RectTransform.offsetMax.x,
                                                                                     ScrollContentDetailChannelItem.ScrollContnetItem.RectTransform.rect.height * ItemCnt);
            ScrollContentDetailChannelItem.ScrollContentRect.position = new Vector3(0.0f, 0.0f, 0.0f);
        }
    }

    void OpenChannelDetailInfo()
    {
        if (GameSingleton.Instance.GameData.PokerChannelType != GlobalTypes.PokerChannelType.Invalid)
        {
            GamePlayData.PokerChannel[] Channels = GameSingleton.Instance.GameData.GetChannelInfos();
            GamePlayData.PokerChannelInfo[] PokerChannelInfos = Channels[(int)GameSingleton.Instance.GameData.PokerChannelType].GetChannelInfos();

            for (int i = 0; i < ScrollContentDetailChannelItem.CachedScrollContentItems.Length; ++i)
            {
                PokerChannelDetailItem DetailItem = ScrollContentDetailChannelItem.CachedScrollContentItems[i];
                DetailItem.CachedPokerChannelInfo = PokerChannelInfos[i];
                DetailItem.TitleUIText.text = DetailItem.CachedPokerChannelInfo.Name;
                DetailItem.RoomCntUIText.text = DetailItem.CachedPokerChannelInfo.RoomCnt.ToString();
                DetailItem.UserCntUIText.text = DetailItem.CachedPokerChannelInfo.UserCnt.ToString();
                DetailItem.CurrentChannlUIButton.gameObject.SetActive(false);
                DetailItem.ChannelMoveUIButton.gameObject.SetActive(false);
                DetailItem.ChannelMoveUIButton.onClick.RemoveAllListeners();
                DetailItem.ChannelMoveUIButton.onClick.AddListener(delegate { OnClickMoveToChannel(DetailItem.CachedPokerChannelInfo.ID); });

                if (PokerChannelInfos[i].State == GlobalTypes.ChannelState.Used)
                {
                    DetailItem.CurrentChannlUIButton.gameObject.SetActive(true);
                }
                else if (PokerChannelInfos[i].State == GlobalTypes.ChannelState.Open)
                {
                    DetailItem.ChannelMoveUIButton.gameObject.SetActive(true);
                }
            }
        }
    }

    public void Open()
    {
        OpenChannelDetailInfo();
    }

    public void SetChannelName(string Value)
    {
        if(ChannelNameGUIText != null)
        {

        }
    }
}
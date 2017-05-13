using UnityEngine;
using UnityEditor;

public partial class GamePlayData
{
    public class UserInfo
    {
        public string Name = "테스트";
    }

    public class UserDetailInfo
    {

    }

    // 채널 정보.
    public class Channel
    {

    }

    public class ChannelInfo
    {
        public byte ID;
        public byte State;
    }

    public class ChannelRoomInfo
    {
        public byte ID;
    }

    public class ChannelRoomDetailInfo
    {

    }

    // 포커 채널 정보.
    public class PokerUserInfo : UserInfo
    {
        public byte PlayGameType;
        public byte PlayGrade;
    }

    public class PorkerChannelInfo : ChannelInfo
    {
        public string Name = "Test";
        public int RoomCnt = 1;
        public int UserCnt = 1;
    }

    public class PorkerChannel : Channel
    {
        public byte Type;
        public byte Grade;
    }

    public class PorkerChannelRoomInfo : ChannelRoomInfo
    {
        public byte Grade;
        public string RoomName = "테스트 방";
        public byte UserCnt;
        public byte MaxUserCnt;
    }

    // 세븐 포커 채널 정보.
    public class SevenPokerUserInfo : PokerUserInfo
    {

    }

    public class SevenPorkerChannelInfo : PorkerChannelInfo
    {

    }

    public class SevenPorkerChannel : PorkerChannel
    {
        public SevenPorkerChannelInfo[] ChanelInfos = new SevenPorkerChannelInfo[15];
    }

    public class SevenPorkerChannelRoomInfo : PorkerChannelRoomInfo
    {
        public int BBingValue;
        public byte RuleType;
    }

    // 훌라 채널 정보.
    public class HoolaUserInfo : PokerUserInfo
    {

    }

    public class HoolaChannelInfo : PorkerChannelInfo
    {

    }

    public class HoolaChannel : PorkerChannel
    {
        public HoolaChannelInfo[] ChanelInfos = new HoolaChannelInfo[15];
    }

    public class HoolaChannelRoomInfo : PorkerChannelRoomInfo
    {
        public byte CalculateType;
        public byte GameMoneyRuleType;
        public byte RuleType;
        public byte RoomAttributeType;
        public byte ModeType;
        public bool ExistJoker;
    }

    // 바둑이 채널 정보.
    public class BadukiUserInfo : PokerUserInfo
    {

    }

    public class BadukiChannelInfo : PorkerChannelInfo
    {

    }

    public class BadukiChannel : PorkerChannel
    {
        public BadukiChannelInfo[] ChanelInfos = new BadukiChannelInfo[15];
    }

    public class BadukiChannelRoomInfo : PorkerChannelRoomInfo
    {
        public int BBingValue;
    }

    // 고스톱 채널 정보.
    public class GostopUserInfo : UserInfo
    {
        public int Money;
    }

    public class GostopChannelInfo : ChannelInfo
    {
        public string Name = "Test";
        public int UserCnt = 1;
        public int MaxUserCnt = 10;
    }

    public class GostopChannel : Channel
    {
        public byte Type;

        public GostopChannelInfo[] ChanelInfos = new GostopChannelInfo[15];
    }

    public class GostopChannelRoomInfo : ChannelRoomInfo
    {
        public string RoomName = "테스트 방";
        public int MinJoinMoney;
        public int UserMaxMoney;
        public byte PointToMoneyType;
        public byte ModeType;
        public byte BonusType;
        public byte UserCnt;
        public byte MaxUserCnt;
    }

    // 섯다 채널 정보.
    public class SuddaUserInfo : GostopUserInfo
    {
        
    }

    public class SuddaChannelInfo : GostopChannelInfo
    {

    }

    public class SuddaChannel : Channel
    {
        public SuddaChannelInfo[] ChanelInfos = new SuddaChannelInfo[15];
    }

    public class SuddaChannelRoomInfo : ChannelRoomInfo
    {
        public string RoomName = "테스트 방";
        public int MinJoinMoney;
        public byte BettingRuleType;
        public byte ModeType;
        public byte RuleType;
        public byte UserCnt;
        public byte MaxUserCnt;
    }
}
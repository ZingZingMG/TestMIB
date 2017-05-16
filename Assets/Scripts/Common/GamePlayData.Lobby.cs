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
        public virtual void Init() { }
        public virtual void InitChannelInfos() { }
    }

    public class ChannelInfo
    {
        public byte ID = 0;
        public GlobalTypes.ChannelState State = GlobalTypes.ChannelState.Open;

        public virtual void Init()
        {
            ID = 0;
            State = GlobalTypes.ChannelState.Open;
        }
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

    public class PokerChannelInfo : ChannelInfo
    {
        public string Name = "Test";
        public int RoomCnt = 0;
        public int UserCnt = 0;
        public int MaxUserCnt = 999;

        public void Init(GlobalTypes.PokerChannelType ChannelType, int Number)
        {
            switch (ChannelType)
            {
                case GlobalTypes.PokerChannelType.Chobo:
                    Name = "초보";
                    break;
                case GlobalTypes.PokerChannelType.Hasu:
                    Name = "하수";
                    break;
                case GlobalTypes.PokerChannelType.Joongsu:
                    Name = "중수";
                    break;
                case GlobalTypes.PokerChannelType.Ama:
                    Name = "아마";
                    break;
                case GlobalTypes.PokerChannelType.Semipro:
                    Name = "세미";
                    break;
                case GlobalTypes.PokerChannelType.Pro:
                    Name = "프로";
                    break;
                case GlobalTypes.PokerChannelType.Masters:
                    Name = "마스터즈";
                    break;
                case GlobalTypes.PokerChannelType.Lasvegas:
                    Name = "베가스";
                    break;
                case GlobalTypes.PokerChannelType.Free:
                    Name = "자유";
                    break;
                case GlobalTypes.PokerChannelType.PokerChip:
                    Name = "포커칩";
                    break;
            }

            Name += Number.ToString();
            ID = (byte)Number;
            RoomCnt = 0;
            UserCnt = 0;
            MaxUserCnt = 700;
        }
    }

    public class PokerChannel : Channel
    {
        public GlobalTypes.PokerChannelType Type = GlobalTypes.PokerChannelType.Invalid;
        public string TypeName = "";
        public byte Grade = 0;
        public string GradeName = "";
        public bool Highlight = false;

        public override void Init()
        {
            base.Init();

            TypeName = "";
            Type = GlobalTypes.PokerChannelType.Invalid;
            Grade = 0;
            GradeName = "";
            Highlight = false;
        }

        public virtual PokerChannelInfo[] GetChannelInfos() { return null; }
    }

    public class PokerChannelRoomInfo : ChannelRoomInfo
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

    public class SevenPokerChannelInfo : PokerChannelInfo
    {

    }

    public class SevenPokerChannel : PokerChannel
    {
        public SevenPokerChannelInfo[] ChannelInfos = new SevenPokerChannelInfo[15];
        public SevenPokerChannelRoomInfo[] RoomInfos = new SevenPokerChannelRoomInfo[100];

        public override void InitChannelInfos()
        {
            base.InitChannelInfos();

            for (int i = 0; i < ChannelInfos.Length; ++i)
            {
                ChannelInfos[i] = new SevenPokerChannelInfo();
                ChannelInfos[i].Init(Type, i + 1);
            }
        }

        public override PokerChannelInfo[] GetChannelInfos() { return ChannelInfos; }
    }

    public class SevenPokerChannelRoomInfo : PokerChannelRoomInfo
    {
        public int BBingValue;
        public byte RuleType;
    }

    // 훌라 채널 정보.
    public class HoolaUserInfo : PokerUserInfo
    {

    }

    public class HoolaChannelInfo : PokerChannelInfo
    {

    }

    public class HoolaChannel : PokerChannel
    {
        public HoolaChannelInfo[] ChannelInfos = new HoolaChannelInfo[15];
        public HoolaChannelRoomInfo[] RoomInfos = new HoolaChannelRoomInfo[100];

        public override void InitChannelInfos()
        {
            base.InitChannelInfos();

            for (int i = 0; i < ChannelInfos.Length; ++i)
            {
                ChannelInfos[i] = new HoolaChannelInfo();
                ChannelInfos[i].Init(Type, i + 1);
            }
        }

        public override PokerChannelInfo[] GetChannelInfos() { return ChannelInfos; }
    }

    public class HoolaChannelRoomInfo : PokerChannelRoomInfo
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

    public class BadukiChannelInfo : PokerChannelInfo
    {

    }

    public class BadukiChannel : PokerChannel
    {
        public BadukiChannelInfo[] ChannelInfos = new BadukiChannelInfo[15];
        public BadukiChannelRoomInfo[] RoomInfos = new BadukiChannelRoomInfo[100];

        public override void InitChannelInfos()
        {
            base.InitChannelInfos();

            for (int i = 0; i < ChannelInfos.Length; ++i)
            {
                ChannelInfos[i] = new BadukiChannelInfo();
                ChannelInfos[i].Init(Type, i + 1);
            }
        }

        public override PokerChannelInfo[] GetChannelInfos() { return ChannelInfos; }
    }

    public class BadukiChannelRoomInfo : PokerChannelRoomInfo
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
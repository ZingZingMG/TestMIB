using UnityEngine;
using UnityEditor;


public partial class GamePlayData
{
    public class SevenPoker
    {
        public SevenPokerUserInfo[] UserInfos = new SevenPokerUserInfo[10];
        public SevenPokerChannel Channel = new SevenPokerChannel();
        public SevenPokerChannelRoomInfo[] RoomInfos = new SevenPokerChannelRoomInfo[100];

        public void Init()
        {

        }
    }

    public class Hoola
    {
        public HoolaUserInfo[] UserInfos = new HoolaUserInfo[10];
        public HoolaChannel Channel = new HoolaChannel();
        public HoolaChannelRoomInfo[] RoomInfos = new HoolaChannelRoomInfo[100];

        public void Init()
        {

        }
    }

    public class Baduki
    {
        public BadukiUserInfo[] UserInfos = new BadukiUserInfo[10];
        public BadukiChannel Channel = new BadukiChannel();
        public BadukiChannelRoomInfo[] RoomInfos = new BadukiChannelRoomInfo[100];

        public void Init()
        {

        }
    }

    public class Gostop
    {
        public GostopUserInfo[] UserInfos = new GostopUserInfo[10];
        public GostopChannel Channel = new GostopChannel();
        public GostopChannelRoomInfo[] RoomInfos = new GostopChannelRoomInfo[100];

        public void Init()
        {

        }
    }

    public class Sudda
    {
        public SuddaUserInfo[] UserInfos = new SuddaUserInfo[10];
        public SuddaChannel Channel = new SuddaChannel();
        public SuddaChannelRoomInfo[] RoomInfos = new SuddaChannelRoomInfo[100];

        public void Init()
        {

        }
    }

    public SevenPoker SevenPokerData = null;
    public Hoola HoolaData = null;
    public Baduki BadukiData = null;
    public Gostop GostopData = null;
    public Sudda SuddaData = null;
        
    public void Init( GlobalTypes.GameKind Kind )
    {
        SevenPokerData = null;
        HoolaData = null;
        BadukiData = null;
        GostopData = null;
        SuddaData = null;

        switch (Kind)
        {
            case GlobalTypes.GameKind.SevenPoker:
                SevenPokerData = new SevenPoker();
                break;
            case GlobalTypes.GameKind.Hoola:
                HoolaData = new Hoola();
                break;
            case GlobalTypes.GameKind.Baduki:
                BadukiData = new Baduki();
                break;
            case GlobalTypes.GameKind.Gostop:
                GostopData = new Gostop();
                break;
            case GlobalTypes.GameKind.Sudda:
                SuddaData = new Sudda();
                break;
        }
    }
}
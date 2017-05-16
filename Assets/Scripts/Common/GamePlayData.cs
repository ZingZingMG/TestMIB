using UnityEngine;
using UnityEditor;


public partial class GamePlayData
{
    public class SevenPoker
    {
        public SevenPokerUserInfo[] UserInfos = new SevenPokerUserInfo[10];
        public SevenPokerChannel[] Channels = new SevenPokerChannel[(int)(GlobalTypes.PokerChannelType.Cnt)];
        public GlobalTypes.PokerChannelType SelectChannelType = GlobalTypes.PokerChannelType.Chobo;

        public void Init()
        {
            SelectChannelType = GlobalTypes.PokerChannelType.Chobo;

            for (int i = 0; i < UserInfos.Length; ++i)
            {
                UserInfos[i] = new SevenPokerUserInfo();
            }

            for ( int i = 0; i < Channels.Length; ++i)
            {
                Channels[i] = new SevenPokerChannel();
                Channels[i].Init();
            }

            Channels[(int)(GlobalTypes.PokerChannelType.Chobo)].Type = GlobalTypes.PokerChannelType.Chobo;
            Channels[(int)(GlobalTypes.PokerChannelType.Chobo)].TypeName = "초보";
            Channels[(int)(GlobalTypes.PokerChannelType.Chobo)].GradeName = "에이스";

            Channels[(int)(GlobalTypes.PokerChannelType.Hasu)].Type = GlobalTypes.PokerChannelType.Hasu;
            Channels[(int)(GlobalTypes.PokerChannelType.Hasu)].TypeName = "하수";
            Channels[(int)(GlobalTypes.PokerChannelType.Hasu)].GradeName = "에이스,원페어";

            Channels[(int)(GlobalTypes.PokerChannelType.Joongsu)].Type = GlobalTypes.PokerChannelType.Joongsu;
            Channels[(int)(GlobalTypes.PokerChannelType.Joongsu)].TypeName = "중수";
            Channels[(int)(GlobalTypes.PokerChannelType.Joongsu)].GradeName = "원페어,투페어";

            Channels[(int)(GlobalTypes.PokerChannelType.Ama)].Type = GlobalTypes.PokerChannelType.Ama;
            Channels[(int)(GlobalTypes.PokerChannelType.Ama)].TypeName = "아마";
            Channels[(int)(GlobalTypes.PokerChannelType.Ama)].GradeName = "투페어,트리플";

            Channels[(int)(GlobalTypes.PokerChannelType.Semipro)].Type = GlobalTypes.PokerChannelType.Semipro;
            Channels[(int)(GlobalTypes.PokerChannelType.Semipro)].TypeName = "세미프로";
            Channels[(int)(GlobalTypes.PokerChannelType.Semipro)].GradeName = "트리플,스트레이트";

            Channels[(int)(GlobalTypes.PokerChannelType.Pro)].Type = GlobalTypes.PokerChannelType.Pro;
            Channels[(int)(GlobalTypes.PokerChannelType.Pro)].TypeName = "프로";
            Channels[(int)(GlobalTypes.PokerChannelType.Pro)].GradeName = "스트레이트,마운틴";

            Channels[(int)(GlobalTypes.PokerChannelType.Lasvegas)].Type = GlobalTypes.PokerChannelType.Lasvegas;
            Channels[(int)(GlobalTypes.PokerChannelType.Lasvegas)].TypeName = "라스베가스";
            Channels[(int)(GlobalTypes.PokerChannelType.Lasvegas)].GradeName = "마운틴 ~ 로티풀";

            Channels[(int)(GlobalTypes.PokerChannelType.Free)].Type = GlobalTypes.PokerChannelType.Free;
            Channels[(int)(GlobalTypes.PokerChannelType.Free)].TypeName = "자유채널";
            Channels[(int)(GlobalTypes.PokerChannelType.Free)].Highlight = true;

            Channels[(int)(GlobalTypes.PokerChannelType.PokerChip)].Type = GlobalTypes.PokerChannelType.PokerChip;
            Channels[(int)(GlobalTypes.PokerChannelType.PokerChip)].TypeName = "포커칩 채널";
            Channels[(int)(GlobalTypes.PokerChannelType.PokerChip)].GradeName = "제한없음";
            Channels[(int)(GlobalTypes.PokerChannelType.PokerChip)].Highlight = true;

            for (int i = 0; i < Channels.Length; ++i)
            {
                Channels[i].InitChannelInfos();
            }
        }
    }

    public class Hoola
    {
        public HoolaUserInfo[] UserInfos = new HoolaUserInfo[10];
        public HoolaChannel[] Channels = new HoolaChannel[(int)(GlobalTypes.PokerChannelType.Cnt)];
        public GlobalTypes.PokerChannelType SelectChannelType = GlobalTypes.PokerChannelType.Chobo;

        public void Init()
        {
            SelectChannelType = GlobalTypes.PokerChannelType.Chobo;

            for (int i = 0; i < UserInfos.Length; ++i)
            {
                UserInfos[i] = new HoolaUserInfo();
            }

            for (int i = 0; i < Channels.Length; ++i)
            {
                Channels[i] = new HoolaChannel();
                Channels[i].Init();
            }

            Channels[(int)(GlobalTypes.PokerChannelType.Chobo)].Type = GlobalTypes.PokerChannelType.Chobo;
            Channels[(int)(GlobalTypes.PokerChannelType.Chobo)].TypeName = "초보";
            Channels[(int)(GlobalTypes.PokerChannelType.Chobo)].GradeName = "에이스";

            Channels[(int)(GlobalTypes.PokerChannelType.Hasu)].Type = GlobalTypes.PokerChannelType.Hasu;
            Channels[(int)(GlobalTypes.PokerChannelType.Hasu)].TypeName = "하수";
            Channels[(int)(GlobalTypes.PokerChannelType.Hasu)].GradeName = "에이스,원페어";

            Channels[(int)(GlobalTypes.PokerChannelType.Joongsu)].Type = GlobalTypes.PokerChannelType.Joongsu;
            Channels[(int)(GlobalTypes.PokerChannelType.Joongsu)].TypeName = "중수";
            Channels[(int)(GlobalTypes.PokerChannelType.Joongsu)].GradeName = "원페어,투페어";

            Channels[(int)(GlobalTypes.PokerChannelType.Ama)].Type = GlobalTypes.PokerChannelType.Ama;
            Channels[(int)(GlobalTypes.PokerChannelType.Ama)].TypeName = "아마";
            Channels[(int)(GlobalTypes.PokerChannelType.Ama)].GradeName = "투페어,트리플";

            Channels[(int)(GlobalTypes.PokerChannelType.Semipro)].Type = GlobalTypes.PokerChannelType.Semipro;
            Channels[(int)(GlobalTypes.PokerChannelType.Semipro)].TypeName = "세미프로";
            Channels[(int)(GlobalTypes.PokerChannelType.Semipro)].GradeName = "트리플,스트레이트";

            Channels[(int)(GlobalTypes.PokerChannelType.Pro)].Type = GlobalTypes.PokerChannelType.Pro;
            Channels[(int)(GlobalTypes.PokerChannelType.Pro)].TypeName = "프로";
            Channels[(int)(GlobalTypes.PokerChannelType.Pro)].GradeName = "스트레이트,마운틴";

            Channels[(int)(GlobalTypes.PokerChannelType.Masters)].Type = GlobalTypes.PokerChannelType.Masters;
            Channels[(int)(GlobalTypes.PokerChannelType.Masters)].TypeName = "마스터즈";
            Channels[(int)(GlobalTypes.PokerChannelType.Masters)].GradeName = "마운틴 ~ 로티풀";

            Channels[(int)(GlobalTypes.PokerChannelType.Free)].Type = GlobalTypes.PokerChannelType.Free;
            Channels[(int)(GlobalTypes.PokerChannelType.Free)].TypeName = "자유채널";
            Channels[(int)(GlobalTypes.PokerChannelType.Free)].Highlight = true;

            for (int i = 0; i < Channels.Length; ++i)
            {
                Channels[i].InitChannelInfos();
            }
        }
    }

    public class Baduki
    {
        public BadukiUserInfo[] UserInfos = new BadukiUserInfo[10];
        public BadukiChannel[] Channels = new BadukiChannel[(int)(GlobalTypes.PokerChannelType.Cnt)];
        public GlobalTypes.PokerChannelType SelectChannelType = GlobalTypes.PokerChannelType.Chobo;

        public void Init()
        {
            SelectChannelType = GlobalTypes.PokerChannelType.Chobo;

            for (int i = 0; i < UserInfos.Length; ++i)
            {
                UserInfos[i] = new BadukiUserInfo();
            }

            for (int i = 0; i < Channels.Length; ++i)
            {
                Channels[i] = new BadukiChannel();
                Channels[i].Init();
            }

            Channels[(int)(GlobalTypes.PokerChannelType.Chobo)].Type = GlobalTypes.PokerChannelType.Chobo;
            Channels[(int)(GlobalTypes.PokerChannelType.Chobo)].TypeName = "초보";
            Channels[(int)(GlobalTypes.PokerChannelType.Chobo)].GradeName = "에이스,원페어";

            Channels[(int)(GlobalTypes.PokerChannelType.Ama)].Type = GlobalTypes.PokerChannelType.Ama;
            Channels[(int)(GlobalTypes.PokerChannelType.Ama)].TypeName = "아마";
            Channels[(int)(GlobalTypes.PokerChannelType.Ama)].GradeName = "투페어,트리플";
            
            Channels[(int)(GlobalTypes.PokerChannelType.Pro)].Type = GlobalTypes.PokerChannelType.Pro;
            Channels[(int)(GlobalTypes.PokerChannelType.Pro)].TypeName = "프로";
            Channels[(int)(GlobalTypes.PokerChannelType.Pro)].GradeName = "스트레이트,마운틴";
            
            Channels[(int)(GlobalTypes.PokerChannelType.Masters)].Type = GlobalTypes.PokerChannelType.Masters;
            Channels[(int)(GlobalTypes.PokerChannelType.Masters)].TypeName = "마스터즈";
            Channels[(int)(GlobalTypes.PokerChannelType.Masters)].GradeName = "마운틴 ~ 로티풀";
            
            Channels[(int)(GlobalTypes.PokerChannelType.Lasvegas)].Type = GlobalTypes.PokerChannelType.Lasvegas;
            Channels[(int)(GlobalTypes.PokerChannelType.Lasvegas)].TypeName = "라스베가스";
            Channels[(int)(GlobalTypes.PokerChannelType.Lasvegas)].GradeName = "플러쉬 ~ 로티풀";

            Channels[(int)(GlobalTypes.PokerChannelType.Free)].Type = GlobalTypes.PokerChannelType.Free;
            Channels[(int)(GlobalTypes.PokerChannelType.Free)].TypeName = "자유채널";
            Channels[(int)(GlobalTypes.PokerChannelType.Free)].Highlight = true;

            Channels[(int)(GlobalTypes.PokerChannelType.PokerChip)].Type = GlobalTypes.PokerChannelType.PokerChip;
            Channels[(int)(GlobalTypes.PokerChannelType.PokerChip)].TypeName = "포커칩 채널";
            Channels[(int)(GlobalTypes.PokerChannelType.PokerChip)].GradeName = "제한없음";
            Channels[(int)(GlobalTypes.PokerChannelType.PokerChip)].Highlight = true;

            for (int i = 0; i < Channels.Length; ++i)
            {
                Channels[i].InitChannelInfos();
            }
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
                SevenPokerData.Init();
                break;
            case GlobalTypes.GameKind.Hoola:
                HoolaData = new Hoola();
                HoolaData.Init();
                break;
            case GlobalTypes.GameKind.Baduki:
                BadukiData = new Baduki();
                BadukiData.Init();
                break;
            case GlobalTypes.GameKind.Gostop:
                GostopData = new Gostop();
                GostopData.Init();
                break;
            case GlobalTypes.GameKind.Sudda:
                SuddaData = new Sudda();
                SuddaData.Init();
                break;
        }
    }

    public GlobalTypes.PokerChannelType PokerChannelType
    {
        get
        {
            if (SevenPokerData != null)
            {
                return SevenPokerData.SelectChannelType;
            }
            else if (HoolaData != null)
            {
                return HoolaData.SelectChannelType;
            }
            else if (BadukiData != null)
            {
                return BadukiData.SelectChannelType;
            }

            return GlobalTypes.PokerChannelType.Invalid;
        }
        set
        {
            if (SevenPokerData != null)
            {
                SevenPokerData.SelectChannelType = value;
            }
            else if (HoolaData != null)
            {
                HoolaData.SelectChannelType = value;
            }
            else if (BadukiData != null)
            {
                BadukiData.SelectChannelType = value;
            }
        }
    }

    public PokerChannel[] GetChannelInfos()
    {
        PokerChannel[] ReturnInfos = null;

        if( SevenPokerData != null)
        {
            ReturnInfos = SevenPokerData.Channels;
        }
        else if( HoolaData != null)
        {
            ReturnInfos = HoolaData.Channels;
        }
        else if (BadukiData != null)
        {
            ReturnInfos = BadukiData.Channels;
        }

        return ReturnInfos;
    }
}
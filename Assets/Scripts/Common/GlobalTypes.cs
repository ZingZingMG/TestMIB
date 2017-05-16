using System.Collections;


namespace GlobalTypes
{
    public enum GameKind
    {
        SevenPoker,
        Hoola,
        Baduki,
        Gostop,
        Sudda,
    }

    public enum ChannelState
    {
        Close,
        Open,
        Used,
    }

    public enum PokerChannelType
    {
        Chobo,
        Hasu,
        Joongsu,
        Ama,
        Semipro,
        Pro,
        Masters,
        Lasvegas,
        Free,
        PokerChip,
        Cnt,
        Invalid,
    }

    public enum MaxPlayer
    {
        SevenPoker = 5,
    }
}


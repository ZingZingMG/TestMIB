using System.Collections;


namespace PlayTypes
{
    public enum PlayPositionType
    {
        None,       // 빈자리
        Wait,       // 게임하기 위해 대기중
        Play,       // 게임중
        Die,        // 게임중 포기
    }

    public enum TrumpMark
    {
        Spade,
        Diamond,
        Heart,
        Clover,
    }
}


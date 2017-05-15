using System.Collections;


namespace PlayTypes
{
    [System.Serializable]
    public enum CardView
    {
        Front,      // 내용이 보이는 정면
        Back,       // 뒷면
        Dual,       // 혼합 : 위로 카드내용 아래로는 백뷰
    }

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

    public enum SevenPokerStep
    {
        None,
        Begin,                        // 게임이 시작        
        ChoiceCardShare_Complete,     // 선택 카드 다 나눈 상태
        ChoiceCardSelect,             // 선택 카드 확정
        CardShare_4,                  // 4구 시작
    }
}


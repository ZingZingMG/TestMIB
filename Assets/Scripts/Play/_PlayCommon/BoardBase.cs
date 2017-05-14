using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 해당 Play 되고 있는 게임판 : MainCavas UI 에 붙여준다.
public class BoardBase : MonoBehaviour
{
    public SevenPokerBoard ToSevenPoker()
    {
        assert.set(this is SevenPokerBoard);
        return this as SevenPokerBoard;
    }
}

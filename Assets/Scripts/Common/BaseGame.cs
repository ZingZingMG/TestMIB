using System.Collections;
using System.Collections.Generic;


public class BaseGame
{
    public BaseLobby Lobby;

    public void Init()
    {
        Lobby = new BaseLobby();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int matchesWon = 0;
    public int matchesLost = 0;

    public GameData(GameManager gameManager)
    {
        matchesWon = gameManager.matchesWon;
        matchesLost = gameManager.matchesLost;
    }
}

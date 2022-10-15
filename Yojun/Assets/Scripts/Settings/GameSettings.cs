using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Settings/GameSettings", order = 1)]
public class GameSettings : ScriptableObject
{
    [System.Serializable]
    public class Player
    {
        public Color color;
    }

    public Player[] players;

    public Color GetPlayerColor(int index)
    {
        return players[index].color;
    }
}

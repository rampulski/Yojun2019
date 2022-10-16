using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }

    public class Player
    {
        public int index;
        public GameObject gameObject;
        public int score;
        public bool banned;

        public Player(int index, GameObject go)
        {
            this.index = index;
            gameObject = go;
            score = 0;
            banned = false;
        }
    }

    [SerializeField] private float gameDuration;
    [SerializeField] private float gameOverDuration;

    private List<Player> players;

    private float timer;
    private bool gameOver;


    void Start()
    {
        players = new List<Player>();

        timer = 0;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver && timer >= gameDuration)
        {
            gameOver = true;

            int winningPlayer = -1, winningScore = -1;
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].score > winningScore)
                {
                    winningPlayer = i;
                    winningScore = players[i].score;
                }
            }

            for (int i = 0; i < players.Count; i++)
            {
                if (i != winningPlayer)
                    players[i].gameObject.GetComponent<Car>().Kill();
            }
        }
    }

    public void IncreaseScore(int index)
    {
        for (int i = 0; i < players.Count; i++)
        {
            if (players[i].index == index)
                players[i].score++;
        }
    }

    public void AddPlayer(int index, GameObject go)
    {
        players.Add(new Player(index, go));
    }

    public void KillPlayer(int index)
    {
        for (int i = 0; i < players.Count; i++)
        {
            if (players[i].index == index)
            {
                if (players[i].banned)
                    players.RemoveAt(i);
            }
        }
    }

    public void BanPlayer(int index)
    {
        for (int i = 0; i < players.Count; i++)
        {
            if (players[i].index == index)
                players[i].banned = true;
        }
    }

    public void UnBanPlayer(int index)
    {
        for (int i = 0; i < players.Count; i++)
        {
            if (players[i].index == index)
                players[i].banned = false;
        }
    }

    public bool IsPlayerExist(int index)
    {
        for (int i = 0; i < players.Count; i++)
        {
            if (players[i].index == index)
                return true;
        }
        return false;
    }

    public int GetPlayerScore(int index)
    {
        int score = 0;
        for (int i = 0; i < players.Count; i++)
        {
            if (players[i].index == index)
                score = players[i].score;
        }
        return score;
    }
}

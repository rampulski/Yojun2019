using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameMenu : MonoBehaviour
{
    private Score scoreScript;
    public int numberPlayerA, numberPlayerB;
    private int teamWinner;

    void Start()
    {
        Application.runInBackground = true;

        scoreScript = GameObject.Find("ScoringZone").GetComponent<Score>();
    }

    void Update()
    {

        if ((numberPlayerA == 0 && numberPlayerB > 1) || (numberPlayerA > 1 && numberPlayerB == 0)) // RAJOUTER UN TIMER POUR EVITER LA SITUATION OU LA WIN EST ANNONCE A CAUSE DU SPAM
        {
            if (numberPlayerA > numberPlayerB)
            {
                scoreScript.YouWin(Color.cyan);
            }

            if (numberPlayerA < numberPlayerB)
            {
                scoreScript.YouWin(new Color32(255, 64, 127, 255));
            }

        }
    }

}

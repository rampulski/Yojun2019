using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    private int playerIndex;

    public void Init(int index)
    {
        playerIndex = index;
    }

    public void IncreaseScore()
    {
        GameManager.instance.IncreaseScore(playerIndex);
    }

    public void Kill()
    {
        if (GetComponent<ExplodeIntoCubes>())
            GetComponent<ExplodeIntoCubes>().Explode();

        GameManager.instance.KillPlayer(playerIndex);
        Destroy(gameObject);
    }
}

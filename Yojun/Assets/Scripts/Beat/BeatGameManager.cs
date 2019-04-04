using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatGameManager : MonoBehaviour
{

    private GameObject[] players;
    public GameObject StrummingBarPrefab;
    private GameObject center;


    void Awake()
    {

    }

    void Start()
    {

        players = GameObject.FindGameObjectsWithTag("Player");
        center = GameObject.Find("Center");

        for (int i = 0; i < players.Length; i++)
        {
            GameObject gO;
            gO = Instantiate(StrummingBarPrefab, players[i].transform.position, Quaternion.identity, players[i].transform);
            gO.GetComponent<PlayerStrummingBar>().playerNumber = 1 +i;
            Vector3 difference = center.transform.position - players[i].transform.position;
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            players[i].transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotZ);
            players[i].transform.rotation *= Quaternion.Euler(0, 0, -180);
        }


    }

    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSpawner : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private Transform center;
    [SerializeField] private Transform autoPrefab;
    [SerializeField] private int playerNumber;

    private bool spawnedAlready;


    // Start is called before the first frame update
    void Start()
    {
        spawnedAlready = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (inputManager.inputPlayersPressed[playerNumber - 1] &&!spawnedAlready)
        {
            Transform auto = Instantiate(autoPrefab, transform.position, Quaternion.Euler(0, 0, Mathf.Atan((center.position.y - transform.position.y) / (center.position.x - transform.position.x)) * Mathf.Rad2Deg), transform);

            if (auto.GetComponent<SkidBehaviour>())
                auto.GetComponent<SkidBehaviour>().SetPlayerNumber(playerNumber - 1);

            spawnedAlready = true;
        }
    }
}

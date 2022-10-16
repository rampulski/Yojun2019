using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSpawner : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private Transform center;
    [SerializeField] private Transform autoPrefab;
    [SerializeField] private int playerNumber;
    [SerializeField] private float delayToSpawn;
    [SerializeField] private float delayToMove;
    [SerializeField] private float delayToBan;

    private Transform auto;

    private int score;
    private bool canSpawn;
    private bool banned;
    private float spawnTimer;
    private float banTimer;


    void Start()
    {
        auto = null;

        score = 0;
        canSpawn = false;
        banned = true;
        spawnTimer = 0;
        banTimer = 0;
    }

    void Update()
    {
        if (inputManager.inputPlayersPressed[playerNumber - 1])
        {
            banTimer = 0;
            banned = false;
        }

        banTimer += Time.deltaTime;
        if (banTimer >= delayToBan)
        {
            banned = true;
        }

        if (auto == null && !canSpawn && !banned)
        {
            canSpawn = true;
            spawnTimer = 0;
        }

        if (canSpawn)
            spawnTimer += Time.deltaTime;

        if (auto == null && !banned && canSpawn && spawnTimer >= delayToSpawn)
        {
            if (transform.position.x > center.position.x)
                auto = Instantiate(autoPrefab, transform.position, Quaternion.Euler(0, 0, 180 - (Mathf.Asin((center.position.y - transform.position.y) / (center.position - transform.position).magnitude) * Mathf.Rad2Deg)), transform);
            else
                auto = Instantiate(autoPrefab, transform.position, Quaternion.Euler(0, 0, Mathf.Asin((center.position.y - transform.position.y) / (center.position - transform.position).magnitude) * Mathf.Rad2Deg), transform);

            MeshRenderer[] renderers = auto.GetComponentsInChildren<MeshRenderer>();
            for (int i = 0; i < renderers.Length; i++)
                renderers[i].material.SetColor("_EmissionColor", InputManager.instance.GetPlayerColor(playerNumber - 1));
            auto.GetComponentInChildren<TrailRenderer>().material.SetColor("_EmissionColor", InputManager.instance.GetPlayerColor(playerNumber - 1));

            if (auto.GetComponent<TrailBehaviour>())
                auto.GetComponent<TrailBehaviour>().Init(this, score);

            if (auto.GetComponent<SkidBehaviour>())
                auto.GetComponent<SkidBehaviour>().Init(playerNumber - 1, delayToMove);

            canSpawn = false;
        }
    }

    public void IncreaseScore()
    {
        score++;
    }
}

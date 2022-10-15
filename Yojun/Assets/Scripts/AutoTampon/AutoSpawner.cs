using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSpawner : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private Transform center;
    [SerializeField] private Transform autoPrefab;
    [SerializeField] private int playerNumber;
    [SerializeField] private float delay;

    private Transform auto;


    // Start is called before the first frame update
    void Start()
    {
        auto = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (inputManager.inputPlayersPressed[playerNumber - 1] && auto == null)
        {
            if (transform.position.x > center.position.x)
                auto = Instantiate(autoPrefab, transform.position, Quaternion.Euler(0, 0, 180 - (Mathf.Asin((center.position.y - transform.position.y) / (center.position - transform.position).magnitude) * Mathf.Rad2Deg)), transform);
            else
                auto = Instantiate(autoPrefab, transform.position, Quaternion.Euler(0, 0, Mathf.Asin((center.position.y - transform.position.y) / (center.position - transform.position).magnitude) * Mathf.Rad2Deg), transform);

            if (auto.GetComponent<SkidBehaviour>())
                auto.GetComponent<SkidBehaviour>().Init(playerNumber - 1, delay);
        }
    }
}

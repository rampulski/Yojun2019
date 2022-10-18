using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesGenerator : MonoBehaviour
{
    [SerializeField] private Transform obstaclePrefab;
    [SerializeField] private int minObstaclesCount = 2;
    [SerializeField] private int maxObstaclesCount = 4;
    [SerializeField] private int areaRadius = 5;
    [SerializeField] private float minDist = 2;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos;
        bool ok;
        List<Transform> obstacles = new List<Transform>();
        int count = Random.Range(minObstaclesCount, maxObstaclesCount + 1);
        for (int i = 0; i < count; i++)
        {
            do
            {
                ok = true;
                pos = Random.insideUnitCircle * areaRadius;
                for (int j = 0; j < obstacles.Count; j++)
                {
                    if ((obstacles[j].position - pos).magnitude < minDist)
                        ok = false;
                }
            } while (!ok);

            obstacles.Add(Instantiate(obstaclePrefab, pos, Quaternion.Euler(-90, 0, 0), transform));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

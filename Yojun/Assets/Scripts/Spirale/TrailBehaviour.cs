using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailBehaviour : MonoBehaviour
{
    [SerializeField] private float minDuration = 1;
    [SerializeField] private float maxDuration = 15;
    [SerializeField] private float durationIncreaseRate = 0.5f;

    private TrailRenderer trail;
    private AutoSpawner spawner;

    private float currentDuration;


    public void Init(AutoSpawner spawner, int score)
    {
        trail = GetComponentInChildren<TrailRenderer>();

        this.spawner = spawner;
        currentDuration = minDuration;
        trail.time = currentDuration;

        for (int i = 0; i < score; i++)
        {
            currentDuration = Mathf.Clamp(currentDuration + durationIncreaseRate, minDuration, maxDuration);
            trail.time = currentDuration;
        }
    }

    public void IncreaseDuration()
    {
        currentDuration = Mathf.Clamp(currentDuration + durationIncreaseRate, minDuration, maxDuration);
        trail.time = currentDuration;

        spawner.IncreaseScore();
    }
}

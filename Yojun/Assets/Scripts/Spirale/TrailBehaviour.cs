using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailBehaviour : MonoBehaviour
{
    [SerializeField] private float minDuration = 1;
    [SerializeField] private float maxDuration = 15;
    [SerializeField] private float durationIncreaseRate = 0.5f;

    private TrailRenderer trail;

    private float currentDuration;


    public void Init(int score)
    {
        trail = GetComponentInChildren<TrailRenderer>();

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
    }
}

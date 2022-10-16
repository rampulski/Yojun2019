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


    // Start is called before the first frame update
    void Start()
    {
        currentDuration = minDuration;

        trail = GetComponentInChildren<TrailRenderer>();
        trail.time = currentDuration;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseDuration()
    {
        currentDuration = Mathf.Clamp(currentDuration + durationIncreaseRate, minDuration, maxDuration);
        trail.time = currentDuration;
    }
}

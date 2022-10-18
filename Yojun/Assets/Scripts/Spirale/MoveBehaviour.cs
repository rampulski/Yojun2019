using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBehaviour : MonoBehaviour
{
    [SerializeField] private float minSpeed = 2;
    [SerializeField] private float maxSpeed = 20;

    private float currentSpeed;
    private float currentSpeedBoost;
    private bool stopped;


    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = minSpeed;
        currentSpeedBoost = 0;
        stopped = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!stopped)
            transform.position += transform.right * currentSpeed * Time.deltaTime;
    }

    public void Resume()
    {
        stopped = false;
    }

    public void Stop()
    {
        stopped = true;
    }

    public void IncreaseSpeedBoost(float amount)
    {
        currentSpeedBoost += amount;
        currentSpeed = Mathf.Lerp(minSpeed, maxSpeed, currentSpeedBoost);
    }

    public float GetSpeedBoost()
    {
        return currentSpeedBoost;
    }

    public void SetSpeedBoost(float amount)
    {
        currentSpeedBoost = amount;
        currentSpeed = Mathf.Lerp(minSpeed, maxSpeed, currentSpeedBoost);
    }

    public float GetSpeed()
    {
        return currentSpeed;
    }
}

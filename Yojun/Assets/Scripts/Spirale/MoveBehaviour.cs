using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBehaviour : MonoBehaviour
{
    [SerializeField] private float minSpeed = 2;
    [SerializeField] private float maxSpeed = 20;

    private SkidBehaviour skidBehaviour;

    private float currentSpeed;
    private bool stopped;


    // Start is called before the first frame update
    void Start()
    {
        skidBehaviour = GetComponent<SkidBehaviour>();

        currentSpeed = minSpeed;
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

    public void BoostSpeed(float boost)
    {
        currentSpeed = Mathf.Lerp(minSpeed, maxSpeed, boost);
    }

    public float GetSpeed()
    {
        return currentSpeed;
    }
}

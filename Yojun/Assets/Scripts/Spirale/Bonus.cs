using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    [SerializeField] private BonusKind bonusKind;
    [SerializeField, Range(-1, 1)] private float gain;
    [SerializeField] private float duration;
    [SerializeField] private float activationDelay;

    private Rigidbody rb;

    private float timer;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        timer = 0;

        rb.useGravity = true;
        rb.isKinematic = false;
        GetComponent<BoxCollider>().isTrigger = false;

        rb.AddExplosionForce(75, transform.position, 0.8f);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= activationDelay)
        {
            rb.useGravity = false;
            rb.isKinematic = true;
            GetComponent<BoxCollider>().isTrigger = true;
        }
    }

    public BonusKind GetKind()
    {
        return bonusKind;
    }

    public float GetGain()
    {
        return gain;
    }

    public float GetDuration()
    {
        return duration;
    }
}

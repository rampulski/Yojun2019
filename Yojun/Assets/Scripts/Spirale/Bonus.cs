using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    [SerializeField] private BonusKind bonusKind;
    [SerializeField, Range(-1, 1)] private float gain;
    [SerializeField] private float duration;
    [SerializeField] private float activationDelay;
    [SerializeField] private Material neutralMaterial;

    private Rigidbody rb;
    private Material mat;

    private float timer;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        timer = 0;

        rb.useGravity = true;
        rb.isKinematic = false;
        GetComponent<BoxCollider>().isTrigger = false;
        mat = GetComponent<MeshRenderer>().material;
        GetComponent<MeshRenderer>().material = neutralMaterial;

        rb.AddExplosionForce(75, transform.position, 0.8f);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= activationDelay)
        {
            if (rb.velocity.magnitude < 0.01f)
            {
                rb.useGravity = false;
                rb.isKinematic = true;
                GetComponent<BoxCollider>().isTrigger = true;

                GetComponent<MeshRenderer>().material = mat;
            }
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

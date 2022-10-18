using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRotation : MonoBehaviour
{
    private bool forward;

    void Start()
    {
        forward = true;
    }

    void Update()
    {
        if (forward)
            transform.Rotate(transform.right, 60 * Time.deltaTime);
        else
            transform.Rotate(transform.right, -60 * Time.deltaTime);

        //if (transform.localRotation.eulerAngles.x >= 180)
        //    forward = false;
        //else
        //    forward = true;
    }
}

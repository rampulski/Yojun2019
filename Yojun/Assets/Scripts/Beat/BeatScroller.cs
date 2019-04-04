using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{

    private bool hasStarted;

   private GameObject[] beatLines;

    void Start()
    {
        beatLines = GameObject.FindGameObjectsWithTag("BeatLine");
    }

    void Update()
    {

        if (!hasStarted)
        {
            if (Input.anyKeyDown)
            {
                hasStarted = true;
            }
        }
        else
        {

            if (BPM.beatD16)
            {
                UpdateBeatLine();
            }
        }
    }

    private void UpdateBeatLine()
    {
        for (int i = 0; i < beatLines.Length; i++)
        {
            beatLines[i].transform.Rotate(new Vector3(0, 0, 7.5f/4f));
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPM : MonoBehaviour
{

    private BPM BPMInstance;
    public float bpm;
    private float beatInterval, beatTimer, beatIntervalD16, beatTimerD16;
    public static bool beatFull, beatD16;
    public static int beatCountFull, beatCountD16;


    void Start()
    {
        if (BPMInstance != null && BPMInstance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            BPMInstance = this; 

        }
    }

    void Update()
    {
        BeatDetection();
    }

    void BeatDetection()
    {
        beatFull = false;
        beatInterval = 60 / bpm;
        beatTimer += Time.deltaTime;

        if (beatTimer >= beatInterval)
        {
            beatTimer -= beatInterval;
            beatFull = true;
            beatCountFull ++;
            Debug.Log("BEAT");
        }


        beatD16 = false;
        beatIntervalD16 = beatInterval / 64;
        beatTimerD16 += Time.deltaTime;

        if (beatTimerD16 >= beatIntervalD16)
        {
            beatTimerD16 -= beatIntervalD16;
            beatD16 = true;
            beatCountD16++;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio; 

public class PlayerStrummingBar : MonoBehaviour
{

    private InputManager inputManager;
    private bool inputOn;
    private bool inputOk;
    [SerializeField]
    public int playerNumber;

    private bool hasStarted;

    public bool IsPressed;
    private float timer;

    private AudioSource aS;

    private Color[] colors = new Color[12];
    private Color myColor;

    private SpriteRenderer sR;

    void Start()
    {
        inputManager = GameObject.FindObjectOfType<InputManager>();
        aS = GetComponent<AudioSource>();
        sR = GetComponent<SpriteRenderer>();

        colors[0] = new Color(1, 0, 0);
        colors[1] = new Color(1, 0.5f, 0);
        colors[2] = new Color(1, 1, 0);
        colors[3] = new Color(0.5f, 1, 0);
        colors[4] = new Color(0, 1, 0);
        colors[5] = new Color(0, 1, 0.5f);
        colors[6] = new Color(0, 1, 1);
        colors[7] = new Color(0, 0.5f, 1);
        colors[8] = new Color(0, 0, 1);
        colors[9] = new Color(0.5f, 0, 1);
        colors[10] = new Color(1, 0, 1);
        colors[11] = new Color(1, 0, 0.5f);

        myColor = colors[playerNumber - 1];
        sR.color = myColor;
    }


    void Update()
    {
        inputOn = inputManager.inputPlayersPressed[playerNumber - 1];

        if (!hasStarted)
        {
            if (Input.anyKeyDown)
            {
                hasStarted = true;
            }
        }
        else
        {
            timer += Time.deltaTime;

            if (inputOn && timer > 0.01f)
            {
                inputOk = true;
                timer = 0;
            }

            if (inputOk && timer < 0.01f)
            {
                PressButton(true);
                inputOk = false;
            }
            else
            {
                PressButton(false);
            }
        }

    }

    public void PressButton(bool b)
    {
        if (b)
        {
            GetComponent<SpriteRenderer>().color = Color.white;
            IsPressed = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = myColor;
            IsPressed = false;
        }
    }

    public void PlayNote(AudioClip clip, AudioMixerGroup channel)
    {

            aS.PlayOneShot(clip);

    }
}

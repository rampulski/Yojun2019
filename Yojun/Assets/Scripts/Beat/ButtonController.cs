using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;

    private Color colorPressed;
    private Color colorUnpressed;

    private InputManager inputManager;
    private bool inputOn;

    public int playerNumber;


    void Start()
    {
        inputManager = GameObject.FindObjectOfType<InputManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        colorPressed = Color.white;
        colorUnpressed = Color.gray;


    }

    void Update()
    {
        inputOn = inputManager.inputPlayersPressed[playerNumber - 1];

        if (inputOn)
        {
            spriteRenderer.color = colorPressed;
        }
        else
        {
            spriteRenderer.color = colorUnpressed;

        }
    }
}

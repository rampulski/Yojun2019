using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{

    public int playerNumber;
    public Rotate rotationScript;
    public bool inputOn;
    public int[] teams;
    private InputManager inputManager;
    public GameObject instanceplayerPrefab;
    public GameObject PlayerFinal;

    public int team;

    public GameMenu gameMenuScript;
    public float timeToStopPlaying;
    public float timeToInstantiatePlayer;

    public float timer_a;
    public float timer_b;

    private LineRenderer lineRenderer;

     void Start()
    {
        inputManager = GameObject.FindObjectOfType<InputManager>();
        gameMenuScript = GameObject.Find("GameManager").GetComponent<GameMenu>();

        timer_a = 0;

        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.startColor = Color.white;
        lineRenderer.endColor = Color.yellow;

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        inputOn = inputManager.inputPlayersPressed[playerNumber - 1];

        if (instanceplayerPrefab == null)
        {
            timer_b += Time.deltaTime;
            lineRenderer.SetPosition(1, transform.position);
        }

        if (!GameObject.FindObjectOfType<Score>().gameOver)
        {
            if (inputOn && instanceplayerPrefab == null && timer_b >= timeToInstantiatePlayer)
            {
                timer_b = 0;

                InstantiatePlayer();
            }
        }

        if (instanceplayerPrefab != null)
        {
            lineRenderer.SetPosition(1, instanceplayerPrefab.transform.position);

            rotationScript.rotate();
            if (inputOn)
            {
                rotationScript.isRotating = false; // Quand la touche est appuyé, la rotation s'arrete
                rotationScript.Propulsate(); // Activation de la vitesse
                timer_a = 0;
            }

            if (!inputOn)
            {
                rotationScript.isRotating = true; // Quand la touche est relaché, la rotation reprend
                rotationScript.PropulsateStop();// // Désactivation de la vitesse

                if (rotationScript.isScoring == false)
                {
                    timer_a += Time.deltaTime;

                }
            }
        }

        if (timer_a > timeToStopPlaying)
        {
            PlayerStopPlaying();
        }


    }

    public void InstantiatePlayer()
    {
        instanceplayerPrefab = Instantiate(PlayerFinal, transform, false);
        rotationScript = instanceplayerPrefab.GetComponentInChildren<Rotate>();

       if (team == 0)
        {
            if (gameMenuScript.numberPlayerA <= gameMenuScript.numberPlayerB)
            {
                gameMenuScript.numberPlayerA += 1;
                team = 1;
            }
            else
            {
                gameMenuScript.numberPlayerB += 1;
                team = 2;
            }
        }

    }

    void PlayerStopPlaying()
    {
        if (team == 1)
        {
            gameMenuScript.numberPlayerA -= 1;
        }
        if (team ==2)
        {
            gameMenuScript.numberPlayerB -= 1;
        }

        team = 0;

        Destroy(instanceplayerPrefab);

    }


}

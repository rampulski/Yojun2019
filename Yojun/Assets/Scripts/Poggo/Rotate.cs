using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// [OneScript] \\

/* Rotation + Speed + Boost 
         * Particle */


public class Rotate : MonoBehaviour
{
    public float rotationspeed; // Speed de la rotation
    public float basespeed; // Vitesse de base
    public bool isRotating; // Pour désactiver la rotation en appuyant sur une touche$
    public ParticleSystem motor; // Pour les particles
    public Transform target; // Prend la position de la cible au milieu du world
    public float timer;
    public float timeToScore;
    public int scoreTeamTwo;
    public int scoreTeamOne;

    private Transform player_teamColor;

    public Score scoreScript;

    public bool isScoring;

    private Color colorTeamOne;
    private Color32 colorTeamTwo;


    // START \\


    void Start()
    {
        isRotating = true;
        //motor = GetComponentInChildren<ParticleSystem>();
        target = GameObject.Find("Target").GetComponent<Transform>();
        Vector3 vtc = target.transform.position - transform.position;
        transform.LookAt(transform.position + new Vector3(0, 0, 1), -vtc);

        scoreScript = GameObject.Find("ScoringZone").GetComponent<Score>();
        player_teamColor = GetComponentsInChildren<Transform>()[1];
         colorTeamOne = Color.cyan;
        colorTeamTwo = new Color32(255, 64, 127,255);
        


        if (GetComponentInParent<PlayerSpawner>().team == 1)
        {
            player_teamColor.GetComponent<SpriteRenderer>().color = colorTeamOne;
        }
        if (GetComponentInParent<PlayerSpawner>().team == 2)
        {
            player_teamColor.GetComponent<SpriteRenderer>().color = colorTeamTwo;
        }

    }


    // MISE A JOUR \\


    void FixedUpdate()
    {

        if (isScoring)
        {
            //timer += Time.deltaTime;
            player_teamColor.localScale += new Vector3 (0.0007f,0.0007f, 1);
            if (player_teamColor.localScale.x >= 0.75f && !scoreScript.gameOver)
            {
                if (GetComponentInParent<PlayerSpawner>().team == 1)
                {
                    scoreScript.ScoringOne();
                }
                if (GetComponentInParent<PlayerSpawner>().team == 2)
                {
                    scoreScript.ScoringTwo();
                }
               // timer = 0;
                player_teamColor.localScale = new Vector3(0.2f, 0.2f, 1);
            }
        }

        if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("End") == true)
        {
            Destroy(gameObject);
        }
    }

    public void Propulsate()
    {
        GetComponent<Rigidbody2D>().AddForce(-transform.up * basespeed); // Addforce a l'inverse de Y (-) sur le rigidbody de la boule
        motor.Play();
    }

    public void PropulsateStop() // Arret de la vitesse, des particles
    {
        motor.Stop();
    }

    public void rotate() // La rotation
    {
        if (isRotating == true)
        {
            transform.Rotate(0, 0, 10 * Time.deltaTime * rotationspeed); // Rotation en fonction d'une variable défini * temps * speed
        }

    }


void OnTriggerEnter2D(Collider2D coll)
    {      
        if (coll.gameObject == GameObject.Find("ScoringZone"))
        {
            isScoring = true;           
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject == GameObject.Find("ScoringZone"))
        {
            isScoring = false;         
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (!GameObject.FindObjectOfType<Score>().gameOver)
        {
            if (coll.gameObject.tag == "Circle")
            {
                coll.gameObject.GetComponent<Animator>().Play("Circle");
            }

            if (coll.gameObject.tag == "Triangle")
            {
                coll.gameObject.GetComponent<Animator>().Play("Triangle");
            }

            if (coll.gameObject.tag == "Chevron")
            {
                coll.gameObject.GetComponent<Animator>().Play("Chevron");
            }

        }

    }

}
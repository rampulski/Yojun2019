using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingStar : MonoBehaviour {

    private GameObject turret;
    public int playerNumber;

    private InputManager inputManager;
    private bool inputOn;

    public List<GameObject> starsTaken;
    private float radius;

    private float timerScale;
    public float timerScaleMax;


    void Start () {

        inputManager = GameObject.FindObjectOfType<InputManager>();
        turret = transform.parent.GetChild(0).gameObject;
        playerNumber = turret.GetComponent<PlayerTurret>().playerNumber;
        GetComponent<SpriteRenderer>().color = transform.parent.GetChild(0).GetChild(0).gameObject.GetComponent<SpriteRenderer>().color;
        radius = 0.03f;
    }

    void Update () {

        inputOn = inputManager.inputPlayersPressed[playerNumber - 1];

       

        if (inputOn)
        {
            transform.localScale += new Vector3(radius, radius, 0f);
            timerScale += Time.deltaTime;
        }
        else
        {
            DestroyBullet();
        }

        if (transform.localScale.x >4)
        {
            DestroyBullet();
        }
    }

     void OnTriggerEnter2D(Collider2D other)
     {
        if (other.tag == "Star")
        {
            if (playerNumber == other.GetComponent<Stars>().possessingPlayer && other.GetComponent<Stars>().taken == false)
            {
                starsTaken.Add(other.gameObject);
            }
        }
     }

    void DestroyBullet()
    {
        if (starsTaken.Count > 1)
        {
            for (int i = 0; i < starsTaken.Count; i++)
            {
                if (starsTaken[i].GetComponent<Stars>().taken == false)
                {
                    if (i != starsTaken.Count - 1)
                    {
                        starsTaken[i].GetComponent<LineRenderer>().SetPosition(0, Vector3.zero);
                        starsTaken[i].GetComponent<LineRenderer>().SetPosition(1, starsTaken[i].transform.InverseTransformPoint(starsTaken[i + 1].transform.position));
                    }
                    else
                    {
                        starsTaken[i].GetComponent<LineRenderer>().SetPosition(0, Vector3.zero);
                        starsTaken[i].GetComponent<LineRenderer>().SetPosition(1, starsTaken[i].transform.InverseTransformPoint(starsTaken[0].transform.position));

                    }
                    starsTaken[i].GetComponent<LineRenderer>().startColor = GetComponent<SpriteRenderer>().color;
                    starsTaken[i].GetComponent<LineRenderer>().endColor = GetComponent<SpriteRenderer>().color;

                }

            }
            for (int i = 0; i < starsTaken.Count; i++)
            {
                starsTaken[i].GetComponent<Stars>().taken = true;
                starsTaken[i].GetComponent<Stars>().constellated = true;
                turret.GetComponent<PlayerTurret>().addConstellatedStars();
            }

        }
        Destroy(gameObject);
    }
}

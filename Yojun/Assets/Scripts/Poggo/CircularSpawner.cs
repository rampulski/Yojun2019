using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularSpawner : MonoBehaviour {

    public GameObject go;
    public SpriteRenderer[] spriteColors;
    private GameObject scoringZone;


    public int goNumber;

    private Randomize randomize;

    private float angle;
    private GameObject _go;

    [Range(1.5f, 7f)]
    public float dist;

    [Range(-2f, 2f)]
    public float speed;

    void Awake()
    {
        randomize = GameObject.FindObjectOfType<Randomize>();


       //if (!randomize.randomized)
       //{
       //    if (gameObject.name == "Triangles")
       //    {
       //        goNumber = randomize.triangles_spawn_notRandom;
       //        speed = randomize.triangles_rotate_notRandom;
       //    }
       //    if (gameObject.name == "Circles")
       //    {
       //        goNumber = randomize.circles_spawn_notRandom;
       //        speed = randomize.circles_rotate_notRandom;
       //    }
       //    if (gameObject.name == "Chevrons")
       //    {
       //        goNumber = randomize.chevrons_spawn_notRandom;
       //        speed = randomize.chevrons_rotate_notRandom;
       //    }
       //
       //    Spawn();
       //}
       //
    }

    void Start () {


        //scoringZone = GameObject.Find("ScoringZone");

       // if (randomize.randomized)
       // {
            if (gameObject.name == "Triangles")
            {
                goNumber = randomize.triangles_spawn;
                speed = randomize.triangles_rotate;
            }
            if (gameObject.name == "Circles")
            {
                goNumber = randomize.circles_spawn;
                speed = randomize.circles_rotate;
            }
            if (gameObject.name == "Chevrons")
            {
                goNumber = randomize.chevrons_spawn;
                speed = randomize.chevrons_rotate;
            }
            Spawn();
       // }

		
	}
	
	void Update () {

        if (randomize.rotating)
        {
            transform.Rotate(Vector3.forward * speed);

        }

    }

    void Spawn()
    {

        for (int i = 0; i < goNumber; i++)
        {
            _go = Instantiate(go, Vector2.zero, Quaternion.AngleAxis(angle, Vector3.forward), gameObject.transform);
            _go.transform.Translate(transform.up * dist);
            angle += 360 / goNumber;
            if (i<5)
            {
                _go.GetComponent<SpriteRenderer>().color = Color.cyan;

            }
        }

       //spriteColors = scoringZone.GetComponentsInChildren<SpriteRenderer>();
       //
       //for (int i = 0; i < 5; i++)
       //{
       //    spriteColors[i].color = Color.cyan;
       //}
    }



}

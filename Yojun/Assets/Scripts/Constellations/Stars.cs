using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour {

    public int possessingPlayer;
    private float scaleRand;
    private float alphaRand;
    private float angleRand;
    private GameObject center;
    public bool taken;
    private StarSpawner starSpawnerScript;


    public bool constellated;

	void Start () {

        scaleRand = Random.Range(0.08f, 0.20f);
        alphaRand = Random.Range(0.5f,1f);
        angleRand = Random.Range(0.007f, 0.025f);
        transform.localScale = new Vector2(scaleRand, scaleRand);
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaRand);
        center = GameObject.Find("Center");
        starSpawnerScript = GameObject.FindObjectOfType<StarSpawner>();

    }

    void Update () {

        if (!taken)
        {
            transform.RotateAround(center.transform.position, Vector3.forward, scaleRand * 0.08f);
        }
        else
        {
            transform.RotateAround(center.transform.position, Vector3.forward, 0.17f * 0.08f);
        }

    }

    void OnCollisionEnter2D(Collision2D coll)
    {

        if (possessingPlayer == 0)
        {
            starSpawnerScript.numberOfStars -= 1;
        }
        if (!taken)
        {
            GetComponent<SpriteRenderer>().color = coll.gameObject.GetComponent<Bullet>().myColor;
            possessingPlayer = coll.gameObject.GetComponent<Bullet>().playerNumber;

        }

        coll.gameObject.GetComponent<Bullet>().lifeTimer = 0;

    }


}

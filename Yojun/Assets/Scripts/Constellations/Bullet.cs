using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public static Bullet _myBullet;

    public GameObject turret;

    private int numberOfCollisions;
    public TrailRenderer trailRenderer;

    public int playerNumber;

    private Color[] colors = new Color[12];
    public Color myColor;

    public float lifeTimer;
    public float speed;

    void Start () {

        turret = transform.parent.GetChild(0).gameObject;
        GetComponent<Rigidbody2D>().AddForce(turret.transform.up * speed, ForceMode2D.Force);
        trailRenderer = GetComponent<TrailRenderer>();
        numberOfCollisions = -1;

        playerNumber = turret.GetComponent<PlayerTurret>().playerNumber;
     
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

        turret.GetComponentInChildren<SpriteRenderer>().color = myColor;
        turret.GetComponentsInChildren<SpriteRenderer>()[1].color = myColor;

        GetComponent<TrailRenderer>().startColor = myColor;
        GetComponent<TrailRenderer>().endColor = myColor;

    }

    void Update () {

        lifeTimer += Time.deltaTime;

        if (lifeTimer >= 3)
        {
            Destroy(gameObject);
        }


    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "Border")
        {
            Destroy(gameObject);
        }

        if(coll.gameObject.CompareTag("Star")) {

            ParticleSystem ps = GetComponent<ParticleSystem>();

            ParticleSystem.EmitParams emitOverride = new ParticleSystem.EmitParams();
            var main = ps.main;
            main.startColor = myColor;
            emitOverride.startLifetime = 10f;
            ps.Emit(emitOverride, 20);

        }
    }


}

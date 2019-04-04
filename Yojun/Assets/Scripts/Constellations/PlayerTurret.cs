using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurret : MonoBehaviour {

    private GameObject center;
    public GameObject bullet;
    public GameObject myBullet;
    public GameObject explodingStar;
    private GameObject myExplodingStar;
    public Transform target;
    public float rotationSpeed;
    private InputManager inputManager;
    private StarSpawner starSpawnerScript;
    private Transform circleScoreTransform;

    public bool inputOn;

    private bool isRotatingRight;

    private float timer;
    public float timerRotation;
    private float timeBetweenRotation;
    private Quaternion startRotation; 

    public int playerNumber;
    public float constellatedStars;
    public float constellatedStarsNeededToWin;

    private bool canShoot;
    private bool canExplode;
    private float timeToShoot;
    private bool exploding;

    private bool input;
    private float radius;
    private float circleScoreTranformSize;

    private bool canEnd;

    void Start () {

        center = GameObject.Find("Center");
        canShoot = true;
        canEnd = true;

        rotationSpeed = 1.5f;

        inputManager = GameObject.FindObjectOfType<InputManager>();
        starSpawnerScript = GameObject.FindObjectOfType<StarSpawner>();
        circleScoreTransform = GetComponentsInChildren<Transform>()[2];

        Vector3 difference = center.transform.position - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotZ);
        transform.rotation *= Quaternion.Euler(0, 0, -180);
        startRotation = transform.rotation;
        timeBetweenRotation = 2f;
        timerRotation = timeBetweenRotation * 0.33f;
        constellatedStarsNeededToWin = 25.00f;
        constellatedStars = 0.00f;

        circleScoreTranformSize = 0.00f;
    }

    void Update()
    {
        circleScoreTranformSize = constellatedStars / constellatedStarsNeededToWin;
        circleScoreTransform.localScale = Vector3.Lerp(new Vector3(0.0f, 0.0f, 0.1f), new Vector3(0.40f, 0.40f,0.1f), circleScoreTranformSize);

        if (constellatedStars >= constellatedStarsNeededToWin && canEnd)
        {
            StartCoroutine(starSpawnerScript.GameEnding());
            canEnd = false;
        }
    }

    void FixedUpdate () {

        inputOn = inputManager.inputPlayersPressed[playerNumber - 1];
        timer += Time.deltaTime;
        timerRotation += Time.deltaTime;

        if (inputOn && timer > 0.3f)
        {
            input = true;
            timer = 0;
        }

        if (input && starSpawnerScript.hasStarted)
        {
            Shoot();
            input = false;
        }
        else
        {
            Rotate();
        }
    }

    void Rotate()
    {
        float angle =  ( Mathf.Sin(Time.time * rotationSpeed) + 1.0f) / 2.0f * 180.0f;
        transform.rotation = startRotation * Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void Shoot()
    {
        if (myBullet == null && myExplodingStar == null)
        {
            myBullet = Instantiate(bullet, transform.position, Quaternion.identity, transform.parent);
        }
        else if (myExplodingStar == null)
        { 
            Destroy(myBullet);
            myExplodingStar = Instantiate(explodingStar, myBullet.transform.position, Quaternion.identity, transform.parent);
        }
    }

    public void addConstellatedStars()
    {
        constellatedStars ++;
    }
}

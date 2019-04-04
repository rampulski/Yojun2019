using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour {

    //THIS SCRIPT MANAGE ALL SCORE RELATED THINGS\\

    public int scoreteamOne, scoreteamTwo;

    public SpriteRenderer[] spriteColors;

    private GameObject player;

    PlayerSpawner playerTeamNum;

    private Color32 colorTeamOne;
    private Color32 colorTeamTwo;

    public GameObject scoringPoint;
    private GameObject scoring;

    private GameObject scoringPointAnim;

    private GameObject[] circles;
    private GameObject[] triangles;
    private GameObject[] chevrons;

    public bool gameOver;
    private bool canWin;

    void Start () {

        gameOver = false;
        canWin = true;

        scoreteamOne = 5;
		scoreteamTwo = 5;

        colorTeamOne = Color.cyan;
        colorTeamTwo = new Color32(255, 64, 127, 255);

        player = GameObject.Find("Player");

        spriteColors = GetComponentsInChildren<SpriteRenderer>();
        scoringPointAnim = GameObject.Find("ScoringPointAnim");
        
        scoring = GameObject.FindGameObjectWithTag("Scoring");
       //
       //for (int i = 0; i < scoreteamOne; i++)
       //{
       //    spriteColors[i].color = Color.cyan;
       //}

    }

    void Update () {

        if (scoreteamOne == 10 && canWin)
        {
            StartCoroutine(YouWin(colorTeamOne));
            canWin = false;
        }
        if (scoreteamTwo == 10 && canWin)
        {
            StartCoroutine(YouWin(colorTeamTwo));
            canWin = false;
        }

    }

    public void ScoringOne()
    {
        scoreteamOne += 1;
        scoreteamTwo -= 1;
        spriteColors = GetComponentsInChildren<SpriteRenderer>();

        GameObject go = new GameObject();
        go = Instantiate(scoringPoint, Vector3.zero, Quaternion.identity, scoringPointAnim.transform);
        go.GetComponent<SpriteRenderer>().color = colorTeamOne;

        if (scoreteamOne < 10)
        {
        }

        for (int i = 0; i < scoreteamOne; i++)
        {
            spriteColors[i].color = Color.cyan;

        }

    }

    public void ScoringTwo()
    {
        scoreteamOne -= 1;
        scoreteamTwo += 1;
        spriteColors = GetComponentsInChildren<SpriteRenderer>();

        GameObject go = new GameObject();
        go = Instantiate(scoringPoint, Vector3.zero, Quaternion.identity, scoringPointAnim.transform);
        go.GetComponent<SpriteRenderer>().color = colorTeamTwo;

        if (scoreteamTwo < 10)
        {
        }
        for (int i = scoreteamOne; i < 10; i++)
        {
            spriteColors[i].color = new Color32(255, 64, 127, 255);

        }
    
    }

    public IEnumerator YouWin(Color32 col)
    {
        gameOver = true;

        scoring.GetComponent<SpriteRenderer>().color = col;
        scoring.GetComponent<Animator>().Play("ScoringWin");

        foreach (var player in GameObject.FindGameObjectsWithTag("Player"))
        {
            if (player.GetComponentsInChildren<SpriteRenderer>()[1].color == col)
            {
                player.GetComponent<Animator>().Play("Player_winner");
            }
            else
            {
                player.GetComponent<Animator>().Play("Player_destruction");
            }           
        }

        StartCoroutine("DestroyTriangles");
        StartCoroutine("DestroyCircles");
        StartCoroutine("DestroyChevrons");

        GameObject go = new GameObject();

        for (int i = 0; i < 3; i++)
        {
            go = Instantiate(scoringPoint, Vector3.zero, Quaternion.identity, scoringPointAnim.transform);
            go.GetComponent<SpriteRenderer>().color = col;

            yield return new WaitForSeconds(3f);
        }

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(0);
        yield return null;

    }


    IEnumerator DestroyChevrons()
    {

        foreach (var chevron in GameObject.FindGameObjectsWithTag("Chevron"))
        {
            chevron.GetComponent<Animator>().Play("Chevron_end",0);
            chevron.GetComponentsInChildren<Animator>()[1].Play("Chevron_end_contour",0);
            yield return new WaitForSeconds(0.3f);
        }

    }
    IEnumerator DestroyTriangles()
    {
        foreach (var triangle in GameObject.FindGameObjectsWithTag("Triangle"))
        {
            triangle.GetComponent<Animator>().Play("Triangle_end",0);
            triangle.GetComponentsInChildren<Animator>()[1].Play("Triangle_end_contour",0);
            yield return new WaitForSeconds(0.3f);
        }

    }
    IEnumerator DestroyCircles()
    {
        foreach (var circle in GameObject.FindGameObjectsWithTag("Circle"))
        {
            circle.GetComponent<Animator>().Play("Circle_end",0);
            circle.GetComponentsInChildren<Animator>()[1].Play("Circle_end_contour",0);
            yield return new WaitForSeconds(0.3f);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class StarSpawner : MonoBehaviour {


    public GameObject star;
    private GameObject stars;
    public int numberOfStars;
    public int minStars;

    public bool hasStarted;


    void Start () {

        stars = gameObject;
        StartCoroutine(CreateSky());
        hasStarted = true;

    }

    void Update () {

        if (numberOfStars <= minStars)
        {
            StartCoroutine(GameEnding());
        }
        if (Input.GetKeyDown(KeyCode.Comma))
        {
            StartCoroutine(GameEnding());
        }
	}

    IEnumerator CreateSky()
    {
        for (int i = 0; i < numberOfStars; i++)
        {
            Instantiate(star, randPos(), Quaternion.identity, stars.transform);
            yield return new WaitForSeconds(0.04f);
        }
    }

    Vector2 randPos()
    {
        Vector2 pos;
        pos = Random.insideUnitCircle * 7.5f;
        return pos;
    }

    public IEnumerator GameEnding()
    {
        hasStarted = false ;

        List<Stars> stars = GameObject.FindObjectsOfType<Stars>().ToList();

        for (int i = 0; i < stars.Count; i++)
        {
            if (!stars[i].constellated)
            {
                Destroy(stars[i].gameObject);
            }
            yield return new WaitForSeconds(.025f);
        }

        List<PlayerTurret> players = GameObject.FindObjectsOfType<PlayerTurret>().ToList();
        players = players.OrderBy(x => x.constellatedStars).ToList();

        for (int i = 0; i < players.Count; i++)
        {
            for (int j = 0; j < stars.Count; j++)
            {
                if (stars[j].possessingPlayer == players[i].playerNumber)
                {
                    if (stars[j] != null)
                    {
                        Destroy(stars[j].gameObject);
                        yield return new WaitForSeconds(.015f);
                    }
                }
            }
            yield return new WaitForSeconds(0.5f);
        }

        SceneManager.LoadScene(1);
        yield return null;
    }
}

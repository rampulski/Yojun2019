using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private GameObject shield;
    [SerializeField] private GameObject bottom;
    [SerializeField] private GameObject top;
    [SerializeField] private GameObject[] wheels;
    [SerializeField] private Transform[] bonusPrefabs;
    [SerializeField] private float bonusSpawnProbability;
    [SerializeField] private float startShieldDuration;

    private int playerIndex;
    private bool destroyed;


    public void Init(int index, Color color)
    {
        destroyed = false;
        playerIndex = index;
        bottom.GetComponent<Renderer>().material.SetColor("_EmissionColor", color);
        top.GetComponent<Renderer>().material.SetColor("_EmissionColor", color);
        for (int i = 0; i < wheels.Length; i++)
        {
            wheels[i].GetComponent<Renderer>().material.SetColor("_EmissionColor", color);
        }

        StartCoroutine(Shield(startShieldDuration));
    }

    public void IncreaseScore()
    {
        GameManager.instance.IncreaseScore(playerIndex);

        if (GetComponent<TrailBehaviour>())
            GetComponent<TrailBehaviour>().IncreaseDuration();
    }

    public void Kill()
    {
        destroyed = true;

        if (GetComponent<ExplodeIntoCubes>())
            GetComponent<ExplodeIntoCubes>().Explode();

        if (Random.value > 1f - bonusSpawnProbability)
        {
            int rand = Random.Range(0, bonusPrefabs.Length);

            Instantiate(bonusPrefabs[rand], transform.position, Quaternion.identity);
        }

        GameManager.instance.KillPlayer(playerIndex);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bonus"))
        {
            Bonus bonus = other.GetComponent<Bonus>();
            switch (bonus.GetKind())
            {
                case BonusKind.Minus:
                case BonusKind.Plus:
                    StartCoroutine(ChangeSpeed(bonus.GetGain()));
                    break;
                case BonusKind.Boost:
                    StartCoroutine(Boost(bonus.GetDuration()));
                    break;
                case BonusKind.Shield:
                    StartCoroutine(Shield(bonus.GetDuration()));
                    break;
            }

            Destroy(other.gameObject);
        }
    }

    private IEnumerator ChangeSpeed(float boost)
    {
        if (GetComponent<MoveBehaviour>())
            GetComponent<MoveBehaviour>().IncreaseSpeedBoost(boost);

        yield return null;
    }

    private IEnumerator Boost(float duration)
    {
        float speedBoost = 0;
        if (GetComponent<MoveBehaviour>())
        {
            speedBoost = GetComponent<MoveBehaviour>().GetSpeedBoost();

            GetComponent<MoveBehaviour>().IncreaseSpeedBoost(1);
        }

        yield return new WaitForSeconds(duration);

        if (GetComponent<MoveBehaviour>())
        {
            GetComponent<MoveBehaviour>().SetSpeedBoost(speedBoost);
        }
    }

    private IEnumerator Shield(float duration)
    {
        shield.SetActive(true);

        yield return new WaitForSeconds(duration);

        shield.SetActive(false);
    }

    public bool IsShieldActive()
    {
        return shield.activeSelf;
    }

    public bool IsDestroyed()
    {
        return destroyed;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private GameObject shield;
    [SerializeField] private Transform[] bonusPrefabs;
    [SerializeField] private float bonusSpawnProbability;
    [SerializeField] private float startShieldDuration;

    private int playerIndex;


    public void Init(int index)
    {
        playerIndex = index;

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
        float speed = 0;
        if (GetComponent<MoveBehaviour>())
        {
            speed = GetComponent<MoveBehaviour>().GetSpeed();

            GetComponent<MoveBehaviour>().IncreaseSpeedBoost(1);
        }

        yield return new WaitForSeconds(duration);

        if (GetComponent<MoveBehaviour>())
        {
            GetComponent<MoveBehaviour>().SetSpeed(speed);
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkidBehaviour : MonoBehaviour
{
    [SerializeField] private Transform turnLeftIndicator;
    [SerializeField] private Transform turnRightIndicator;
    [SerializeField] private float turnIndicatorTime;
    [SerializeField] private float speedBoostRate;
    [SerializeField] private float maxSpiralRadius;
    [SerializeField] private float spiralShrinkSpeed;

    private InputManager inputManager;
    private MoveBehaviour moveBehaviour;

    private int playerIndex;
    private float turnIndicatorTimer;
    private bool turnLeft;
    private bool killed;
    private float currentSpeedBoost;
    private float currentRadius;


    // Start is called before the first frame update
    void Start()
    {
        inputManager = InputManager.instance;
        moveBehaviour = GetComponent<MoveBehaviour>();

        turnIndicatorTimer = 0;
        turnLeft = false;
        killed = false;
        currentSpeedBoost = 0;
        currentRadius = maxSpiralRadius;
    }

    // Update is called once per frame
    void Update()
    {
        if (!killed)
        {
            if (inputManager.inputPlayersPressed[playerIndex])
            {
                float speed = 0;
                if (moveBehaviour)
                {
                    moveBehaviour.BoostSpeed(currentSpeedBoost);
                    speed = moveBehaviour.GetSpeed();

                    moveBehaviour.Stop();
                }

                if (turnLeft)
                {
                    transform.RotateAround(transform.position + (transform.up * currentRadius), Vector3.forward, ((speed * 360) / (2f * Mathf.PI * currentRadius)) * Time.deltaTime);
                }
                else
                {
                    transform.RotateAround(transform.position + (Quaternion.Euler(0, 0, 180) * transform.up * currentRadius), -Vector3.forward, ((speed * 360) / (2f * Mathf.PI * currentRadius)) * Time.deltaTime);
                }

                if (turnLeft)
                    Debug.DrawRay(transform.position, transform.up * currentRadius, Color.red);
                else
                    Debug.DrawRay(transform.position, Quaternion.Euler(0, 0, 180) * transform.up * currentRadius, Color.yellow);

                currentSpeedBoost += speedBoostRate * Time.deltaTime;
                currentRadius -= spiralShrinkSpeed * Time.deltaTime;

                currentRadius = Mathf.Clamp(currentRadius, 0, maxSpiralRadius);
            }
            else
            {
                turnIndicatorTimer += Time.deltaTime;
                if (turnIndicatorTimer >= turnIndicatorTime)
                {
                    turnIndicatorTimer = 0;
                    turnLeft = !turnLeft;

                    if (turnLeft)
                    {
                        turnLeftIndicator.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.red);
                        turnRightIndicator.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);
                    }
                    else
                    {
                        turnLeftIndicator.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);
                        turnRightIndicator.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.red);
                    }
                }

                currentRadius = maxSpiralRadius;

                moveBehaviour.Resume();
            }
        }

        if (currentRadius <= 0)
            StartCoroutine(Kill());
    }

    private IEnumerator Kill()
    {
        killed = true;

        yield return null;

        Destroy(gameObject);
    }

    public void SetPlayerNumber(int index)
    {
        playerIndex = index;
    }

    public float GetCurrentSpeedBoost()
    {
        return currentSpeedBoost;
    }
}

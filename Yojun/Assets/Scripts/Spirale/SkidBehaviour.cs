using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkidBehaviour : MonoBehaviour
{
    [SerializeField] private Transform turnLeftIndicator;
    [SerializeField] private Transform turnRightIndicator;
    [SerializeField] private float minTurnIndicatorTime;
    [SerializeField] private float maxTurnIndicatorTime;
    [SerializeField] private float speedBoostRate;
    [SerializeField] private float maxSpiralRadius;
    [SerializeField] private float spiralShrinkSpeed;

    private InputManager inputManager;
    private MoveBehaviour moveBehaviour;

    private int playerIndex;
    private float turnIndicatorTimer;
    private float currentTurnIndicatorTime;
    private bool ready;
    private bool turnLeft;
    private bool skidding;
    private bool killed;
    private float currentSpeedBoost;
    private float currentRadius;


    // Start is called before the first frame update
    void Start()
    {
        inputManager = InputManager.instance;
        moveBehaviour = GetComponent<MoveBehaviour>();

        turnLeftIndicator.GetComponent<SpriteRenderer>().enabled = false;
        turnRightIndicator.GetComponent<SpriteRenderer>().enabled = false;

        turnIndicatorTimer = 0;
        currentTurnIndicatorTime = maxTurnIndicatorTime;
        ready = false;
        turnLeft = false;
        skidding = false;
        killed = false;
        currentSpeedBoost = 0;
        currentRadius = maxSpiralRadius;
    }

    // Update is called once per frame
    void Update()
    {
        if (ready && !killed)
        {
            if (inputManager.inputPlayersPressed[playerIndex])
            {
                float speed = 0;
                if (moveBehaviour)
                {
                    moveBehaviour.BoostSpeed(currentSpeedBoost);
                    speed = moveBehaviour.GetSpeed();

                    if (!skidding)
                        moveBehaviour.Stop();
                }

                skidding = true;

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

                currentRadius = Mathf.Clamp(currentRadius - (spiralShrinkSpeed * Time.deltaTime), 0, maxSpiralRadius);
            }
            else
            {
                if (skidding)
                {
                    skidding = false;

                    SwitchTurnIndicatorDirection();

                    moveBehaviour.Resume();
                }

                turnIndicatorTimer += Time.deltaTime;
                if (turnIndicatorTimer >= currentTurnIndicatorTime)
                    SwitchTurnIndicatorDirection();

                currentRadius = maxSpiralRadius;
            }
        }

        if (currentRadius <= 0)
        {
            killed = true;
            GetComponent<Car>().Kill();
        }
    }

    public void Init(int index, float delay)
    {
        playerIndex = index;

        StartCoroutine(WaitToStart(delay));
    }

    private IEnumerator WaitToStart(float delay)
    {
        yield return new WaitForSeconds(delay);

        ready = true;
        turnLeft = Random.value > 0.5 ? true : false;
        ShowTurnIndicator();
    }

    private void SwitchTurnIndicatorDirection()
    {
        turnIndicatorTimer = 0;
        currentTurnIndicatorTime = Mathf.Lerp(maxTurnIndicatorTime, minTurnIndicatorTime, currentSpeedBoost);
        turnLeft = !turnLeft;

        ShowTurnIndicator();
    }

    private void ShowTurnIndicator()
    {
        turnLeftIndicator.GetComponent<SpriteRenderer>().enabled = turnLeft;
        turnRightIndicator.GetComponent<SpriteRenderer>().enabled = !turnLeft;
    }
}

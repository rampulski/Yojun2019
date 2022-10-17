using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    private MoveBehaviour moveBehaviour;


    // Start is called before the first frame update
    void Start()
    {
        moveBehaviour = GetComponent<MoveBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (GetComponent<Car>().IsShieldActive())
            {
                if (collision.gameObject.GetComponent<Car>().IsShieldActive())
                {
                    GetComponent<Car>().Kill();
                    collision.gameObject.GetComponent<Car>().Kill();
                }
                else
                {
                    collision.gameObject.GetComponent<Car>().Kill();
                }
            }
            else if (collision.gameObject.GetComponent<Car>().IsShieldActive())
            {
                GetComponent<Car>().Kill();
            }
            else
            {
                if (moveBehaviour.GetSpeed() < collision.gameObject.GetComponent<MoveBehaviour>().GetSpeed())
                {
                    GetComponent<Car>().Kill();

                    collision.gameObject.GetComponent<Car>().IncreaseScore();
                }
                else if (moveBehaviour.GetSpeed() > collision.gameObject.GetComponent<MoveBehaviour>().GetSpeed())
                {
                    collision.gameObject.GetComponent<Car>().Kill();

                    GetComponent<Car>().IncreaseScore();
                }
                else
                {
                    GetComponent<Car>().Kill();
                    collision.gameObject.GetComponent<Car>().Kill();
                }
            }
        }
    }
}

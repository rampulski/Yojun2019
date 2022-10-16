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
            if (moveBehaviour.GetSpeed() < collision.gameObject.GetComponent<MoveBehaviour>().GetSpeed())
            {
                if (gameObject.GetComponent<ExplodeIntoCubes>())
                    gameObject.GetComponent<ExplodeIntoCubes>().Explode();

                Destroy(gameObject);

                if (collision.gameObject.GetComponent<TrailBehaviour>())
                    collision.gameObject.GetComponent<TrailBehaviour>().IncreaseDuration();
            }
            else if (moveBehaviour.GetSpeed() > collision.gameObject.GetComponent<MoveBehaviour>().GetSpeed())
            {
                if (collision.gameObject.GetComponent<ExplodeIntoCubes>())
                    collision.gameObject.GetComponent<ExplodeIntoCubes>().Explode();

                Destroy(collision.gameObject);

                if (gameObject.GetComponent<TrailBehaviour>())
                    gameObject.GetComponent<TrailBehaviour>().IncreaseDuration();
            }
            else
            {
                if (gameObject.GetComponent<ExplodeIntoCubes>())
                    gameObject.GetComponent<ExplodeIntoCubes>().Explode();

                if (collision.gameObject.GetComponent<ExplodeIntoCubes>())
                    collision.gameObject.GetComponent<ExplodeIntoCubes>().Explode();

                Destroy(gameObject);
                Destroy(collision.gameObject);
            }
        }
    }
}

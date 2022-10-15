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
                Destroy(gameObject);
            }
            else if (moveBehaviour.GetSpeed() > collision.gameObject.GetComponent<MoveBehaviour>().GetSpeed())
            {
                Destroy(collision.gameObject);
            }
            else
            {
                Destroy(gameObject);
                Destroy(collision.gameObject);
            }
        }
    }
}

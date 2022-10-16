using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPart : MonoBehaviour
{
    public void Spawn(float minTimeToDie, float maxTimeToDie)
    {
        StartCoroutine(WaitAndDestroy(minTimeToDie, maxTimeToDie));
    }

    private IEnumerator WaitAndDestroy(float minTimeToDie, float maxTimeToDie)
    {
        yield return new WaitForSeconds(Random.Range(minTimeToDie, maxTimeToDie));

        Destroy(gameObject);
    }
}

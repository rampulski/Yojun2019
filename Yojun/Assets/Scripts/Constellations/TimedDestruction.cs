using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDestruction : MonoBehaviour {

	void Start () {

        Invoke("Destruction", 2f);
		
	}
	
	void Update () {
		
	}

    void Destruction()
    {
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triangle : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {

        if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("End") == true)
        {
            Destroy(gameObject);
        }

    }
}

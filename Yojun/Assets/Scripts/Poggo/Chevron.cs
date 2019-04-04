using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chevron : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("End") == true)
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayGabarit : MonoBehaviour {

    public SpriteRenderer gabarit;

	void Start () {

        gabarit = GameObject.Find("GabaritDebug").GetComponent<SpriteRenderer>();


    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.G))
        {
            gabarit.enabled = !gabarit.enabled;
        }
		
	}
}

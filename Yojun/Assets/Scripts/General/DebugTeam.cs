using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugTeam : MonoBehaviour {

    // Use this for initialization

    public GameObject gO;

	void Start () {


        

    }
	
	// Update is called once per frame
	void Update () {

       GetComponent<Text>().text =  gO.GetComponent<PlayerSpawner>().team.ToString();

    }
}

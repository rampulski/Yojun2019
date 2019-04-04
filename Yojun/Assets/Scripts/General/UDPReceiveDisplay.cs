using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UDPReceiveDisplay : MonoBehaviour {


    public GameObject udpReceive;

    private string udpPacket;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        udpPacket = udpReceive.GetComponent<UDPReceive>().lastReceivedUDPPacket;

        GetComponent<Text>().text = udpPacket;





    }
}

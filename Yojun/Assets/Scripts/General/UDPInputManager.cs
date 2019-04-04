using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UDPInputManager : MonoBehaviour {


   
    private string text;

    public bool[] inputPlayersPressed;

    public string[] maxSplittedPacket;



    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

        text = GetComponent<UDPReceive>().UDPTextReceived;

         maxSplittedPacket = text.Split('n');

        //INPUT from UDP 

        //inputReader();

        if (Input.GetKeyDown(KeyCode.Q))
        {
            inputPlayersPressed[0] = true;

        } else if (Input.GetKeyUp(KeyCode.Q))
        {
            inputPlayersPressed[0] = false;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            inputPlayersPressed[1] = true;

        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            inputPlayersPressed[1] = false;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            inputPlayersPressed[2] = true;

        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            inputPlayersPressed[2] = false;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            inputPlayersPressed[3] = true;

        }
        else if (Input.GetKeyUp(KeyCode.R))
        {
            inputPlayersPressed[3] = false;
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            inputPlayersPressed[4] = true;

        }
        else if (Input.GetKeyUp(KeyCode.T))
        {
            inputPlayersPressed[4] = false;
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            inputPlayersPressed[5] = true;

        }
        else if (Input.GetKeyUp(KeyCode.Y))
        {
            inputPlayersPressed[5] = false;
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            inputPlayersPressed[6] = true;

        }
        else if (Input.GetKeyUp(KeyCode.U))
        {
            inputPlayersPressed[6] = false;
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            inputPlayersPressed[7] = true;

        }
        else if (Input.GetKeyUp(KeyCode.I))
        {
            inputPlayersPressed[7] = false;
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            inputPlayersPressed[8] = true;

        }
        else if (Input.GetKeyUp(KeyCode.O))
        {
            inputPlayersPressed[8] = false;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            inputPlayersPressed[9] = true;

        }
        else if (Input.GetKeyUp(KeyCode.P))
        {
            inputPlayersPressed[9] = false;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            inputPlayersPressed[10] = true;

        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            inputPlayersPressed[10] = false;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            inputPlayersPressed[11] = true;

        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            inputPlayersPressed[11] = false;
        }



    }

 void inputReader()
    {

        int i;
        for (i = 0; i < maxSplittedPacket.Length; i++)
        {
            inputPlayersPressed[i] = maxSplittedPacket[i].Equals("1") ? true : false;
        }

    

    }

}

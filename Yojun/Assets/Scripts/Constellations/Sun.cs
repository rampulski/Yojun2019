using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Sun : MonoBehaviour {


    public Stars[] starsPossessed;
    public List<int> starsPossessedList;



	void Start () {

        starsPossessed = FindObjectsOfType<Stars>();



    }
	
	// Update is called once per frame
	void Update () {


        if (Input.GetKeyDown(KeyCode.C))
        {
            DrawConstellations();
        }
		
	}

    void DrawConstellations()
    {

        //starsPossessed = Physics2D.OverlapCircleAll(transform.position, 100, 8);
        starsPossessedList.Clear();

        for (int i = 0; i < FindObjectsOfType<Stars>().Length; i++)
        {
            starsPossessedList.Add(starsPossessed[i].possessingPlayer);           
        }
        int k = 0;
        for (int j = 0; j < starsPossessedList.Count; j++)
        {
            if (starsPossessed[j].possessingPlayer == 2)
            {
                starsPossessed[j].GetComponent<LineRenderer>().SetPosition(k,starsPossessed[j].transform.position);
                k++;
            }
            k = 0;

        }


    }
}

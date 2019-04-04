using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceUI : MonoBehaviour {

    private Randomize randomizeScript;

    public static InterfaceUI instance = null;

    void Start() {

        //Singleton
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
        DontDestroyOnLoad(transform.gameObject);

        randomizeScript = GameObject.FindObjectOfType<Randomize>();

        SetRotation();
    }

    void Update () {
		
	}

    public void SetRandomize()
    {
        randomizeScript.randomized = !randomizeScript.randomized;
    }

    public void SetRotation()
    {
        //randomizeScript.rotating = !randomizeScript.rotating;
    }

    void OnValueChanged()
    {
        //randomizeScript.randomized = !randomizeScript.randomized;
        //randomizeScript.rotating = !randomizeScript.rotating;
    }
}

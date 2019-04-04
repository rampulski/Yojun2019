using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomize : MonoBehaviour {


    public static Randomize instance = null;


    [HideInInspector]
    public int triangles_spawn;
    public int triangles_spawn_notRandom;

    [HideInInspector]
    public int circles_spawn;
    public int circles_spawn_notRandom;

    [HideInInspector]
    public int chevrons_spawn;
    public int chevrons_spawn_notRandom;

    [HideInInspector]
    public float triangles_rotate;
    public float triangles_rotate_notRandom;

    [HideInInspector]
    public float circles_rotate;
    public float circles_rotate_notRandom;

    [HideInInspector]
    public float chevrons_rotate;
    public float chevrons_rotate_notRandom;

    [HideInInspector]
    public bool randomized;
    [HideInInspector]
    public bool rotating;


    void Awake () {

       // //Singleton
       // if (instance == null)instance = this;
       // else if (instance != this)Destroy(gameObject);
       // DontDestroyOnLoad(transform.gameObject);

        triangles_spawn = Random.Range(3, 5);
        triangles_rotate = Random.Range(0, 0.1f);

        circles_spawn = Random.Range(9, 13);
        circles_rotate = Random.Range(0, 0.2f);

        chevrons_spawn = Random.Range(3, 7);
        chevrons_rotate = Random.Range(-0.1f,0);

        rotating = true;
    }



}

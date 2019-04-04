using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    public bool IsDestructive;
    public bool IsSwitchable;
    public bool TimedSwitch;
    private int Hits;
    public int hitCount;
    public SpriteRenderer _renderer;

    void Start()
    {

        _renderer = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
        if (IsDestructive == true)
        {
            _renderer.color = new Color32(255, 127, 0, 255);
        }
        if (IsDestructive == false)
        {
            _renderer.color = Color.white;
        }

    }



    void OnCollisionEnter2D(Collision2D coll)
    {




        if (IsDestructive == true)
        {
            Destroy(coll.gameObject);
        }


        if (IsSwitchable == true)
        {
            IsDestructive = !IsDestructive;
        }


        if (TimedSwitch == true)
        {
            Hits += 1;
            if (Hits >= hitCount && IsDestructive == false)
            {
                IsDestructive = true;
                Hits = 0;
            }
            if (Hits >= 1 && IsDestructive == true)
            {
                IsDestructive = false;
                Hits = 0;
            }
        }
    }
}

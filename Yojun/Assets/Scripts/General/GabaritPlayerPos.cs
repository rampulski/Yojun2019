using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GabaritPlayerPos : MonoBehaviour {

    private SpriteRenderer[] playerPosRenderer;
    private Transform[] playerPosTransform;

    [HideInInspector]
    public float scaleValue;
    private Color color;


    void Start () {

        playerPosRenderer = GetComponentsInChildren<SpriteRenderer>();
        playerPosTransform = GetComponentsInChildren<Transform>();

        scaleValue = playerPosTransform[1].localScale.x;

    }

    void Update () {


    }


   public void SwitchColor()
    {      
        if (color == Color.black)
        {
            color = Color.white;
        }
        else if (color == Color.white)
        {
            color = Color.black;
        }

        for (int i = playerPosRenderer.Length -1; i < playerPosRenderer.Length; i++)
        {
            playerPosRenderer[i].color = color;
        }      
    }

    public void ChangeSize()
    {     
        for (int i = 1; i < playerPosTransform.Length -1; i++)
        {
            playerPosTransform[i].localScale = new Vector3(scaleValue, scaleValue, 1);
        }
   }
}

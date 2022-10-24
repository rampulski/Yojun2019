using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GabaritPlayerPos : MonoBehaviour
{
    [SerializeField] private SpriteRenderer border;

    private Transform[] playerPosTransform;

    [HideInInspector]
    public float scaleValue;
    private Color color;


    void Start () {

        playerPosTransform = GetComponentsInChildren<Transform>();

        scaleValue = playerPosTransform[1].localScale.x;
    }

    void Update () {


    }


   public void SwitchBorderVisibility()
    {
        border.enabled = !border.enabled;
    }

    public void ChangeSize()
    {     
        for (int i = 1; i < playerPosTransform.Length -1; i++)
        {
            playerPosTransform[i].localScale = new Vector3(scaleValue, scaleValue, 1);
        }
   }
}

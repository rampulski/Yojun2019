using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    // SCRIPT POUR ADDFORCE EN FONCTION DE LA FLECHE \\

    /* Ajout d'une force défini par un float
     * en fonction de l'orientation de la flèche
     * Ajout des particules, simulation moteur */


public class ArrowForce : MonoBehaviour {

    private Rigidbody2D ballrigid;
    public ParticleSystem motor;
    public float speed1;




    // Départ \\


    void Start () {

        ballrigid = gameObject.GetComponentInParent<Rigidbody2D>(); // Obtention du Rigidbody de la boule
        motor = gameObject.GetComponentInChildren<ParticleSystem>(); // Obtention des particles

     
    }
	
	// Mise à jour \\


	void Update () {
   
	}

    public void Propulsate()
    {
        ballrigid.AddForce(-transform.up * speed1); // Addforce a l'inverse de Y (-) sur le rigidbody de la boule
        motor.Play();
    }

    public void PropulsateStop()
    {
        motor.Stop();

    }
}

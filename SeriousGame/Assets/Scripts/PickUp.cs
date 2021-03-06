﻿using UnityEngine;
using System.Collections;
//var pickSound:AudioClip;
public class PickUp : MonoBehaviour {
    AudioSource chompSound;
	LevelManager levelManager;
    void Start()
    {
		levelManager = GameObject.Find ("LevelManager").GetComponent<LevelManager> ();
        chompSound = GetComponent<AudioSource>();
    }

    void OnTriggerEnter (Collider other)
    {
        Debug.Log("Moved item to 0,0,-3 position");
        transform.position = new Vector3(0, 0, -3);
        chompSound.Play();

		levelManager.FoodCollected(this.name);
		levelManager.UpdateTextIngame ();
    }
 /*   void OnTriggerStay(Collider other)
    {
        Debug.Log("Stay Called.");
    }
    void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit Called.");
    }*/
}
  
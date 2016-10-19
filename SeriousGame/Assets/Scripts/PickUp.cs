using UnityEngine;
using System.Collections;
//var pickSound:AudioClip;
public class PickUp : MonoBehaviour {
    AudioSource chompSound;

    void Start()
    {
        chompSound = GetComponent<AudioSource>();
    }

    void OnTriggerEnter (Collider other)
    {
        Debug.Log("Moved item to 0,0,-3 position");
        transform.position = new Vector3(0, 0, -3);
        chompSound.Play();

        GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>().FoodCollected(this.name);
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
  
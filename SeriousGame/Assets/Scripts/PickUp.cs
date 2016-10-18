using UnityEngine;
using System.Collections;
//var pickSound:AudioClip;
public class PickUp : MonoBehaviour {

    void OnTriggerEnter (Collider other)
    {
        Debug.Log("Moved item to 0,0,-3 position");
        transform.position = new Vector3(0, 0, -3);
    //    AudioSource.PlayClipAtPoint(pickSound, transform.position);
        //Destroy(this.gameObject);
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
  
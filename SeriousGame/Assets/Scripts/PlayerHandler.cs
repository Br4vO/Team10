using UnityEngine;
using System.Collections;

public class PlayerHandler : MonoBehaviour {
    private Vector2 position;


	// Use this for initialization
	void Start () {
        position = new Vector2(0, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void MovePlayer(float xSwipeDirection, float ySwipeDirection)
    {
        position.x += xSwipeDirection;
        position.y += ySwipeDirection >= 0 ? ySwipeDirection : 0;//can only swipe up, not down
    }
}

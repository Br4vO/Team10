using UnityEngine;
using System.Collections;

public class PlayerHandler : MonoBehaviour {
    private Vector2 position;
    private int walkingCount = 23;
    float xOffset;
    float yOffset;
    Animation playerAnimation;


    // Use this for initialization
    void Start () {
        position = new Vector2(1, -1);
        playerAnimation = GetComponent<Animation>();
    }
	
	// Update is called once per frame
	void Update () {
	    if(walkingCount < 23)
        {
            ++walkingCount;
            transform.Translate(new Vector3(xOffset, 0, yOffset) * Time.deltaTime);
            if(walkingCount == 23)
            {
                playerAnimation.Play("Idle");
            }
        }

		if (gameObject.transform.position.z >= 5)
		{
			ResetLevel ();
		}
	}

    public void MovePlayer(float xSwipeDirection, float ySwipeDirection)
    {
        float temp = position.x + xSwipeDirection;
        if (walkingCount != 23 || temp > 2 || temp < 0)
        {
            return;
        }

        position.x = temp;
        position.y += ySwipeDirection >= 0 ? ySwipeDirection : 0;//can only swipe up, not down

        xOffset = xSwipeDirection;

        if(ySwipeDirection < 0)
        {
            //swiped down, do nothing
            yOffset = 0;
        }
        else
        {
            yOffset = ySwipeDirection;
            playerAnimation.Play("Walk");
            walkingCount = 0;
        }
    }

	public void ResetLevel()
	{
		//Reset level and show end screen
		GameObject UI = GameObject.Find("UI");
		UI.GetComponent<SwitchUI> ().toEnd ();
		//this.gameObject.transform.position = new Vector3 (1, 0, -1);
	}
}

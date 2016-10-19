using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {
    private bool isMobile = true;
    private PlayerHandler player;

    //variables for swiping
    private float startTime;
    private Vector2 startPos;
    private bool couldBeSwipe;
    private float comfortZone;
    public float minSwipeDist;
    public float maxSwipeTime;
    private bool paused;

	// Use this for initialization
	void Start () {
	    if( Application.isEditor)
        {
            isMobile = false;
        }

        player = GameObject.Find("player").GetComponent<PlayerHandler>();
        comfortZone = 100;
        paused = true;
	}

    public void SetPaused(bool p)
    {
        paused = p;
    }
	
	// Update is called once per frame
	void Update () {
        if(paused)
        {
            return;
        }

	    if(isMobile)
        {
            int touchesOnScreen = Input.touchCount;
            --touchesOnScreen;

            Touch touch = Input.GetTouch(touchesOnScreen);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    //check if they begin at player??
                    couldBeSwipe = true;
                    startPos = touch.position;
                    startTime = Time.time;
                    break;

                case TouchPhase.Moved:
                    if (Mathf.Abs(touch.position.y - startPos.y) > comfortZone)
                    {
                        couldBeSwipe = false;
                    }
                    break;

                case TouchPhase.Stationary:
                    couldBeSwipe = false;
                    break;

                case TouchPhase.Ended:
                    float swipeTime = Time.time - startTime;
                    float swipeDist = (touch.position - startPos).magnitude;

                    if (couldBeSwipe && (swipeTime < maxSwipeTime) && (swipeDist > minSwipeDist))
                    {
                        // It's a swiiiiiiiiiiiipe!
                        float xSwipeDirection;
                        float ySwipeDirection;

                        float xMagnitude = Mathf.Abs(touch.position.x - startPos.x);
                        float yMagnitude = Mathf.Abs(touch.position.y - startPos.y);

                        if(xMagnitude > yMagnitude)
                        {
                            //horizontal swipe
                            xSwipeDirection = Mathf.Sign(touch.position.x - startPos.x);
                            ySwipeDirection = 0;
                        }
                        else
                        {
                            //vertical swipe
                            xSwipeDirection = 0;
                            ySwipeDirection = Mathf.Sign(touch.position.y - startPos.y);
                        }

                        HandleInteraction(xSwipeDirection, ySwipeDirection);
                    }
                    break;
            }
        }
        else //is in editor
        {
            if(Input.GetMouseButtonDown(0))
            {
                //left mouse button is down
                if(!couldBeSwipe)
                {
                    couldBeSwipe = true;
                    startPos = Input.mousePosition;
                    startTime = Time.time;
                }
                else
                {
                    if (Mathf.Abs(Input.mousePosition.y - startPos.y) > comfortZone)
                    {
                        couldBeSwipe = false;
                    }
                }
            }
            else if(Input.GetMouseButtonUp(0) && couldBeSwipe)
            {
                float swipeTime = Time.time - startTime;
                float swipeDist = (new Vector2(Input.mousePosition.x, Input.mousePosition.y) - startPos).magnitude;

                if ((swipeTime < maxSwipeTime) && (swipeDist > minSwipeDist))
                {
                    // It's a swiiiiiiiiiiiipe!
                    float xSwipeDirection;
                    float ySwipeDirection;

                    float xMagnitude = Mathf.Abs(Input.mousePosition.x - startPos.x);
                    float yMagnitude = Mathf.Abs(Input.mousePosition.y - startPos.y);

                    if (xMagnitude > yMagnitude)
                    {
                        //horizontal swipe
                        xSwipeDirection = Mathf.Sign(Input.mousePosition.x - startPos.x);
                        ySwipeDirection = 0;
                    }
                    else
                    {
                        //vertical swipe
                        xSwipeDirection = 0;
                        ySwipeDirection = Mathf.Sign(Input.mousePosition.y - startPos.y);
                    }

                    HandleInteraction(xSwipeDirection, ySwipeDirection);
                }

                couldBeSwipe = false;
            }
        }
	}

    void HandleInteraction(float xSwipeDirection, float ySwipeDirection)
    {
        player.MovePlayer(xSwipeDirection, ySwipeDirection);
    }
}

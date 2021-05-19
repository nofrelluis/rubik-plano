using Leap;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;

public class RotateCubeHand : MonoBehaviour
{

    private Vector2 firstPressPos;
    private Vector2 secondPressPos;
    private Vector2 currentSwipe;
    private Vector3 previousMousePosition;
    private Vector3 mouseDelta;
    private float speed = 300f;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ActivateR() {
        HandModel handm = GetComponent<HandModel>();
        Hand hand = handm.GetLeapHand();
        firstPressPos = new Vector2(hand.Fingers[1].TipPosition.x, hand.Fingers[1].TipPosition.y);
    }

    public void SwipeR()
    {
        HandModel handm = GetComponent<HandModel>();
        Hand hand = handm.GetLeapHand();
        // get the 2D poition of the second mouse click
        secondPressPos = new Vector2(hand.Fingers[1].TipPosition.x, hand.Fingers[1].TipPosition.y);
        //create a vector from the first and second click positions
        currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
        //normalize the 2d vector
        currentSwipe.Normalize();
        print(currentSwipe);
            

        

        if (LeftSwipe(currentSwipe))
        {
            target.transform.Rotate(0, 90, 0, Space.World);
        }
        else if (UpLeftSwipe(currentSwipe))
        {
            target.transform.Rotate(90, 0, 0, Space.World);
        }
        else if (DownRightSwipe(currentSwipe))
        {
            target.transform.Rotate(-90, 0, 0, Space.World);
        }


    }

    public void ActivateL()
    {
        HandModel handm = GetComponent<HandModel>();
        Hand hand = handm.GetLeapHand();
        firstPressPos = new Vector2(hand.Fingers[1].TipPosition.x, hand.Fingers[1].TipPosition.y);
    }

    public void SwipeL()
    {
        HandModel handm = GetComponent<HandModel>();
        Hand hand = handm.GetLeapHand();
        // get the 2D poition of the second mouse click
        secondPressPos = new Vector2(hand.Fingers[1].TipPosition.x, hand.Fingers[1].TipPosition.y);
        //create a vector from the first and second click positions
        currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
        //normalize the 2d vector
        currentSwipe.Normalize();
        print(currentSwipe);
        if (RightSwipe(currentSwipe))
        {
            target.transform.Rotate(0, -90, 0, Space.World);
        }
        else if (UpRightSwipe(currentSwipe))
        {
            target.transform.Rotate(0, 0, -90, Space.World);
        }
        else if (DownLeftSwipe(currentSwipe))
        {
            target.transform.Rotate(0, 0, 90, Space.World);
        }


    }



    public void Activated() {
        HandModel handm = GetComponent<HandModel>();
        Hand hand = handm.GetLeapHand();

        print("Puedo");
    }

    public void Deactivated() {
        print("Ya no");
    }

    bool LeftSwipe(Vector2 swipe)
    {
        return currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f;
    }

    bool RightSwipe(Vector2 swipe)
    {
        return currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f;
    }

    bool UpLeftSwipe(Vector2 swipe)
    {
        return currentSwipe.y > 0 && currentSwipe.x < 0f;
    }

    bool UpRightSwipe(Vector2 swipe)
    {
        return currentSwipe.y > 0 && currentSwipe.x < 0f;
    }

    bool DownLeftSwipe(Vector2 swipe)
    {
        return currentSwipe.y < 0 && currentSwipe.x > 0f;
    }

    bool DownRightSwipe(Vector2 swipe)
    {
        return currentSwipe.y < 0 && currentSwipe.x > 0f;
    }



}

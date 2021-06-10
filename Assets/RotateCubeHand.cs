using Leap;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;
using System;
using System.Linq.Expressions;

public class RotateCubeHand : MonoBehaviour
{

    private Vector2 firstPressPos = Vector2.zero;
    private Vector2 secondPressPos;
    private Vector2 currentSwipe;
    private Vector3 previousMousePosition;
    private Vector3 mouseDelta;
    private float speed = 300f;
    public GameObject target;
    private Concurrencia concu;

    public TutorialScript tutorialScript;
    private bool block;
    private string blockString;

    // Start is called before the first frame update
    void Start()
    {
        block = false;
        concu = FindObjectsOfType<Concurrencia>()[0];
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ActivateR() {
        HandModel handm = GetComponent<HandModel>();
        Hand hand = handm.GetLeapHand();
        Vector3 aux = new Vector3(hand.Fingers[1].TipPosition.x, hand.Fingers[1].TipPosition.y, hand.Fingers[1].TipPosition.z);
        print(aux);
        if (InsideCube(aux))
        {
            firstPressPos = new Vector2(aux.x, aux.y);
        }
    }

    public void SwipeR()
    {
        try {
            if (concu.Potgirar())
            {
                if (firstPressPos != Vector2.zero)
                {
                    print("Swipe Hand R");
                    HandModel handm = GetComponent<HandModel>();
                    Hand hand = handm.GetLeapHand();
                    // get the 2D poition of the second mouse click
                    secondPressPos = new Vector2(hand.Fingers[1].TipPosition.x, hand.Fingers[1].TipPosition.y);
                    //create a vector from the first and second click positions
                    currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
                    //normalize the 2d vector
                    currentSwipe.Normalize();
                    print("SwipeR " + currentSwipe);


                    if (LeftSwipe(currentSwipe) && (!block || blockString.Equals("L")))
                    {
                        //print("SwipeR L");
                        print("SwipeL i block = " + block);
                        target.transform.Rotate(0, 90, 0, Space.World);
                        if (block)
                        {
                            print("Arriba if");
                            tutorialScript.MoveDone();
                        }
                    }
                    else if (UpLeftSwipe(currentSwipe) && (!block || blockString.Equals("UL")))
                    {
                        //print("SwipeR UL");
                        target.transform.Rotate(90, 0, 0, Space.World);
                        if (block)
                        {
                            tutorialScript.MoveDone();
                        }
                    }
                    else if (DownRightSwipe(currentSwipe) && (!block || blockString.Equals("DR")))
                    {
                        //print("SwipeR DR");
                        target.transform.Rotate(-90, 0, 0, Space.World);
                        if (block)
                        {
                            tutorialScript.MoveDone();
                        }
                    }
                    firstPressPos = Vector2.zero;
                }
            }
            else
            {
                print("Swipe Hand R blocked");
            }
        }
        catch (Exception e){
            print(e);
        }
    }

    public void ActivateL()
    {
        HandModel handm = GetComponent<HandModel>();
        Hand hand = handm.GetLeapHand();
        Vector3 aux= new Vector3(hand.Fingers[1].TipPosition.x, hand.Fingers[1].TipPosition.y, hand.Fingers[1].TipPosition.z);
        //print("aux " + aux);
        if (InsideCube(aux))
        {
            firstPressPos = new Vector2(aux.x, aux.y);
        }
    }

    public void SwipeL()
    {
        try
        {
            if (concu.Potgirar() )
            {
                print("Swipe Hand L");
                HandModel handm = GetComponent<HandModel>();
                Hand hand = handm.GetLeapHand();
                if (firstPressPos != Vector2.zero)
                {
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
                        if (block)
                        {
                            tutorialScript.MoveDone();
                        }
                    }
                    else if (UpRightSwipe(currentSwipe))
                    {
                        target.transform.Rotate(0, 0, -90, Space.World);
                        if (block)
                        {
                            tutorialScript.MoveDone();
                        }
                    }
                    else if (DownLeftSwipe(currentSwipe))
                    {
                        target.transform.Rotate(0, 0, 90, Space.World);
                        if (block)
                        {
                            tutorialScript.MoveDone();
                        }
                    }
                }
                firstPressPos = Vector2.zero;
            }
            else {
                print("Swipe Hand L blocked");

            }
        }
        catch (Exception e){
            print(e);
        }
    }

    //Comprova que la mà estigui aprop del cub
    public bool InsideCube(Vector3 coord)
    {
        //print("Insidecube" + (-2 < coord.x && coord.x < 2 && -2 < coord.y && coord.y < 2 && -2 < coord.z && coord.z < 2));
        return -2.5 < coord.x && coord.x < 2.5 && -2.5 < coord.y && coord.y < 2.5 && -2.5 < coord.z && coord.z < 2.5;
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

    public void blockMovement(String str) {
        blockString = str;
        block = true;
    }

    public void unblockMovement() {
        block = false;
    }

}

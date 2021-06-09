﻿using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class RotateBigCube : MonoBehaviour
{
    private Vector2 firstPressPos;
    private Vector2 secondPressPos;
    private Vector2 currentSwipe;
    private Vector3 previousMousePosition;
    private Vector3 mouseDelta;
    private float speed = 200f;
    public GameObject target;

    public TutorialScript tutorialScript;
    private bool block;
    private string blockString;

    // Start is called before the first frame update
    void Start()
    {
        block = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!block)
        {
            print("not blocked");
            Swipe();
            Drag();
        }
        else { 
            print("blocked");
            SwipeBlocked();
            Drag();
        }
    }

    void Drag()
    {
        if (Input.GetMouseButton(1))
        {
            // while the mouse is held down the cube can be moved around its central axis to provide visual feedback
            mouseDelta = Input.mousePosition - previousMousePosition;
            mouseDelta *= 0.1f; // reduction of rotation speed
            transform.rotation = Quaternion.Euler(mouseDelta.y, -mouseDelta.x, 0) * transform.rotation;
        }
        else
        {
            // automatically move to the target position
            if (transform.rotation != target.transform.rotation)
            {
                var step = speed * Time.deltaTime;
                transform.rotation = Quaternion.RotateTowards(transform.rotation, target.transform.rotation, step);
            }
        }
        previousMousePosition = Input.mousePosition;


    }

    void Swipe()
    {
        if (Input.GetMouseButtonDown(1))
        {
            // get the 2D position of the first mouse click
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            //print(firstPressPos);
        }
        if (Input.GetMouseButtonUp(1))
        {
            // get the 2D poition of the second mouse click
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            //create a vector from the first and second click positions
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
            //normalize the 2d vector
            currentSwipe.Normalize();

            if (LeftSwipe(currentSwipe))
            {
                print("L");
                target.transform.Rotate(0, 90, 0, Space.World);
                
            }
            else if (RightSwipe(currentSwipe) )
            {
                print("R");
                target.transform.Rotate(0, -90, 0, Space.World);
            }
            else if (UpLeftSwipe(currentSwipe) )
            {
                print("UL");
                target.transform.Rotate(90, 0, 0, Space.World);
            }
            else if (UpRightSwipe(currentSwipe) )
            {
                print("UR");
                target.transform.Rotate(0, 0, -90, Space.World);
            }
            else if (DownLeftSwipe(currentSwipe) )
            {
                print("DL");
                target.transform.Rotate(0, 0, 90, Space.World);
            }
            else if (DownRightSwipe(currentSwipe))
            {
                print("DR");
                target.transform.Rotate(-90, 0, 0, Space.World);
            }
        }
    }

    void SwipeBlocked()
    {
        if (Input.GetMouseButtonDown(1))
        {
            // get the 2D position of the first mouse click
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            //print(firstPressPos);
        }
        if (Input.GetMouseButtonUp(1))
        {
            // get the 2D poition of the second mouse click
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            //create a vector from the first and second click positions
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
            //normalize the 2d vector
            currentSwipe.Normalize();

            if (LeftSwipe(currentSwipe) && blockString.Equals("L"))
            {
                print("L");
                target.transform.Rotate(0, 90, 0, Space.World);
                tutorialScript.MoveDone();
            }
            else if (RightSwipe(currentSwipe) && blockString.Equals("R"))
            {
                print("R");
                target.transform.Rotate(0, -90, 0, Space.World);
                tutorialScript.MoveDone();
            }
            else if (UpLeftSwipe(currentSwipe) && blockString.Equals("UL"))
            {
                print("UL");
                target.transform.Rotate(90, 0, 0, Space.World);
                tutorialScript.MoveDone();
            }
            else if (UpRightSwipe(currentSwipe) && blockString.Equals("UR"))
            {
                print("UR");
                target.transform.Rotate(0, 0, -90, Space.World);
                tutorialScript.MoveDone();
            }
            else if (DownLeftSwipe(currentSwipe) && blockString.Equals("DL"))
            {
                print("DL");
                target.transform.Rotate(0, 0, 90, Space.World);
                tutorialScript.MoveDone();
            }
            else if (DownRightSwipe(currentSwipe) && blockString.Equals("DR"))
            {
                print("DR");
                target.transform.Rotate(-90, 0, 0, Space.World);
                tutorialScript.MoveDone();
            }
        }
    }

    bool LeftSwipe(Vector2 swipe)
    {
        return currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f;
    }

    bool RightSwipe(Vector2 swipe)
    {
        return currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f;
    }

    bool UpLeftSwipe(Vector2 swipe)
    {
        return currentSwipe.y > 0 && currentSwipe.x < 0f;
    }

    bool UpRightSwipe(Vector2 swipe)
    {
        return currentSwipe.y > 0 && currentSwipe.x > 0f;
    }

    bool DownLeftSwipe(Vector2 swipe)
    {
        return currentSwipe.y < 0 && currentSwipe.x < 0f;
    }

    bool DownRightSwipe(Vector2 swipe)
    {
        return currentSwipe.y < 0 && currentSwipe.x > 0f;
    }

    public void blockMovement(string str) {
        blockString = str;
        block = true;
    }

    public void unblockMovement() {
        block = false;
    }
}

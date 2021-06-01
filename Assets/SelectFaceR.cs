using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;
using System;

public class SelectFaceR : MonoBehaviour
{
    public GameObject Cube;
    private Vector3 First = Vector3.zero; //Primera coordenada
    private Vector3 Second; //Segona coordenada
    private CubeState cubeState;
    private ReadCube readCube;
    private GameObject target;
    private Concurrencia concu;
   

    private Quaternion targetQuaternion;



    // Start is called before the first frame update
    void Start()
    {
        readCube = FindObjectOfType<ReadCube>();
        cubeState = FindObjectOfType<CubeState>();
        target = FindObjectOfType<RotateCubeHand>().target;
        concu = FindObjectsOfType<Concurrencia>()[0];
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    public void GetFirst()
    {

        HandModel handm = GetComponent<HandModel>();
        Hand hand = handm.GetLeapHand();
        Vector3 coord = hand.Fingers[1].TipPosition.ToVector3();
        if (InsideCube(coord) )
        {
            //print("Dins");
            print("Fisrt: "+coord.y);
            First = coord;
        }
        else {
            //print("Fora");
        }

    }

    public void GetSecondL()
    {
        try {
        if (concu.Potgirar())
        {
            //GameObject face = hit.collider.gameObject;
            // Make a list of all the sides (lists of face GameObjects)

            HandModel handm = GetComponent<HandModel>();
            Hand hand = handm.GetLeapHand();
            Vector3 coord = hand.Fingers[1].TipPosition.ToVector3();
            Vector2 Swipe;
            if (First != Vector3.zero)
            {
                //print("segon");

                Second = coord;
                Swipe = new Vector2(Second.x - First.x, Second.y - First.y);
                if (RightSwipe(Swipe))
                {
                    readCube.ReadState();
                    if (First.y > 0.5 && First.x <1)
                    {
                        print("U'");
                        cubeState.up[4].transform.parent.GetComponent<PivotRotation>().StartAutoRotate(cubeState.up, 90);
                    }
                    else if (-0.5 <= First.y && First.y <= 0.5 && First.x < 1)
                    {
                        print("E");
                        cubeState.up[4].transform.parent.GetComponent<PivotRotation>().StartAutoRotate(cubeState.up, -90);
                        target.transform.Rotate(0, -90, 0, Space.World);
                        cubeState.down[4].transform.parent.GetComponent<PivotRotation>().StartAutoRotate(cubeState.down, 90);
                    }
                    else if (First.y < -0.5 && First.x < 1)
                    {
                        print("D");
                        cubeState.down[4].transform.parent.GetComponent<PivotRotation>().StartAutoRotate(cubeState.down, -90);
                    }
                }
                else if (UpRightSwipe(Swipe))
                {
                    readCube.ReadState();
                    if (First.z > 0.5 && First.x < 1)
                    {
                        print("L");
                        cubeState.left[4].transform.parent.GetComponent<PivotRotation>().StartAutoRotate(cubeState.left, 90);
                    }
                    else if (-0.5 <= First.z && First.z <= 0.5 && First.x < 1)
                    {
                        print("M'");
                        cubeState.left[4].transform.parent.GetComponent<PivotRotation>().StartAutoRotate(cubeState.left, -90);
                        target.transform.Rotate(0, 0, -90, Space.World);
                        cubeState.right[4].transform.parent.GetComponent<PivotRotation>().StartAutoRotate(cubeState.right, 90);
                    }
                    else if (First.z < -0.5 && First.x < 1)
                    {
                        print("R'");
                        cubeState.right[4].transform.parent.GetComponent<PivotRotation>().StartAutoRotate(cubeState.right, -90);
                    }
                }
                else if (DownLeftSwipe(Swipe))
                {
                    readCube.ReadState();
                    if (First.z > 0.5 && First.x < 1)
                    {
                        print("L'");
                        cubeState.left[4].transform.parent.GetComponent<PivotRotation>().StartAutoRotate(cubeState.left, -90);
                    }
                    else if (-0.5 <= First.z && First.z <= 0.5 && First.x < 1)
                    {
                        print("M");
                        cubeState.left[4].transform.parent.GetComponent<PivotRotation>().StartAutoRotate(cubeState.left, 90);
                        target.transform.Rotate(0, 0, 90, Space.World);
                        cubeState.right[4].transform.parent.GetComponent<PivotRotation>().StartAutoRotate(cubeState.right, -90);
                    }
                    else if (First.z < -0.5 && First.x < 1)
                    {
                        print("R");
                        cubeState.right[4].transform.parent.GetComponent<PivotRotation>().StartAutoRotate(cubeState.right, 90);
                    }
                }
                First = Vector3.zero;
            }
            
        }
    }
        catch (Exception e) { print(e);
}
    }

    public void GetSecondR()
    {
        try
        {

            if (concu.Potgirar())
            {

                //GameObject face = hit.collider.gameObject;
                // Make a list of all the sides (lists of face GameObjects)

                HandModel handm = GetComponent<HandModel>();
                Hand hand = handm.GetLeapHand();
                Vector3 coord = hand.Fingers[1].TipPosition.ToVector3();
                Vector2 Swipe;
                if (First != Vector3.zero)
                {
                    //print("segon");

                    Second = coord;
                    Swipe = new Vector3(Second.x - First.x, Second.y - First.y, Second.z - First.z);
                    if (LeftSwipe(Swipe))
                    {
                        readCube.ReadState();
                        //print("ReadCube: " + readCube);
                        if (First.y > 0.5)
                        {
                            print("U");
                            //print(cubeState.GetStateString());
                            //GameObject prova = cubeState.up[4];
                            //print("U post prova");
                            //PivotRotation pivotprova = prova.transform.parent.GetComponent<PivotRotation>();
                            //print("U post pivot");
                            //pivotprova.StartAutoRotate(cubeState.up, -90);
                            //print("U post autoRotate");
                            cubeState.up[4].transform.parent.GetComponent<PivotRotation>().StartAutoRotate(cubeState.up, -90);
                        }
                        else if (-0.5 <= First.y && First.y <= 0.5)
                        {
                            print("E'");
                            cubeState.up[4].transform.parent.GetComponent<PivotRotation>().StartAutoRotate(cubeState.up, 90);
                            target.transform.Rotate(0, 90, 0, Space.World);
                            cubeState.down[4].transform.parent.GetComponent<PivotRotation>().StartAutoRotate(cubeState.down, -90);
                        }
                        else if (First.y < -0.5)
                        {
                            print("D'");
                            cubeState.down[4].transform.parent.GetComponent<PivotRotation>().StartAutoRotate(cubeState.down, 90);
                        }
                    }
                    else if (UpLeftSwipe(Swipe))
                    {
                        readCube.ReadState();
                        if (First.x > 0.5)
                        {
                            print("B");
                            cubeState.back[4].transform.parent.GetComponent<PivotRotation>().StartAutoRotate(cubeState.back, -90);
                        }
                        else if (-0.5 <= First.x && First.x <= 0.5)
                        {
                            print("S'");
                            cubeState.back[4].transform.parent.GetComponent<PivotRotation>().StartAutoRotate(cubeState.back, 90);
                            target.transform.Rotate(90, 0, 0, Space.World);
                            cubeState.front[4].transform.parent.GetComponent<PivotRotation>().StartAutoRotate(cubeState.front, -90);
                        }
                        else if (First.x < -0.5)
                        {
                            print("F'");
                            cubeState.front[4].transform.parent.GetComponent<PivotRotation>().StartAutoRotate(cubeState.front, 90);
                        }
                    }
                    else if (DownRightSwipe(Swipe))
                    {
                        readCube.ReadState();
                        if (First.x > 0.5)
                        {
                            print("B'");
                            cubeState.back[4].transform.parent.GetComponent<PivotRotation>().StartAutoRotate(cubeState.back, 90);
                        }
                        else if (-0.5 <= First.x && First.x <= 0.5)
                        {
                            print("S");
                            cubeState.back[4].transform.parent.GetComponent<PivotRotation>().StartAutoRotate(cubeState.back, -90);
                            target.transform.Rotate(-90, 0, 0, Space.World);
                            cubeState.front[4].transform.parent.GetComponent<PivotRotation>().StartAutoRotate(cubeState.front, 90);
                        }
                        else if (First.x < -0.5)
                        {
                            print("F");
                            cubeState.front[4].transform.parent.GetComponent<PivotRotation>().StartAutoRotate(cubeState.front, -90);
                        }
                    }
                    First = Vector3.zero;
                }

            }
        }
        catch (Exception e) { print(e); }
    }

    public bool InsideCube(Vector3 coord) {
        return -2 < coord.x && coord.x < 2 && -2 < coord.y && coord.y < 2 && -2 < coord.z && coord.z < 2;
    }

    bool LeftSwipe(Vector3 swipe)
    {
        return swipe.x < 0 && swipe.y > -0.5f && swipe.y < 0.5f;
    }

    bool RightSwipe(Vector3 swipe)//-1, 0.1
    {
        return swipe.x < 0 && swipe.y > -0.5f && swipe.y < 0.5f;
    }

    bool UpLeftSwipe(Vector3 swipe)
    {

        return swipe.y > 0 && swipe.x < 0f;
    }

    bool UpRightSwipe(Vector3 swipe)
    {
        //Possible x<0
        return swipe.y > 0 && swipe.x < 0f;
    }

    bool DownLeftSwipe(Vector3 swipe)
    {

        return swipe.y < 0 && swipe.x < 0f;
    }

    bool DownRightSwipe(Vector3 swipe)//-0.3,0.9
    {

        return swipe.y < 0 && swipe.x > 0f;
    }

    public void RotateSide(List<GameObject> side, float angle)
    {
        // automatically rotate the side by the angle
        PivotRotation pr = side[4].transform.parent.GetComponent<PivotRotation>();
        //print("Side: "+side);
        pr.StartAutoRotate(side, angle);
        //print("RotateE");
    }

    public void StartAutoRotate(List<GameObject> side, float angle)
    {
        //print("autorotateS");
        cubeState.PickUp(side);
        Vector3 localForward = Vector3.zero - side[4].transform.parent.transform.localPosition;
        targetQuaternion = Quaternion.AngleAxis(angle, localForward) * transform.localRotation;
        //print("autorotateE");
    }
}

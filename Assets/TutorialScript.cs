using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
{
    public Text txt;
    public RotateBigCube rotateBigcube;
    public RotateCubeHand rotateCubeHandLeft;
    public RotateCubeHand rotateCubeHandRight;

    private int state;
    private bool start;

    void Start() {
        start = false;
        state = 0;
    }

    void Update() {
        if (start) {
            switch (state) {
                case 0:
                    txt.text = "GÜELCOME TO THE TUTORIAL: move hand from left to right";
                    rotateBigcube.blockMovement("L");
                    rotateCubeHandLeft.blockMovement("");
                    rotateCubeHandRight.blockMovement("L");
                    break;
                case 1:
                    txt.text = "Now do the same but from right to lefto";
                    rotateBigcube.blockMovement("R"); 
                    rotateCubeHandLeft.blockMovement("R");
                    rotateCubeHandRight.blockMovement("");
                    break;
                case 2:
                    txt.text = "Move your fingüer";
                    rotateBigcube.blockMovement("R");
                    break;
            }
        }
    }

    public void StartTutorial() {

        state = 0;
        start = true;
        rotateBigcube.blockMovement("");
        rotateCubeHandLeft.blockMovement("");
        rotateCubeHandRight.blockMovement("");
       
    }

    public void MoveDone() {
        print("well done");
        state += 1;
    }
}


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
    public SelectFaceFingers selectFaceRight;
    public SelectFaceFingers selectFaceLeft;
    public GameObject panel;

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
                    rotateCubeHandLeft.blockMovement("");
                    rotateCubeHandRight.blockMovement("L");
                    selectFaceLeft.blockMovement("");
                    selectFaceRight.blockMovement("");
                    break;
                case 1:
                    txt.text = "Now do the same but from right to lefto"; 
                    rotateCubeHandLeft.blockMovement("R");
                    rotateCubeHandRight.blockMovement("");
                    selectFaceLeft.blockMovement("");
                    selectFaceRight.blockMovement("");
                    break;
                case 2:
                    txt.text = "Try to move the upper laier with yo fingüer";
                    rotateCubeHandLeft.blockMovement("");
                    rotateCubeHandRight.blockMovement("");
                    selectFaceLeft.blockMovement("");
                    selectFaceRight.blockMovement("U");
                    break;
                case 3:
                    txt.text = "Now the upper layer to the right";
                    rotateCubeHandLeft.blockMovement("");
                    rotateCubeHandRight.blockMovement("");
                    selectFaceLeft.blockMovement("U'");
                    selectFaceRight.blockMovement("");
                    break;
                case 4:
                    EndTutorial();
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

    public void EndTutorial() {
        state = 0;
        start = false;
        rotateCubeHandLeft.unblockMovement();
        rotateCubeHandRight.unblockMovement();
        selectFaceLeft.unblockMovement();
        selectFaceRight.unblockMovement();
        panel.SetActive(false);
    }

    public void MoveDone() {
        print("well done");
        state += 1;
    }
}


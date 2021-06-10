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
                    txt.text = "El dispositiu LEAP MOTION necessita que s'exagerin els moviments per a detectar el que es vol fer \n" +
                     "Prova a girar el cub moguent la mà oberta de dreta a esquerra i tanca la mà en acabar el moviment";
                    rotateCubeHandLeft.blockMovement("");
                    rotateCubeHandRight.blockMovement("L");
                    selectFaceLeft.blockMovement("");
                    selectFaceRight.blockMovement("");
                    break;
                case 1:
                    txt.text = "Amb la mà dreta pots fer els moviments de la dreta del cub i amb la mà esquerra els de l'altre part del cub,\n" +
                        "Prova de fer el moviment anterior moguent la mà esquerra d'esquerra a dreta"; 
                    rotateCubeHandLeft.blockMovement("R");
                    rotateCubeHandRight.blockMovement("");
                    selectFaceLeft.blockMovement("");
                    selectFaceRight.blockMovement("");
                    break;
                case 2:
                    txt.text = "Els moviments verticals han de ser més precisos\n" +
                        "Amb la mà dreta fer el gest d'abaix cap adalt tancant la mà al final del moviment";
                    rotateCubeHandLeft.blockMovement("");
                    rotateCubeHandRight.blockMovement("UL");
                    selectFaceLeft.blockMovement("");
                    selectFaceRight.blockMovement("");
                    break;
                case 3:
                    txt.text = "Per a moure les cares del cub s'ha de fer el moviment d'obrir i tancar pero només amb el dit index\n" +
                        "Prova de moure la cara d'adalt amb la mà dreta moguent de dreta a esquerra";
                    rotateCubeHandLeft.blockMovement("");
                    rotateCubeHandRight.blockMovement("");
                    selectFaceLeft.blockMovement("");
                    selectFaceRight.blockMovement("U");
                    break;
                case 4:
                    txt.text = "Per a facilitar el control del cub intenta que el movident del dit quedi dins la cara que vols moure\n" +
                        "Prova de moure la cara superior de esquerra a dreta, exagera l'obrir i tancar el dit";
                    rotateCubeHandLeft.blockMovement("");
                    rotateCubeHandRight.blockMovement("");
                    selectFaceLeft.blockMovement("U'");
                    selectFaceRight.blockMovement("");
                    break;
                case 5:
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


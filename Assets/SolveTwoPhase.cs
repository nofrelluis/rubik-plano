using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kociemba;

public class SolveTwoPhase : MonoBehaviour
{
    public ReadCube readCube;
    public CubeState cubeState;
    private bool doOnce = true;

    public GameObject target;
    public RotateBigCube rotateBigCube;

    // Start is called before the first frame update
    void Start()
    {
        readCube = FindObjectOfType<ReadCube>();
        cubeState = FindObjectOfType<CubeState>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!rotateBigCube.rotating) 
        {
            if (CubeState.started && doOnce)
            {
                doOnce = false;
                Solver();
            }
        }
    }

    public void Solver()
    {

        readCube.ReadState();

        // get the state of the cube as a string
        string moveString = cubeState.GetStateString();
        print(moveString);

        // solve the cube
        string info = "";
        string solution = "";

        char[] aux = moveString.ToCharArray();
        switch (aux[4])
        {
            case 'R':
                print("R");
                doOnce = true;
                switch (aux[13])
                {                  
                    case 'F':
                        print("- F");
                        target.transform.Rotate(0, 0, -90, Space.World);
                        break;
                    case 'D':
                        print("- D");
                        target.transform.Rotate(-90, 0, 0, Space.World);
                        break;
                    case 'L':
                        print("- L");
                        print("impossible");
                        break;
                    case 'B':
                        print("- B");
                        target.transform.Rotate(0, 0, 90, Space.World); doOnce = true;
                        break;
                    case 'U':
                        target.transform.Rotate(90, 0, 0, Space.World);

                        break;
                }
                break;
            case 'F':
                print("F");
                doOnce = true;
                switch (aux[13])
                {
                    case 'R':
                        print("- R");
                        target.transform.Rotate(0, 0, 90, Space.World);
                        break;
                    case 'D':
                        print("- D");
                        target.transform.Rotate(-90, 0, 0, Space.World);
                        break;
                    case 'L':
                        print("- L");
                        target.transform.Rotate(0, 0, -90, Space.World);
                        break;
                    case 'B':
                        print("- B");
                        print("impossible");
                        break;
                    case 'U':
                        target.transform.Rotate(90, 0, 0, Space.World);

                        break;
                }
                doOnce = true;
                break;
            case 'D':
                print("D");
                doOnce = true;
                target.transform.Rotate(0, 0, 90, Space.World);
                break;
            case 'L':
                print("L");
                doOnce = true;
                switch (aux[13])
                {
                    case 'R':
                        print("- R");
                        print("impossible");
                        break;
                    case 'D':
                        print("- D");
                        target.transform.Rotate(-90, 0, 0, Space.World);
                        break;
                    case 'F':
                        print("- F");
                        target.transform.Rotate(0, 0, 90, Space.World);
                        break;
                    case 'B':
                        print("- B");
                        target.transform.Rotate(-90, 0, 0, Space.World);
                        break;
                    case 'U':
                        target.transform.Rotate(90, 0, 0, Space.World);

                        break;
                }
                
                break;
            case 'B':
                print("B");
                doOnce = true;
                switch (aux[13])
                {
                    case 'R':
                        print("- R");
                        target.transform.Rotate(0, 0, -90, Space.World);
                        break;
                    case 'D':
                        print("- D");
                        target.transform.Rotate(-90, 0, 0, Space.World);
                        break;
                    case 'L':
                        print("- L");
                        target.transform.Rotate(0, 0, 90, Space.World);
                        break;
                    case 'F':
                        print("- F");
                        print("impossible");
                        break;
                    case 'U':
                        target.transform.Rotate(90, 0, 0, Space.World);
                        break;
                }
                break;
            case 'U':
                print("U ");
                switch (aux[13])
                {
                    case 'R':
                        print("- R - GOOD");

                        // First time build the tables
                        solution = SearchRunTime.solution(moveString, out info, buildTables: true);
                        
                        //Every other time
                        //string solution = Search.solution(moveString, out info);

                        // convert the solved moves from a string to a list
                        List<string> solutionList = StringToList(solution);

                        //Automate the list
                        Automate.moveList = solutionList;
                        doOnce = false;

                        break;
                    case 'F':
                        print("- F");
                        target.transform.Rotate(0, 90, 0, Space.World);
                        doOnce = true;
                        break;
                    case 'D':
                        print("impossible");
                        break;
                    case 'L':
                        print("- L");
                        target.transform.Rotate(0, 90, 0, Space.World);
                        doOnce = true;
                        break;
                    case 'B':
                        print("- B");
                        target.transform.Rotate(0, -90, 0, Space.World);
                        doOnce = true;
                        break;
                }
                break;
        }

        print("info: "+info);
        print("solution:" + solution);
        
    }

    List<string> StringToList(string solution)
    {
        List<string> solutionList = new List<string>(solution.Split(new string[] { " " }, System.StringSplitOptions.RemoveEmptyEntries));
        return solutionList;
    }

}

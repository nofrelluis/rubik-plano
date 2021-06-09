using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Concurrencia : MonoBehaviour
{
    private int contador;
    private int Max_cont;
    // Start is called before the first frame update
    void Start()
    {
        print("cuncu starto");
        contador = 0;
        Max_cont = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (contador > 0) {
            contador--;
            //print("concu contador = " + contador);
        }
    }

    public bool Potgirar() {
        print("vull girar");
        if (contador == 0)
        {
            gira();
            return true;
        }
        else {
            return false;
        };
        
    }

    private void gira() {
        contador = Max_cont;
    }
}

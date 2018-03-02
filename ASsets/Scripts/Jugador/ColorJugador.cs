using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorJugador : MonoBehaviour {

    SpriteRenderer jugador;

    private void Awake(){
        jugador = GetComponent<SpriteRenderer>();
    }

     public void AsignadorColor(AsignadorJugador asignador)
    {
        if(asignador.jugador1 == true){
            jugador.color = Color.red;
        }
        if (asignador.jugador2 == true){
            jugador.color = Color.blue;
        }
        if (asignador.jugador3 == true){
            jugador.color = Color.green;
        }
        if (asignador.jugador4 == true){
            jugador.color = Color.yellow;
        }
    }
}

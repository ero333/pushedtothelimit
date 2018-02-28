using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorJugador : MonoBehaviour {

   // public Color[] color;
    SpriteRenderer jugador;
    AsignadorJugador asignador;

    private void Awake(){
        asignador = GetComponent<AsignadorJugador>();
        jugador = GetComponent<SpriteRenderer>();
    }

    private void OnEnable(){
        AsignadorColor();
    }

    void AsignadorColor(){
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

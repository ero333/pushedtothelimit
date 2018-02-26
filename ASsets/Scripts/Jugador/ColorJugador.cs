using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorJugador : MonoBehaviour {

    public Color[] color;
    SpriteRenderer jugador;
    AsignadorJugador asignador;

    private void Awake(){
        asignador = GetComponent<AsignadorJugador>();
        jugador = GetComponent<SpriteRenderer>();
    }

    private void Start(){
       AsignadorColor();
    }

    void AsignadorColor(){
        if(asignador.jugador1 == true){
            jugador.color = color[0];
        }
        if (asignador.jugador2 == true){
            jugador.color = color[1];
        }
        if (asignador.jugador3 == true){
            jugador.color = color[2];
        }
        if (asignador.jugador4 == true){
            jugador.color = color[3];
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour {
    AsignadorJugador asiganador;
    
    private void Awake(){
        asiganador = GetComponent<AsignadorJugador>();
        DontDestroyOnLoad(gameObject);
        gameObject.SetActive(false);
    }

    private void ControlJoystink(){
        if(asiganador.jugador1 == true){

        }
        if (asiganador.jugador2 == true){

        }
        if (asiganador.jugador3 == true){

        }
        if (asiganador.jugador4 == true){

        }
    }
    

}

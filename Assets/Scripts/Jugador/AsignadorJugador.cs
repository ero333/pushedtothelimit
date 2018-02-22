using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsignadorJugador : MonoBehaviour {
    public bool jugador1;
    public bool jugador2;
    public bool jugador3;
    public bool jugador4;

    private void Awake(){
        Asignador();
    }

    void Asignador(){
        if(GameManager.instance.jugador1 == null){
            GameManager.instance.jugador1 = gameObject;
            jugador1 = true;
        }else if(GameManager.instance.jugador2 == null){
            GameManager.instance.jugador2 = gameObject;
            jugador2 = true;
        }
        else if(GameManager.instance.jugador3 == null){
            GameManager.instance.jugador3 = gameObject;
            jugador3 = true;
        }
        else if(GameManager.instance.jugador4 == null){
            GameManager.instance.jugador4 = gameObject;
            jugador4 = true;
            GameManager.instance.lleno = true;
        }
        else{
            Destroy(gameObject);
        }
    }

}

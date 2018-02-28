using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsignadorJugador : MonoBehaviour {
    public bool jugador1;
    public bool jugador2;
    public bool jugador3;
    public bool jugador4;
    ColorJugador colorJ;

    private void Awake(){
        Asignador();
    }

    void Asignador(){
        if(GameManager.instance.jugador1 == null){
            GameManager.instance.jugador1 = gameObject;
            jugador1 = true;
            GameManager.instance.jugadoresVivos += 1;
              // gameObject.SetActive(false);
        }
        else if(GameManager.instance.jugador2 == null){
            GameManager.instance.jugador2 = gameObject;
            jugador2 = true;
            GameManager.instance.jugadoresVivos += 1;
           //    gameObject.SetActive(false);
        }
        else if(GameManager.instance.jugador3 == null){
            GameManager.instance.jugador3 = gameObject;
            jugador3 = true;
            GameManager.instance.jugadoresVivos += 1;
            // gameObject.SetActive(false);
        }
        else{
            GameManager.instance.jugador4 = gameObject;
            jugador4 = true;
            GameManager.instance.jugadoresVivos += 1;
          //   gameObject.SetActive(false);
        }
    }

    private void OnDestroy(){
        if(jugador1 == true){
            GameManager.instance.jugador1 = null;
        }
        if (jugador2 == true){
            GameManager.instance.jugador2 = null;
        }
        if (jugador3 == true){
            GameManager.instance.jugador3 = null;
        }
        if (jugador4 == true){
            GameManager.instance.jugador4 = null;
        }
        GameManager.instance.jugadoresVivos--;
        GameManager.instance.ControlRonda();
    }
}

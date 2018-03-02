using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsignadorJugador : MonoBehaviour {
    public bool jugador1;
    public bool jugador2;
    public bool jugador3;
    public bool jugador4;
    ColorJugador colorJ;

    public int Asignador()
    {
        int ret = 0;
        if(GameManager.instance.jugador1 == null){
            GameManager.instance.jugador1 = gameObject;
            jugador1 = true;

            ret = 1;
              // gameObject.SetActive(false);
        }
        else if(GameManager.instance.jugador2 == null){
            GameManager.instance.jugador2 = gameObject;
            jugador2 = true;

            ret = 2;
           //    gameObject.SetActive(false);
        }
        else if(GameManager.instance.jugador3 == null){
            GameManager.instance.jugador3 = gameObject;
            jugador3 = true;

            ret = 3;
            // gameObject.SetActive(false);
        }
        else{
            GameManager.instance.jugador4 = gameObject;
            jugador4 = true;

            ret = 4;
          //   gameObject.SetActive(false);
        }

        GameManager.instance.jugadoresVivos++;
        return ret;
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

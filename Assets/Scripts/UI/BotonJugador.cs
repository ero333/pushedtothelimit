using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonJugador : MonoBehaviour {
    public int jugadoresAIstanciar;
    public string escenaAJugar;

    public void InstanciadorJugadores(){
        GameManager.instance.jugadoreEnPartida = jugadoresAIstanciar;
        SceneManager.LoadScene(escenaAJugar);
    }
}

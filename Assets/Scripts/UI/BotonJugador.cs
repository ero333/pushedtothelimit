using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonJugador : MonoBehaviour {
    public int jugadoresAIstanciar;
    public GameObject jugador;
    public string escenaAJugar;

    public void InstanciadorJugadores(){
        for (int i = 0; i < jugadoresAIstanciar; i++)
        {
            Instantiate(jugador);
        }
        SceneManager.LoadScene(escenaAJugar);
    }
}

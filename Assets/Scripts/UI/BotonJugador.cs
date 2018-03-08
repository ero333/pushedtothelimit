using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class BotonJugador : MonoBehaviour {
    public int jugadoresAIstanciar;
    public string escenaAJugar;

    public void InstanciadorJugadores(){

		Analytics.CustomEvent("PartidaInicio", new Dictionary<string, object>
		{
				{ "jugadores", jugadoresAIstanciar }
		});
		
        GameManager.instance.jugadoreEnPartida = jugadoresAIstanciar;
        SceneManager.LoadScene(escenaAJugar);
    }
}

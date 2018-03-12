using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class GameManager : MonoBehaviour {
	public static GameManager instance;
    public string pantallaMenu;
    public string pantallaVictoria;
    public GameObject jugador1;
    public GameObject jugador2;
    public GameObject jugador3;
    public GameObject jugador4;
    public bool rondaEnCurso;
    public string ganador;
    public int jugadoresVivos;
    public int jugadoreEnPartida;
    int partidasJugadas;
    float inicioPartida;
    float tiempoPartida;

    void Awake(){
		if(instance == null){
			instance = this;
		}else{
			Destroy(gameObject);
		}
        DontDestroyOnLoad(gameObject);
	}

    public void CargarPantallaMenu(){
        SceneManager.LoadScene(pantallaMenu);
    }

    public void CaragarPanatallaVitoria(){
        SceneManager.LoadScene(pantallaVictoria);
    }


 
    public void ControlRonda(){
        if (rondaEnCurso == true){
            if (jugadoresVivos <= 1){
                if (jugador1 != null){
                    ganador = "Jugador 1";
                }
                else if (jugador2 != null){
                    ganador = "Jugador 2";
                }
                else if (jugador3 != null){
                    ganador = "Jugador 3";
                }
                else if (jugador4 != null){
                    ganador = "Jugador 4";
                }
                rondaEnCurso = false;
				SpawnNaveNASO nave;
				nave = FindObjectOfType<SpawnNaveNASO>();
				nave.NaveAlRescate();
                partidasJugadas += 1;
                tiempoPartida = Time.time;

                Analytics.CustomEvent("PartidaInicio", new Dictionary<string, object>{{ "PartidasJugadas", partidasJugadas }});

                Analytics.CustomEvent("PartidaFin", new Dictionary<string, object>{{ "Ganador", ganador },});

                Analytics.CustomEvent("PartidaFin", new Dictionary<string, object> {{ "TiempoPartida", tiempoPartida }});
            }
        }
        
    }

}

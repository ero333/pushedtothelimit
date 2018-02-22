using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public static GameManager instance;
    public string pantallaMenu;
    public string pantallaVictoria;
    public GameObject jugador1;
    public GameObject jugador2;
    public GameObject jugador3;
    public GameObject jugador4;
    public bool lleno;
    public GameObject[] jugadores;
    public bool rondaEnCurso;
    public string ganador;

    void Awake(){
		if(instance == null){
			instance = this;
		}else{
			Destroy(gameObject);
		}
        jugadores = new GameObject[4];
        DontDestroyOnLoad(gameObject);
	}

    void Update(){
        if (rondaEnCurso == true){
            ControlRonda();
            for (int i = 0; i < jugadores.Length; i++){
                jugadores[i].SetActive(true);
            }
        }
        if(rondaEnCurso == false){
            EnsambladorRonda();
        }
	}

    public void CargarPantallaMenu(){
        SceneManager.LoadScene(pantallaMenu);
    }

    public void CaragarPanatallaVitoria(){
        SceneManager.LoadScene(pantallaVictoria);
    }

    public void EnsambladorRonda(){
        if (jugador1 != null){
            jugadores[0] = jugador1;
        }
        if (jugador2 != null){
            jugadores[1] = jugador2;
        }
        if (jugador3 != null){
            jugadores[2] = jugador3;
        }
        if (jugador4 != null){
            jugadores[3] = jugador4;
        }
    }

    public void ControlRonda(){
        int vivos = 0;
        for (int i = 0; i < jugadores.Length; i++){
            if (jugadores[i].activeInHierarchy == true){
                vivos += 1;
            }
        }
        if(vivos == 1){
            for (int i = 0; i < jugadores.Length; i++){
                if(jugadores[i].activeSelf == true){
                    ganador = jugadores[i].name;
                }
            }
        }
        if(vivos == 0){
            CargarPantallaMenu();
        }
    }

}

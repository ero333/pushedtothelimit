using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ganador : MonoBehaviour {
    Text texto;

    private void Awake(){
        texto = GetComponent<Text>();
    }

    private void Start(){
        NombreGanador();
    }

    void NombreGanador(){
        texto.text = GameManager.instance.ganador;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;

public class Ganador : MonoBehaviour {
    Text texto;

    private void Awake(){
        texto = GetComponent<Text>();
    }

    private void Start(){

		Analytics.CustomEvent("PartidaFin", new Dictionary<string, object>
		{
				{ "ganador", GameManager.instance.ganador }
		});
		
		NombreGanador();
    }

    void NombreGanador(){
        texto.text = "El ganador es " + GameManager.instance.ganador;
    }
}

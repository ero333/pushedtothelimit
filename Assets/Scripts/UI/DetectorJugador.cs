using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectorJugador : MonoBehaviour {
	Text titulo;
	public bool slot1;
	public bool slot2;
	public bool slot3;
	public bool slot4;

	void Awake(){
		titulo = GetComponent<Text>();
	}

	void Update(){
		JugadorCreado();
	}

	void JugadorCreado(){
		if(slot1 == true){
			if(GameManager.instance.jugador1 == true){
				titulo.text = "Ready!";
			}
		}
		if(slot2 == true){
			if(GameManager.instance.jugador2 == true){
				titulo.text = "Ready!";
			}
		}
		if(slot3 == true){
			if(GameManager.instance.jugador3 == true){
				titulo.text = "Ready!";
			}
		}
		if(slot4 == true){
			if(GameManager.instance.jugador4 == true){
				titulo.text = "Ready!";
			}
		}
	}
}

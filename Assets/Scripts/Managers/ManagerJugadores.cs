using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerJugadores : MonoBehaviour {
	public GameObject prefabJugador;
	int jugadoresActivos = 0;

	void Update(){
			ActivadorJugador();
	}
	private void ActivadorJugador(){
		if(jugadoresActivos < 4){
			if(Input.GetKeyDown(KeyCode.Space)){
				Instantiate(prefabJugador);
				jugadoresActivos += 1;
			}
		}
	}
}

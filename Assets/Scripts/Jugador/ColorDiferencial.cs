using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorDiferencial : MonoBehaviour {

	//Este scrip le da un color al jugador ni bien empieza el nivel dependiendo de su nombre

	public Color[] variables;
	SpriteRenderer colorDelPlayer;

	// Use this for initialization
	void Start () {

		colorDelPlayer = gameObject.GetComponent <SpriteRenderer>();

		switch (gameObject.name){
		case "Jugador1":
			colorDelPlayer.color = variables [0];
			break;
		case "Jugador2":
			colorDelPlayer.color = variables [1];
			break;
		case "Jugador3":
			colorDelPlayer.color = variables [2];
			break;
		case "Jugador4":
			colorDelPlayer.color = variables [3];
			break;

		}
	}
}

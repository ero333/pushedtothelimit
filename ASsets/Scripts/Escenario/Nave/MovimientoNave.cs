using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoNave : MonoBehaviour {

	public float velocidad;
	public Transform salida;

	PlayerController jugador;



	void Start () {
		jugador = FindObjectOfType<PlayerController> ();
	}

	void Update () {
		
		if (jugador != null) {

			float distanciaAlJugador = Vector2.Distance (transform.position, jugador.transform.position);

			if (distanciaAlJugador > 1f) {
				transform.position = Vector2.MoveTowards (transform.position, jugador.transform.position, velocidad * Time.deltaTime);
				//			transform.LookAt (jugador.transform.position); esta línea rota el sprite de la nave dejándola fuera del plano de juego
			} else {
				print ("absorbo al player");

			}
				
		} else if (jugador == null) {
			float distanciaASalida = Vector2.Distance (transform.position, salida.position);
			if (distanciaASalida > 0.1f) {
				transform.position = Vector2.MoveTowards (transform.position, salida.position, velocidad * Time.deltaTime);
			} else {
				GameManager.instance.CaragarPanatallaVitoria ();
			}
		}
	}
//	if (jugador == null)
	void OnTriggerEnter2D (Collider2D abduccion){
		if (abduccion.gameObject.GetComponent <PlayerController>()){
			Destroy (abduccion.gameObject);
		}
	}

}
 
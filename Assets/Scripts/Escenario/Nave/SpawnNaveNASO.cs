using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNaveNASO : MonoBehaviour {

	public GameObject nave;


	public void NaveAlRescate(){
		Instantiate (nave, transform.position, transform.rotation);
	}
}

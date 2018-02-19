using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetaManager : MonoBehaviour {

	public float velocidadRotacion;

	
	// Update is called once per frame
	void Update () {
	
		transform.Rotate (Vector3.forward * Time.deltaTime * velocidadRotacion);

	}
}

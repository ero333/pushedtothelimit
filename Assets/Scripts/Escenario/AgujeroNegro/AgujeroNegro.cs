using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgujeroNegro : MonoBehaviour {
	void OnCollisionEnter2D(Collision2D coll) {
		if(coll.gameObject.name != "arenaLimit")
			Destroy(coll.gameObject);
	}

}

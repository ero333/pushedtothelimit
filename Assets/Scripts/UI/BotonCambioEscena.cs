using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonCambioEscena : MonoBehaviour {
	public string escenaACambiar;

	public void CambioEscena(){
		SceneManager.LoadScene(escenaACambiar);
	}
}

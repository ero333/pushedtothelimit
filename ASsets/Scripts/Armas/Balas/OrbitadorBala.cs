using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitadorBala : MonoBehaviour {

    Rigidbody2D rbBala;
    PlanetAttractor planeta;

    private void Awake(){
        rbBala = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate(){
        if (planeta != null){
            planeta.Attract(rbBala);
        }
    }

    private void OnTriggerEnter2D(Collider2D hit){
       
        if (hit.CompareTag("Planet")){
            planeta = hit.GetComponent<PlanetAttractor>();
        }
    }
}

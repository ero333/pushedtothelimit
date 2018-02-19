using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {
    public int dano;

    private void OnTriggerEnter(Collider hit){
        if(hit.GetComponent<Vida>() != null){
            Vida objetivo = hit.GetComponent<Vida>();
            objetivo.Damage(dano);
        }
    }
}

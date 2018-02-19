using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {
    public int dano;

    private void OnTriggerEnter2D(Collider2D hit){
        if (hit.GetComponent<Vida>() != null)
        {
            Vida objetivo = hit.GetComponent<Vida>();
            objetivo.Damage(dano);
        }
    }
}

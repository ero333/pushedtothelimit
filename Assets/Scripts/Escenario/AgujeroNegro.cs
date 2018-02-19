using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgujeroNegro : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D hit){
        Destroy(hit);
    }
    
}

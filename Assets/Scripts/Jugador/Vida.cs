using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour {
    public int vida;

    private void Update(){
        ControlVida();
    }

    void ControlVida(){
        if(vida <= 0){
            Destroy(gameObject);
        }
    }

    public void Damage(int hit){
        vida -= hit;
    }

    public void Healer(int aCurar){
        vida += aCurar;
    }
}

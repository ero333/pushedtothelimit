using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

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

    private void OnDestroy()
    {
        Analytics.CustomEvent("Morir", new Dictionary<string, object> { { "Vida", vida } });
    }
}

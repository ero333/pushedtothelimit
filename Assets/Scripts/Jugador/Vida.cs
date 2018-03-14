using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class Vida : MonoBehaviour {
    public int vida;
	public Slider barraHp;

    private void Update(){
        ControlVida();
    }

    void ControlVida(){
		barraHp.value = vida;
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

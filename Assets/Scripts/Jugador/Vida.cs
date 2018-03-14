using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class Vida : MonoBehaviour {
    public int vida;
	public Slider barraHp;
	public Sprite playDeath;

    private void Update(){
        ControlVida();
    }

    void ControlVida(){
		barraHp.value = vida;
        if(vida <= 0){
			gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
			if ((gameObject.transform.position.x < 12) && (gameObject.transform.position.x > -12) && (gameObject.transform.position.y < 12) && (gameObject.transform.position.y > -12))
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

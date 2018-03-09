using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limites : MonoBehaviour {
    public Vector2[] sizeBoxCollider;
    public Vector2[] positionBoxCollider;
    public float powerForce = 200;

    void Start () {
        BoxCollider2D[] colls = GetComponents<BoxCollider2D>();
        int index = 0;
        foreach(BoxCollider2D box in colls)
        {
            box.size = sizeBoxCollider[index];
            box.offset = positionBoxCollider[index];
            index++;
        }
	}

	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D other)
    {
		
        if (other.gameObject.tag.Equals("Player"))
        {
			
			Jetpack jet = other.gameObject.GetComponent<Jetpack>();
            PlayerController pControl = other.gameObject.GetComponent<PlayerController>();
			if (pControl != null) {
				pControl.jetPackEnabled = false;
				pControl.playerVelocity = -1 * other.transform.position * powerForce;
			}

			if (jet != null) {
				jet.activado = false;
			}
        }

    }
}

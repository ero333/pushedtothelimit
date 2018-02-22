using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetAttractor : MonoBehaviour {
    public float gravity = -9.8f;
    public float RotSpeed = 1;

	/*
    void Update()
    {
        Collider2D other = Physics2D.OverlapCircle(transform.position, radius);
        if(other != null && other.tag.Equals("Player"))
        {
            other.gameObject.GetComponent<PlayersGravitySensor>().planet = this;
        }
    }*/


    public void Attract(Rigidbody2D body)
    {
        Vector2 pos = new Vector2(transform.position.x, transform.position.y);
        Vector2 gravityUp = (body.position-pos).normalized;
        Vector2 localUp = body.transform.up;
        
        body.AddForce(gravityUp * gravity);

        body.transform.up = Vector2.Lerp(body.transform.up, gravityUp, Time.deltaTime* RotSpeed);        
    }


}

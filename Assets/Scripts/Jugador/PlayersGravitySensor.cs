using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayersGravitySensor : MonoBehaviour {
    public PlanetAttractor planet;
    private Rigidbody2D rbPlayer;

    void Awake()
    {
        //planet = GameObject.FindGameObjectWithTag("Planet").GetComponent<PlanetAttractor>();
        rbPlayer = GetComponent<Rigidbody2D>();        
    }

    void FixedUpdate()
    { 
        if (planet != null)
            planet.Attract(rbPlayer);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Planet"))
            planet = other.gameObject.GetComponent<PlanetAttractor>();
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Planet") && other.GetComponent<PlanetAttractor>() == planet)
            planet = null;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackFireController : MonoBehaviour {

    public GameObject jetpack;
    public GameObject jetpackSprite;
    public ParticleSystem jetpackFireParticle;
    private Animator jetpackAnimator;

    public bool isUsingParticles; // Este bool es para elegir entre partículas y animación.

	void Start () {
        // isUsingParticles = true;
        jetpackAnimator = jetpack.GetComponentInChildren<Animator>();
        jetpackAnimator.enabled = false; // Apago la animación por las dudas
        jetpackFireParticle.Stop(); // También apago el sistema de partículas, también por las dudas.
    }
	
    public void OnJetpackEnabled()
    {
        if (isUsingParticles) // Si decido usar el sistema de partículas les doy play...
        {
            jetpackFireParticle.Play();
        }
        else // Si no, activo el sprite y su animación.
        {
            jetpackAnimator.enabled = true;
            jetpackSprite.SetActive(true);
        }
    }

    public void OnJetpackDisabled()
    {
        if (isUsingParticles)
        {
            jetpackFireParticle.Stop();
        }
        else
        { 
            jetpackAnimator.enabled = false;
            jetpackSprite.SetActive(false);
        }
    }
}

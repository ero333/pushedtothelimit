using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackFireController : MonoBehaviour {

    public GameObject jetpack;
    public GameObject jetpackSprite;
    private Animator jetpackAnimator;
	// Use this for initialization
	void Start () {
        jetpackAnimator = jetpack.GetComponentInChildren<Animator>();
        jetpackAnimator.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnJetpackEnabled()
    {
        jetpackAnimator.enabled = true;
        jetpackSprite.SetActive(true);
    }

    public void OnJetpackDisabled()
    {
        jetpackAnimator.enabled = false;
        jetpackSprite.SetActive(false);
    }
}

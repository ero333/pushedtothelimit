using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PusherBullet : BaseBullet
{
    private Weapon _weapon;
	private float pushPower = 20000.0f;
	private float bulletSpeed = 10.0f;
	private Rigidbody2D rbPlayer;
	private Rigidbody2D rbBullet;
	private Vector2 pushVelocidad;
	private Vector2 pushFuerza;

    public override void OnShot()
    {
		Debug.Log("ExampleBullet disparada", gameObject);
		rbBullet = GetComponent<Rigidbody2D>();
		//rbBullet.isKinematic = false;
		//rbBullet.AddForce (transform.right * bulletSpeed);
		rbBullet.velocity = transform.right * bulletSpeed;
		Debug.Log ("La bala se mueve", gameObject);
		Destroy (this.gameObject, 1);
    }

    protected override void ApplyEffectOnPlayer(GameObject player)
    {
		rbPlayer = player.GetComponent<Rigidbody2D> ();
		rbPlayer.AddForce (rbPlayer.transform.right * pushPower);

    }
}
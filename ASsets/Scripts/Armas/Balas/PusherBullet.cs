using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PusherBullet : BaseBullet
{
    private Weapon _weapon;
	public float pushPower = 100.0f;
	public float bulletSpeed = 5000.0f;
	private Rigidbody2D rbPlayer;
	private Rigidbody2D rbBullet;
	private Vector2 pushVelocidad;
	private Vector2 pushFuerza;

	private int enemyname; //Quien recibe el disparo?
	private PlayerController playcontrol;

	public override void OnShot(int shooter)
    {
		rbBullet = GetComponent<Rigidbody2D>();
		rbBullet.velocity = transform.right * bulletSpeed;
		Destroy (this.gameObject, 0.05f);
    }

    protected override void ApplyEffectOnPlayer(GameObject player)
    {
		playcontrol =  player.GetComponent<PlayerController> ();
		enemyname = playcontrol.PlayerName; 
		//Comparo los PlayerNames, si son iguales no aplica el efecto, sino hace el Push
		if (_playerName != enemyname) {
			rbPlayer = player.GetComponent<Rigidbody2D> ();
			rbPlayer.AddForce (rbPlayer.transform.up * pushPower);
			player.transform.parent = null;
		}
	
    }
}
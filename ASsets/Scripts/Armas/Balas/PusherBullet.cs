using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PusherBullet : BaseBullet
{
    private Weapon _weapon;
	public float pushPower = 20000.0f;
	public float bulletSpeed = 500.0f;
	private Rigidbody2D rbPlayer;
	private Rigidbody2D rbBullet;
	private Vector2 pushVelocidad;
	private Vector2 pushFuerza;

	private int playername; //Quien dispara?
	private int enemyname; //Quien recibe el disparo?
	private PlayerController playcontrol;

	public override void OnShot(int shooter)
    {
		Debug.Log("ExampleBullet disparada", gameObject);
		playername = shooter;
		Debug.Log (shooter);
		rbBullet = GetComponent<Rigidbody2D>();
		rbBullet.velocity = transform.right * bulletSpeed;
		Debug.Log ("La bala se mueve", gameObject);
		Destroy (this.gameObject, 1);
    }

    protected override void ApplyEffectOnPlayer(GameObject player)
    {
		playcontrol =  player.GetComponent<PlayerController> ();
		if (playcontrol != null)
			Debug.Log ("Hay PlayerController");
		enemyname = playcontrol.PlayerName; 
		Debug.Log (enemyname);
		//Comparo los PlayerNames, si son iguales no aplica el efecto, sino hace el Push
		if (playername != enemyname) {
			rbPlayer = player.GetComponent<Rigidbody2D> ();
			rbPlayer.AddForce (rbPlayer.transform.right * pushPower);
		}
	
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayersGravitySensor))]
public class PlayerController : MonoBehaviour {
	public Transform groundCheck;
	public Transform rotatePoint;
	public float angle = 2;
    public float walkSpeed = 6;
    public float jumpForce = 220;
	public float powerJetpack = 220;
    public LayerMask groundedMask;
    
    
    private Vector2 moveAmount;
    private Vector2 smoothMoveVelocity;
    private float verticalLookRotation;
    private Transform cameraTransform;
    private Rigidbody2D rbPlayer;

    private PlayerInputManager _inputManager;
    

	public PlayerInputManager GetInputManager { get { return _inputManager; } }

    void Awake()
    {        
        rbPlayer = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
		Collider2D[] coll2d = Physics2D.OverlapCircleAll ((Vector2)groundCheck.position, 0.01f);
        float inputX = _inputManager.MovementAxisValue;

		if (inputX != 0 && coll2d.Length > 1)
			rbPlayer.velocity = ((Vector2)transform.right * inputX) * walkSpeed;

		if (_inputManager.JumpWasJustPressed && coll2d.Length > 1)
			rbPlayer.AddForce(transform.up * jumpForce);

		if (_inputManager.JetpackThurstIsPressed /* && coll2d.Length > 0*/) {
			rbPlayer.velocity = (transform.up * powerJetpack);
			if (inputX != 0)
				transform.RotateAround (rotatePoint.position, Vector3.forward, inputX * angle);
			
		} else if (coll2d.Length == 0 && inputX != 0) {
			transform.RotateAround (rotatePoint.position, Vector3.forward, inputX * angle);

		}
	

    }

    public void InitializeInputController(int playerNumber)
    {
        _inputManager = new PlayerInputManager(this, playerNumber);
    }
	/*
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.name == "Agujero Negro")
			Destroy (gameObject);

	}*/
		
}

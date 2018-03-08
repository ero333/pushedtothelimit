using CatPot.Framework.Messaging;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayersGravitySensor))]
public class PlayerController : MonoBehaviour {
	public Transform groundCheck;
	public Transform rotatePoint;
	public float angle = 2;
    public float walkSpeed = 6;
    public float jumpPower = 220;
    public LayerMask groundedMask;
	public float powerJetpack = 220;
	public int PlayerName;

    private Vector2 moveAmount;
    private Vector2 smoothMoveVelocity;
    private float verticalLookRotation;
    private Transform cameraTransform;
    private Rigidbody2D rbPlayer;
	private bool jetPackEnabled;
	private bool isGamePad = true;
    private PlayerInputManager _inputManager;

	/*Variables condicionales para el movimiento*/
	private float inputX;
	private bool jump;
	private bool jetpackAction;
	private Vector2 playerVelocity;
	private Vector2 jumpForce;
	private Collider2D[] coll2d;

    public JetpackFireController jetpackController;

    Jetpack jetpack;


	public PlayerInputManager GetInputManager { get { return _inputManager; } }

    void Awake()
    {        
		//Para test
		//InitializeInputController (1);
		//PlayerName = 1;
		//isGamePad = false;
		//fin para test
        rbPlayer = GetComponent<Rigidbody2D>();
		coll2d = new Collider2D[0];
        jetpack = GetComponent<Jetpack>();
    }

	void Update()
	{		
		GamePadControl ();
		KeyboardControl ();
	}

    void FixedUpdate()
	{
		rbPlayer.velocity = playerVelocity;
		rbPlayer.AddForce (jumpForce);
		jumpForce = Vector2.zero;
		inputX = 0;
		if (coll2d.Length != 0)
			playerVelocity = Vector2.zero;
	}
    /*
	void OnCollisionExit2D(Collision2D col){
		
		if (col.gameObject.tag == "arenaLimit") {
			//Si sale de los limites el jetpack deja de funcionar hasta volver a un planeta
			jetPackEnabled = false;
            jetpackController.OnJetpackDisabled();
		}
	}

	void OnCollisionEnter2D(Collision2D col){

		if (col.gameObject.tag == "Planet") {
			//Al tocar un planeta se "recarga" el Jetpack
			jetPackEnabled = true;
            jetpackController.OnJetpackDisabled();
		}

	}
    */
    public void InitializeInputController(int playerNumber)
    {
        _inputManager = new PlayerInputManager(this, playerNumber);
    }

	void KeyboardControl()
	{
		coll2d = Physics2D.OverlapCircleAll ((Vector2)groundCheck.position, 0.01f);


		if (PlayerName == 1) {
			if (Input.GetKey (KeyCode.A))
				inputX = -1;

			if (Input.GetKey (KeyCode.D))
				inputX = 1;

			jump = Input.GetKeyDown (KeyCode.W);
			jetpackAction = Input.GetKey (KeyCode.W);
		}

		if (PlayerName == 2) {
			if (Input.GetKey (KeyCode.LeftArrow))
				inputX = -1;

			if (Input.GetKey(KeyCode.RightArrow))
				inputX = 1;
			
			jump = Input.GetKeyDown (KeyCode.UpArrow);
            jetpackAction = Input.GetKey(KeyCode.UpArrow);
        }

		if (PlayerName == 3) {
			if (Input.GetKey (KeyCode.J))
				inputX = -1;

			if (Input.GetKey (KeyCode.L))
				inputX = 1;

			jump = Input.GetKeyDown (KeyCode.I);
			jetpackAction = Input.GetKey (KeyCode.I);
		}

		if (PlayerName == 4) {
			if (Input.GetKey (KeyCode.Keypad4))
				inputX = -1;

			if (Input.GetKey (KeyCode.Keypad6))
				inputX = 1;

			jump = Input.GetKeyDown (KeyCode.Keypad8);
			jetpackAction = Input.GetKey (KeyCode.Keypad8);
		}

		if (inputX != 0 && coll2d.Length > 1)
			playerVelocity = ((Vector2)transform.right * inputX) * walkSpeed;
		
		if(coll2d.Length > 0 && jetpackAction)
		{
			jumpForce = (transform.up * jumpPower);

		}
		else if (jetpackAction) {
            //if(jetPackEnabled)
            	
			//playerVelocity = (transform.up * powerJetpack);
            /*jetpackController.OnJetpackEnabled();
            */
            jetpack.Movimiento();
            if (inputX != 0)
				transform.RotateAround (rotatePoint.position, Vector3.forward, inputX * angle);

		} else if (coll2d.Length == 0 && inputX != 0) {
			transform.RotateAround (rotatePoint.position, Vector3.forward, inputX * angle);
		}
	}

	void GamePadControl()
	{
		coll2d = Physics2D.OverlapCircleAll ((Vector2)groundCheck.position, 0.01f);
		inputX = _inputManager.MovementAxisValue;

		if (inputX != 0 && coll2d.Length > 1) {
			playerVelocity = ((Vector2)transform.right * inputX) * walkSpeed;

		}

		if (_inputManager.JumpWasJustPressed && coll2d.Length > 1) {
			jumpForce = (transform.up * jumpPower);

		}

		if(coll2d.Length > 0 && _inputManager.JetpackThurstIsPressed)
		{
			jumpForce = (transform.up * jumpPower);

		}
		else if(_inputManager.JetpackThurstIsPressed /* && coll2d.Length > 0*/) {
			//if(jetPackEnabled)	
				playerVelocity = (transform.up * powerJetpack);
				jetpackController.OnJetpackEnabled();



			if (inputX != 0) {
				transform.RotateAround (rotatePoint.position, Vector3.forward, inputX * angle);
			
			}

		} else if (coll2d.Length == 0 && inputX != 0) {
			transform.RotateAround (rotatePoint.position, Vector3.forward, inputX * angle);

		}
	}

    private void OnDestroy()
    {
        EventDispatcher.Instance.Dispatch(new PlayerDiedEvent(gameObject, this));
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerController))]
public class FlipPlayerController : MonoBehaviour {
	public Transform weaponAnchor;
	private PlayerInputManager _input;
	private PlayerController controller;
	private int PlayerName;
	private float inputX;

	void Start () {
		controller = GetComponent<PlayerController> ();
		if (controller != null)
			PlayerName = controller.PlayerName;
		else
			PlayerName = 0;

		_input = controller.GetInputManager;

		inputX = 1;
	}
	

	void Update () {
		FlipPlayer ();
	}

	private void FlipPlayer()
	{
		KeyBoardResult ();
		//GamepadResult ();
		Vector3 rotation = transform.localEulerAngles;
		if (inputX > 0) {
			transform.localScale = new Vector3(1,1,1);
			weaponAnchor.localRotation = Quaternion.Euler (0, 0, 0);
			//transform.Find("WeaponAnchor").localScale = new Vector3 (1,1,1);
		} else if(inputX < 0){
			transform.localScale = new Vector3(-1,1,1);
			weaponAnchor.localRotation = Quaternion.Euler (0, 180, 0);
			//transform.Find("WeaponAnchor").localScale = new Vector3 (-1,1,1);

		}
		inputX = 0;
	}

	private void KeyBoardResult()
	{
		
		if (PlayerName == 1) {
			if (Input.GetKey (KeyCode.A))
				inputX = -1;

			if (Input.GetKey (KeyCode.D))
				inputX = 1;
			
		}

		if (PlayerName == 2) {
			if (Input.GetKey (KeyCode.LeftArrow))
				inputX = -1;

			if (Input.GetKey (KeyCode.RightArrow))
				inputX = 1;
			
		}

		if (PlayerName == 3) {
			if (Input.GetKey (KeyCode.J))
				inputX = -1;

			if (Input.GetKey (KeyCode.L))
				inputX = 1;
			
		}

		if (PlayerName == 4) {
			if (Input.GetKey (KeyCode.Keypad4))
				inputX = -1;

			if (Input.GetKey (KeyCode.Keypad6))
				inputX = 1;
			
		}
	}

	private void GamepadResult()
	{
		if (_input != null) {
			inputX = _input.MovementAxisValue;
		}
	}
}

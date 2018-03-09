using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    public GameObject DefaultWeaponPrefab;

	public Weapon _defaultWeapon;
	public Transform _weaponPosition;

	public Weapon _activeWeapon;
	int playername;
	private PlayerController playcontrol;
	private bool shoot = false;
	private PlayerInputManager inputControl;

	void Start () {
        ResetToDefaultWeapon();
        playcontrol = GetComponent<PlayerController> ();
		inputControl = playcontrol.GetInputManager;

		if (playcontrol != null)
			playername = playcontrol.PlayerName;

	}

	void Update(){
		ShootWeapon (_activeWeapon);
	}

    private void ResetToDefaultWeapon()
    {
        _activeWeapon = Instantiate(DefaultWeaponPrefab, _weaponPosition.position, Quaternion.identity).GetComponent<Weapon>();
        _activeWeapon.transform.parent = _weaponPosition;
    }

	public void ShootWeapon (Weapon newWeapon){

		if (playername == 1) {
			if (Input.GetKeyDown (KeyCode.S)) {
				//Debug.Log ("Player 1 dispara");
				shoot = true;
			}
			
		}

		if (playername == 2) {
			if (Input.GetKeyDown (KeyCode.DownArrow))
				shoot = true;
		}

		if (playername == 3) {
			if (Input.GetKey (KeyCode.K))
				shoot = true;
		}

		if (playername == 4) {
			if (Input.GetKey (KeyCode.Keypad5))
				shoot = true;
		}

		if (inputControl.ShootIsPressed)
			shoot = true;

		if (shoot) {
			//Debug.Log (shoot);
			_activeWeapon.Shoot (playername);

            if (_activeWeapon.IsEmpty)
                ResetToDefaultWeapon();
        }

		shoot = false;
	}
}

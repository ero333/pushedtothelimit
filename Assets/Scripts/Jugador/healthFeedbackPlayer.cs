using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerController))]
public class healthFeedbackPlayer : MonoBehaviour {
	public float VibrateIntensity = 1f;
	public float vibrateTime = 1f;
	public float timerFeedback = 1f;
	public SpriteRenderer srPlayer;
	private float timer;
	private PlayerInputManager playerInput;
	private Color dangerColor;
	private Color normalColor;
	void Start () {
		timer = timerFeedback;
		dangerColor = Color.red;
		normalColor = srPlayer.color;
		playerInput = GetComponent<PlayerController> ().GetInputManager;
	}
	

	void Update () {
		if (Feedback) {
			timer = timerFeedback;
			Feedback = false;
		}

		timer -= Time.deltaTime;

		if (timer > 0)
			ShowFeedback ();

		if(timer < 0 && srPlayer.color != normalColor)
			srPlayer.color = normalColor;
	}

	private void ShowFeedback()
	{
		playerInput.Vibrate(VibrateIntensity, vibrateTime);
		srPlayer.color = dangerColor;
	}

	public bool Feedback { get; set; } 
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuController : MonoBehaviour {
	public Button btnPlay;
	public Button btnExit;
    public string lvlACargar;

	void Start ()
	{
		btnExit.onClick.AddListener(Exit);
		btnPlay.onClick.AddListener(Play);	
	}

	void Update ()
	{
	}

	private void Controllers()
	{
		SceneManager.LoadScene ("");
	}

	private void Play()
	{
		SceneManager.LoadScene ("lvlACargar");
	}

	private void Exit()
	{
		Application.Quit();
	}
}

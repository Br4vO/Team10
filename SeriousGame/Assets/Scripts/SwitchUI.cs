﻿using UnityEngine;
using System.Collections;

public class SwitchUI : MonoBehaviour {

	private GameObject startUI;
	private GameObject inGameUI;
	private GameObject endGameUI;

	void Awake()
	{
		startUI = GameObject.Find ("StartGameUI");
		inGameUI = GameObject.Find ("InGameUI");
		endGameUI = GameObject.Find ("EndGameUI");

		inGameUI.gameObject.SetActive (false);
		endGameUI.gameObject.SetActive (false);
	}

	public void toStart()
	{
		startUI.gameObject.SetActive (true);
		endGameUI.gameObject.SetActive (false);
	}

	public void toIngame()
	{
		startUI.gameObject.SetActive (false);
		inGameUI.gameObject.SetActive (true);
		GameObject.Find ("LevelManager").GetComponent<LevelManager> ().showPickupStats ();
	}

	public void toEnd()
	{
		inGameUI.gameObject.SetActive (false);
		endGameUI.gameObject.SetActive (true);
		GameObject.Find ("LevelManager").GetComponent<LevelManager> ().removePickupStats ();
	}
}

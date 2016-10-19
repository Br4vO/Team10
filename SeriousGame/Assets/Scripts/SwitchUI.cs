using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
        GameObject.Find("InputController").GetComponent<InputController>().SetPaused(true);
    }

	public void toIngame()
	{
		startUI.gameObject.SetActive (false);
		inGameUI.gameObject.SetActive (true);
		GameObject.Find ("LevelManager").GetComponent<LevelManager> ().showPickupStats ();

        //reset energy bar
        RectTransform energyBarTransform = GameObject.Find("EnergyBar").GetComponent<RectTransform>();
        energyBarTransform.sizeDelta = new Vector2(0, energyBarTransform.rect.height);

        GameObject.Find("PlayerUIImage").GetComponent<Image>().sprite = GameObject.Find("LevelManager").GetComponent<LevelManager>().heads[0];
        GameObject.Find("InputController").GetComponent<InputController>().SetPaused(false);
    }

	public void toEnd()
	{
		inGameUI.gameObject.SetActive (false);
		endGameUI.gameObject.SetActive (true);

	GameObject.Find ("LevelManager").GetComponent<LevelManager> ().removePickupStats ();
        GameObject.Find("InputController").GetComponent<InputController>().SetPaused(true);
    }
}

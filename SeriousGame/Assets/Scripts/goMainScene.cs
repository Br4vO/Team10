using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class goMainScene : MonoBehaviour {

	public void StartGame()
	{
		SceneManager.LoadScene ("main");
	}
}

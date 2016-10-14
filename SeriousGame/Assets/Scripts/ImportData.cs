using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[System.Serializable]

enum Foods
{
	None = 0,
	Apple,
	Broccoli,
	Banana,
	Orange,
	Cheese,
	Fish, 
	Egg, 
	Carrot, 
	Burger, 
	Pizza, 
	Soda, 
	FrenchFries, 
	CandyBar, 
	IceCream
};

public class ImportData : MonoBehaviour {
	TextAsset asset;
	JsonData data;
	FoodSpawner foodSpawner;

	Vector2[,] tilePosition;
	// Use this for initialization
	void Start () 
	{
		foodSpawner = GameObject.Find ("FoodSpawner").GetComponent<FoodSpawner>();

		asset = Resources.Load("pickupObjectPosition") as TextAsset;
		Debug.Log (asset);
		data =JsonUtility.FromJson<JsonData>(asset.text);
		for (int i = 0; i < 18; i++)
		{
			Debug.Log(data.level1[i]);
			Debug.Log(data.level2[i]);
		}
		buildTiles ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void buildTiles()
	{
		tilePosition = new Vector2[3, 6];

		for (int i = 5; i >= 0; i--) 
		{
			for (int j = 0; j < 3; j++)
			{
				tilePosition [j, i] = new Vector2 (j, i);			
			}
		}
	}
		
}

class JsonData
{
	//public List<int[]> level1;
	public int[] level1 = new int[18];
	public int[] level2 = new int[18];
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[System.Serializable]

public class ImportData : MonoBehaviour {
	TextAsset asset;
	JsonData data;
	FoodSpawner foodSpawner;
	public List<int[,]> foodPlaceByLevel; 
	// Use this for initialization
	void Awake () 
	{
		foodPlaceByLevel = new List<int[,]>();

		foodSpawner = GameObject.Find ("FoodSpawner").GetComponent<FoodSpawner>();

		asset = Resources.Load("pickupObjectPosition") as TextAsset;
		Debug.Log (asset);
		data =JsonUtility.FromJson<JsonData>(asset.text);
		//Inserting 14 level arrays
		for (int i = 0; i <14; i++)
			foodPlaceByLevel.Insert (foodPlaceByLevel.Count,new int[3, 6]);
		buildTiles ();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void buildTiles()
	{


		List<int[]> foodMapData = new List<int[]>();
		foodMapData.Add (data.level1);
		foodMapData.Add (data.level2);
		foodMapData.Add (data.level3);
		foodMapData.Add (data.level4);
		foodMapData.Add (data.level5);
		foodMapData.Add (data.level6);
		foodMapData.Add (data.level7);
		foodMapData.Add (data.level8);
		foodMapData.Add (data.level9);
		foodMapData.Add (data.level10);
		foodMapData.Add (data.level11);
		foodMapData.Add (data.level12);
		foodMapData.Add (data.level13);
		foodMapData.Add (data.level14);

		for (int l = 0; l < 14; l++) 
		{
			for (int i = 5; i >= 0; i--)
			{
				for (int j = 0; j < 3; j++) 
				{
					foodPlaceByLevel [l] [j, i] = foodMapData[l][j + ((5 - i) * 3)];
				}
			}
		}
	}
		
}

class JsonData
{
	public int[] level1 = new int[18];
	public int[] level2 = new int[18];
	public int[] level3 = new int[18];
	public int[] level4 = new int[18];
	public int[] level5 = new int[18];
	public int[] level6 = new int[18];
	public int[] level7 = new int[18];
	public int[] level8 = new int[18];
	public int[] level9 = new int[18];
	public int[] level10 = new int[18];
	public int[] level11 = new int[18];
	public int[] level12 = new int[18];
	public int[] level13 = new int[18];
	public int[] level14 = new int[18];
}

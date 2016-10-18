using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[System.Serializable]

public class ImportData : MonoBehaviour {
	TextAsset asset;
	JsonData data;
	FoodSpawner foodSpawner;
	List<GameObject[,]> foodPlaceByLevel; 
	// Use this for initialization
	void Start () 
	{
		foodPlaceByLevel = new List<GameObject[,]>();

		foodSpawner = GameObject.Find ("FoodSpawner").GetComponent<FoodSpawner>();

		asset = Resources.Load("pickupObjectPosition") as TextAsset;
		Debug.Log (asset);
		data =JsonUtility.FromJson<JsonData>(asset.text);
		//Inserting 2 level arrays
		foodPlaceByLevel.Insert (foodPlaceByLevel.Count,new GameObject[3, 6]);
		foodPlaceByLevel.Insert (foodPlaceByLevel.Count,new GameObject[3, 6]);
		buildTiles ();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void buildTiles()
	{
		List<GameObject> poolOfFoods;

		for (int i = 5; i >= 0; i--) 
		{
			for (int j = 0; j < 3; j++)
			{
				Debug.Log((FoodSpawner.Foods)data.level1 [j + i]);

				if (data.level1 [j + ((5-i)*3)] != 0) 
				{
					foodSpawner.foodPool.TryGetValue ((FoodSpawner.Foods)data.level1 [j + ((5-i)*3)], out poolOfFoods);
					//Finding available food

					int k = 0;
					while (poolOfFoods [k].transform.position.x != 0 || poolOfFoods [k].transform.position.z != -3) 
					{
						k++;
					}
					foodPlaceByLevel [0] [j, i] = poolOfFoods [k];
					foodPlaceByLevel [0] [j, i].transform.position = new Vector3 (j, 0, i);
					Debug.Log(foodPlaceByLevel [0] [j, i].transform.position);
				}
			}
		}
	}
		
}

class JsonData
{
	public int[] level1 = new int[18];
	public int[] level2 = new int[18];
}

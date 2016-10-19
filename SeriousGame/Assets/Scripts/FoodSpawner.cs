using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class FoodSpawner : MonoBehaviour {

	public int poolSize;
	public Dictionary<Foods, List<GameObject>> foodPool;

	// Use this for initialization
	void Awake () 
	{
		foodPool = new Dictionary<Foods,List<GameObject>> ();
		foodPool.Add(Foods.Apple, new List<GameObject>());
		foodPool.Add(Foods.Broccoli, new List<GameObject>());
		foodPool.Add(Foods.Banana, new List<GameObject>());
		foodPool.Add(Foods.Orange, new List<GameObject>());
		foodPool.Add(Foods.Cheese, new List<GameObject>());
		foodPool.Add(Foods.Fish, new List<GameObject>());
		foodPool.Add(Foods.Egg, new List<GameObject>());
		foodPool.Add(Foods.Carrot, new List<GameObject>());
		foodPool.Add(Foods.Burger, new List<GameObject>());
		foodPool.Add(Foods.Pizza, new List<GameObject>());
		foodPool.Add(Foods.Soda, new List<GameObject>());
		foodPool.Add(Foods.FrenchFries, new List<GameObject>());
		foodPool.Add(Foods.CandyBar, new List<GameObject>());
		foodPool.Add(Foods.IceCream, new List<GameObject>());

		for (int i = 0; i < poolSize; ++i)
		{
			foodPool [Foods.Apple].Add((GameObject)Instantiate(Resources.Load("Prefabs/Apple")));
			foodPool [Foods.Broccoli].Add((GameObject)Instantiate(Resources.Load("Prefabs/Broccoli")));
			foodPool [Foods.Banana].Add((GameObject)Instantiate(Resources.Load("Prefabs/Banana")));
			foodPool [Foods.Orange].Add((GameObject)Instantiate(Resources.Load("Prefabs/Orange")));
			foodPool [Foods.Cheese].Add((GameObject)Instantiate(Resources.Load("Prefabs/Cheese")));
			foodPool [Foods.Fish].Add((GameObject)Instantiate(Resources.Load("Prefabs/Fish")));
			foodPool [Foods.Egg].Add((GameObject)Instantiate(Resources.Load("Prefabs/Egg")));
			foodPool [Foods.Carrot].Add((GameObject)Instantiate(Resources.Load("Prefabs/Carrot")));
			foodPool [Foods.Burger].Add((GameObject)Instantiate(Resources.Load("Prefabs/Burger")));
			foodPool [Foods.Pizza].Add((GameObject)Instantiate(Resources.Load("Prefabs/Pizza")));
			foodPool [Foods.Soda].Add((GameObject)Instantiate(Resources.Load("Prefabs/Soda")));
			foodPool [Foods.FrenchFries].Add((GameObject)Instantiate(Resources.Load("Prefabs/Fries")));
			foodPool [Foods.CandyBar].Add((GameObject)Instantiate(Resources.Load("Prefabs/Candy")));
			foodPool [Foods.IceCream].Add((GameObject)Instantiate(Resources.Load("Prefabs/IceCream")));
		}
	}

	public enum Foods
	{
		None = 0,
		Apple = 1,
		Broccoli= 2,
		Banana= 3,
		Orange= 4,
		Cheese= 5,
		Fish= 6, 
		Egg= 7, 
		Carrot= 8, 
		Burger= 9, 
		Pizza= 10, 
		Soda= 11, 
		FrenchFries= 12, 
		CandyBar= 13, 
		IceCream= 14
	};

}


using UnityEngine;
using System.Collections;

public enum FoodGroups
{
	Fruit = 0,
	Vegetable,
	Junk,
	Dairy,
	Grain,
	Meat
}

public class FoodInfo : MonoBehaviour {
	public FoodGroups foodGroup;
	public string description;

	// Use this for initialization
	void Start () 
	{
	}

}

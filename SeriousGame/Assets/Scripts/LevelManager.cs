﻿using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class Food
{
    public int Apple, Broccoli, Banana, Orange, Cheese, Fish, Egg, Carrot;
    public int Burger, Pizza, Soda, FrenchFries, CandyBar, IceCream;

    public Food()
    {
        Apple = 0;
        Broccoli = 0;
        Banana = 0;
        Orange = 0;
        Cheese = 0;
        Fish = 0;
        Egg = 0;
        Carrot = 0;
        Burger = 0;
        Pizza = 0;
        Soda = 0;
        FrenchFries = 0;
        CandyBar = 0;
        IceCream = 0;
    }

    public void Reset()
    {
        Apple = 0;
        Broccoli = 0;
        Banana = 0;
        Orange = 0;
        Cheese = 0;
        Fish = 0;
        Egg = 0;
        Carrot = 0;
        Burger = 0;
        Pizza = 0;
        Soda = 0;
        FrenchFries = 0;
        CandyBar = 0;
        IceCream = 0;
    }

    public int GetTotalFood()
    {
        return Apple + Broccoli + Banana + Orange + Cheese + Fish + Egg + Carrot + Burger + Pizza + Soda + FrenchFries + CandyBar + IceCream;
    }
}

public class LevelManager : MonoBehaviour {
    private Food foodTotal;
    private Food weekTotal;
    private Food dayTotal;

	private FoodSpawner foodSpawner;

    private int currLevel;
    private List<Food> levelGoals;

	private List<GameObject[,]> FoodLevelObjects;

    private AudioSource gameMusic;

    public Sprite[] heads = new Sprite[4];

    void Awake()
    {
        Application.targetFrameRate = 60;
    }

	// Use this for initialization
	void Start () 
	{
		foodSpawner = GameObject.Find ("FoodSpawner").GetComponent<FoodSpawner>();
        gameMusic = GetComponent<AudioSource>();
        gameMusic.Play();

        foodTotal = new Food();
        weekTotal = new Food();
        dayTotal = new Food();
        currLevel = 1;
        levelGoals = new List<Food>();
		FoodLevelObjects = new List<GameObject[,]> ();
		for (int i = 0; i <14; i++)
			FoodLevelObjects.Insert (FoodLevelObjects.Count,new GameObject[3, 6]);

        CreateLevelGoals();
		SetupNextLevel ();
    }
	
	// Update is called once per frame
	void Update () 
	{
	
	}

    List<Food> GetLevelGoals()
    {
        return levelGoals;
    }

    int GetCurrentLevel()
    {
        return currLevel;
    }

	public void NextLevel()
	{
		currLevel++;
		SetupNextLevel ();
	}

    void CreateLevelGoals()
    {
        //level 1
        Food temp = new Food();
        temp.Apple = 3;
        levelGoals.Add(temp);

        //level 2
        temp = new Food();
        temp.Egg = 5;
        levelGoals.Add(temp);

        //level 3
        temp = new Food();
        temp.Broccoli = 2;
        temp.Fish = 2;
        levelGoals.Add(temp);

        //level 4
        temp = new Food();
        temp.Banana = 3;
        temp.Burger = 1;
        levelGoals.Add(temp);

        //level 5
        temp = new Food();
        temp.Broccoli = 2;
        temp.Orange = 3;
        temp.IceCream = 1;
        levelGoals.Add(temp);

        //level 6
        temp = new Food();
        temp.Apple = 2;
        temp.Carrot = 2;
        temp.FrenchFries = 1;
        temp.Soda = 1;
        levelGoals.Add(temp);

        //level 7
        temp = new Food();
        temp.CandyBar = 1;
        temp.Pizza = 1;
        temp.Broccoli = 1;
        temp.Banana = 1;
        levelGoals.Add(temp);
        
        //level 8
        temp = new Food();
        temp.Orange = 1;
        temp.Cheese = 1;
        temp.Fish = 1;
        temp.Carrot = 1;
        temp.Soda = 1;
        levelGoals.Add(temp);

        //level 9
        temp = new Food();
        temp.IceCream = 1;
        temp.Fish = 2;
        temp.Egg = 1;
        temp.Carrot = 1;
        temp.Broccoli = 1;
        temp.Orange = 1;
        temp.Apple = 1;
        levelGoals.Add(temp);

        //level 10
        temp = new Food();
        temp.Egg = 3;
        temp.Broccoli = 2;
        temp.Fish = 2;
        temp.Apple = 2;
        temp.Banana = 1;
        temp.Carrot = 1;
        temp.Cheese = 1;
        temp.Orange = 1;
        levelGoals.Add(temp);

        //level 11
        temp = new Food();
        temp.CandyBar = 1;
        temp.FrenchFries = 1;
        temp.Banana = 2;
        temp.Egg = 2;
        temp.Broccoli = 2;
        temp.Cheese = 2;
        levelGoals.Add(temp);
    }

	private void SetupNextLevel()
	{
		List<int[,]> tempData = this.GetComponent<ImportData> ().foodPlaceByLevel; 
		List<GameObject> poolOfFoods;

		if (GetCurrentLevel () - 3 >= 0) 
		{
			//Moving all objects form previous level back
			for (int i = 5; i >= 0; i--) 
			{
				for (int j = 0; j < 3; j++) 
				{
					if (FoodLevelObjects [GetCurrentLevel () - 2] [j, i])
						FoodLevelObjects [GetCurrentLevel () - 2] [j, i].transform.position = new Vector3 (0, 0, -3);
				}
			}
		} 


		//Moving objects to right place
		for (int i = 5; i >= 0; i--)
		{
			for (int j = 0; j < 3; j++) 
			{
				if (tempData [GetCurrentLevel () - 1] [j, i] != 0) 
				{
					foodSpawner.foodPool.TryGetValue ((FoodSpawner.Foods)tempData [GetCurrentLevel () - 1] [j, i], out poolOfFoods);
					//Finding available food

					int k = 0;
					while (poolOfFoods [k].transform.position.z != -3) {
						k++;
					}
					FoodLevelObjects [GetCurrentLevel () - 1] [j, i] = poolOfFoods [k];

					FoodLevelObjects [GetCurrentLevel () - 1] [j, i].transform.position = new Vector3 (j * .38333333f, 0, i * .38333333f);
				}
			}
		}

		//Reset player position
		GameObject.Find("player").transform.position = new Vector3(0.3833333f, 0f, -0.3833333f);
		GameObject.Find ("UI").GetComponent<SwitchUI> ().toStart ();
	}
    private void IncrementFoodCount(string foodName)
    {
        switch (foodName)
        {
            case "apple":
                foodTotal.Apple += 1;
                weekTotal.Apple += 1;
                dayTotal.Apple += 1;
                break;
            case "Banana":
                foodTotal.Banana += 1;
                weekTotal.Banana += 1;
                dayTotal.Banana += 1;
                break;
            case "broccoli":
                foodTotal.Broccoli += 1;
                weekTotal.Broccoli += 1;
                dayTotal.Broccoli += 1;
                break;
            case "Burger":
                foodTotal.Burger += 1;
                weekTotal.Burger += 1;
                dayTotal.Burger += 1;
                break;
            case "Candy":
                foodTotal.CandyBar += 1;
                weekTotal.CandyBar += 1;
                dayTotal.CandyBar += 1;
                break;
            case "Carrot":
                foodTotal.Carrot += 1;
                weekTotal.Carrot += 1;
                dayTotal.Carrot += 1;
                break;
            case "cheese":
                foodTotal.Cheese += 1;
                weekTotal.Cheese += 1;
                dayTotal.Cheese += 1;
                break;
            case "Egg":
                foodTotal.Egg += 1;
                weekTotal.Egg += 1;
                dayTotal.Egg += 1;
                break;
            case "Fish":
                foodTotal.Fish += 1;
                weekTotal.Fish += 1;
                dayTotal.Fish += 1;
                break;
            case "fries":
                foodTotal.FrenchFries += 1;
                weekTotal.FrenchFries += 1;
                dayTotal.FrenchFries += 1;
                break;
            case "IceCream":
                foodTotal.IceCream += 1;
                weekTotal.IceCream += 1;
                dayTotal.IceCream += 1;
                break;
            case "Orange":
                foodTotal.Orange += 1;
                weekTotal.Orange += 1;
                dayTotal.Orange += 1;
                break;
            case "Pizza":
                foodTotal.Pizza += 1;
                weekTotal.Pizza += 1;
                dayTotal.Pizza += 1;
                break;
            case "Soda":
                foodTotal.Soda += 1;
                weekTotal.Soda += 1;
                dayTotal.Soda += 1;
                break;
            default:
                break;
        }
    }

    private int GetLevelStepSize()
    {
        Food levelGoal = levelGoals[GetCurrentLevel() - 1];
        return (280 / levelGoal.GetTotalFood()) + 1; 
    }

    private int EnergyBarDirection(string foodName)
    {
        switch (foodName)
        {
            case "apple":
            case "broccoli":
            case "Carrot":
            case "Banana":
            case "cheese":
            case "Egg":
            case "Fish":
            case "Orange":
                return 1;
            case "Burger":
                return dayTotal.Burger > 1 ? -1 : 1;
            case "Pizza":
                return dayTotal.Pizza > 1 ? -1 : 1;
            case "fries":
                return dayTotal.FrenchFries > 1 ? -1 : 1;
            case "Candy":
                return dayTotal.CandyBar > 1 ? -1 : 1;
            case "IceCream":
                return dayTotal.IceCream > 1 ? -1 : 1;
            case "Soda":
                return dayTotal.Soda > 1 ? -1 : 1;
            default:
                return 1;
        }
    }

    private void UpdateUI(string foodName)
    {
        int stepSize = GetLevelStepSize();
        int direction = 1;

        //increment or decrement energy bar
        RectTransform energyBarTransform = GameObject.Find("EnergyBar").GetComponent<RectTransform>();
        energyBarTransform.sizeDelta = new Vector2(Math.Min(energyBarTransform.rect.width + (direction * stepSize), 280), energyBarTransform.rect.height);

        //update player UI image if needed
        const float energyBarMaxWidth = 280f;
        float energyPercent = energyBarTransform.rect.width / energyBarMaxWidth;

        if(energyPercent < .25f)
        {
            GameObject.Find("PlayerUIImage").GetComponent<Image>().sprite = heads[0];
        }
        else if(energyPercent < .5f)
        {
            GameObject.Find("PlayerUIImage").GetComponent<Image>().sprite = heads[1];
        }
        else if(energyPercent < .75f)
        {
            GameObject.Find("PlayerUIImage").GetComponent<Image>().sprite = heads[2];
        }
        else
        {
            GameObject.Find("PlayerUIImage").GetComponent<Image>().sprite = heads[3];
        }
    }

    public void FoodCollected(string foodName)
    {
        IncrementFoodCount(foodName);
        UpdateUI(foodName);   
    }
}

using UnityEngine;
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

	public List<int> GetGoalData()
	{
		List<int> GoalData = new List<int> ();
		GoalData.Add (Apple);
		GoalData.Add (Broccoli);
		GoalData.Add (Banana);
		GoalData.Add (Orange);		
		GoalData.Add (Cheese);
		GoalData.Add (Fish);
		GoalData.Add (Egg);
		GoalData.Add (Carrot);
		GoalData.Add (Burger);
		GoalData.Add (Pizza);
		GoalData.Add (Soda);
		GoalData.Add (FrenchFries);
		GoalData.Add (CandyBar);
		GoalData.Add (IceCream);

		return GoalData;
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

	private List<GameObject> GUIObjects;

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
		GUIObjects = new List<GameObject> ();
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
		temp.Cheese = 1;
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
		GameObject.Find ("player").GetComponent<PlayerHandler> ().position = new Vector2 (1, -1);
		GameObject.Find ("UI").GetComponent<SwitchUI> ().toStart ();

        //Reset food counters
        dayTotal.Reset();

        if(GetCurrentLevel() == 8)
        {
            weekTotal.Reset();
        }
    }
    private void IncrementFoodCount(string foodName)
    {
        switch (foodName)
        {
            case "apple":
            case "apple(Clone)":
                foodTotal.Apple += 1;
                weekTotal.Apple += 1;
                dayTotal.Apple += 1;
                break;
            case "Banana":
            case "Banana(Clone)":
                foodTotal.Banana += 1;
                weekTotal.Banana += 1;
                dayTotal.Banana += 1;
                break;
            case "broccoli":
            case "broccoli(Clone)":
                foodTotal.Broccoli += 1;
                weekTotal.Broccoli += 1;
                dayTotal.Broccoli += 1;
                break;
            case "Burger":
            case "Burger(Clone)":
                foodTotal.Burger += 1;
                weekTotal.Burger += 1;
                dayTotal.Burger += 1;
                break;
            case "Candy":
            case "Candy(Clone)":
                foodTotal.CandyBar += 1;
                weekTotal.CandyBar += 1;
                dayTotal.CandyBar += 1;
                break;
            case "Carrot":
            case "Carrot(Clone)":
                foodTotal.Carrot += 1;
                weekTotal.Carrot += 1;
                dayTotal.Carrot += 1;
                break;
            case "cheese":
            case "cheese(Clone)":
                foodTotal.Cheese += 1;
                weekTotal.Cheese += 1;
                dayTotal.Cheese += 1;
                break;
            case "Egg":
            case "Egg(Clone)":
                foodTotal.Egg += 1;
                weekTotal.Egg += 1;
                dayTotal.Egg += 1;
                break;
            case "Fish":
            case "Fish(Clone)":
                foodTotal.Fish += 1;
                weekTotal.Fish += 1;
                dayTotal.Fish += 1;
                break;
            case "fries":
            case "fries(Clone)":
                foodTotal.FrenchFries += 1;
                weekTotal.FrenchFries += 1;
                dayTotal.FrenchFries += 1;
                break;
            case "IceCream":
            case "IceCream(Clone)":
                foodTotal.IceCream += 1;
                weekTotal.IceCream += 1;
                dayTotal.IceCream += 1;
                break;
            case "Orange":
            case "Orange(Clone)":
                foodTotal.Orange += 1;
                weekTotal.Orange += 1;
                dayTotal.Orange += 1;
                break;
            case "Pizza":
            case "Pizza(Clone)":
                foodTotal.Pizza += 1;
                weekTotal.Pizza += 1;
                dayTotal.Pizza += 1;
                break;
            case "Soda":
            case "Soda(Clone)":
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
        return (330 / levelGoal.GetTotalFood()) + 1; 
    }

    private int EnergyBarDirection(string foodName)
    {
        switch (foodName)
        {
            case "apple(Clone)":
            case "broccoli(Clone)":
            case "Carrot(Clone)":
            case "Banana(Clone)":
            case "cheese(Clone)":
            case "Egg(Clone)":
            case "Fish(Clone)":
            case "Orange(Clone)":
            case "apple":
            case "broccoli":
            case "Carrot":
            case "Banana":
            case "cheese":
            case "Egg":
            case "Fish":
            case "Orange":
                return 1;
            case "Burger(Clone)":
            case "Burger":
                return dayTotal.Burger > 1 ? -1 : 1;
            case "Pizza":
            case "Pizza(Clone)":
                return dayTotal.Pizza > 1 ? -1 : 1;
            case "fries":
            case "fries(Clone)":
                return dayTotal.FrenchFries > 1 ? -1 : 1;
            case "Candy":
            case "Candy(Clone)":
                return dayTotal.CandyBar > 1 ? -1 : 1;
            case "IceCream":
            case "IceCream(Clone)":
                return dayTotal.IceCream > 1 ? -1 : 1;
            case "Soda":
            case "Soda(Clone)":
                return dayTotal.Soda > 1 ? -1 : 1;
            default:
                return 1;
        }
    }

    private void UpdateUI(string foodName)
    {
        int stepSize = GetLevelStepSize();
        int direction = EnergyBarDirection(foodName);

        //increment or decrement energy bar
        RectTransform energyBarTransform = GameObject.Find("EnergyBar").GetComponent<RectTransform>();
        float temp = Math.Max(Math.Min(energyBarTransform.rect.width + (direction * stepSize), 330),0);
        energyBarTransform.sizeDelta = new Vector2(temp, energyBarTransform.rect.height);

        //update player UI image if needed
        const float energyBarMaxWidth = 330f;
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

	public void showPickupStats()
	{
		List<int>tempIntList = levelGoals [GetCurrentLevel ()-1].GetGoalData ();
		List<GameObject> poolOfFoods = new List<GameObject> ();
		for (int i = 0; i < 14; i++) 
		{
			if (tempIntList [i] > 0) 
			{
				foodSpawner.foodPool.TryGetValue ((FoodSpawner.Foods)i+1, out poolOfFoods);	
				GUIObjects.Add(poolOfFoods[poolOfFoods.Count-1]);
			}
		}
		int k = 0;
		foreach (GameObject food in GUIObjects) 
		{
			
			food.transform.position = GameObject.Find ("UICamera").transform.position;
			food.layer = 8;
			food.transform.parent = GameObject.Find ("UICamera").transform;
			food.transform.localPosition = new Vector3 (-250, 60-k, 100);
			k += 30;
			if (food.name == "Pizza(Clone)" || food.name == "Candy(Clone)" || food.name == "Fish(Clone)" || food.name == "cheese(Clone)")
				food.transform.Rotate(Vector3.left*45, Space.World);
		}
	}

	public void removePickupStats ()
	{
		foreach (GameObject food in GUIObjects) 
		{
			food.layer = 0;
			food.transform.position = new Vector3 (0, 0, -3);
			food.transform.parent = null;
		}

		GUIObjects.Clear ();
	}

    public void FoodCollected(string foodName)
    {
        IncrementFoodCount(foodName);
        UpdateUI(foodName);   
    }
}

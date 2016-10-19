using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

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

    private int currLevel;
    private List<Food> levelGoals;

    private AudioSource gameMusic;

    void Awake()
    {
        Application.targetFrameRate = 60;
    }

	// Use this for initialization
	void Start () 
	{
        gameMusic = GetComponent<AudioSource>();
        gameMusic.Play();

        foodTotal = new Food();
        weekTotal = new Food();
        dayTotal = new Food();
        currLevel = 1;
        levelGoals = new List<Food>();

        CreateLevelGoals();
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
        return levelGoal.GetTotalFood() / 280; 
    }

    private void UpdateUI(string foodName)
    {
        int stepSize = GetLevelStepSize();

        //increment or decrement energy bar
        RectTransform energyBarTransform = GameObject.Find("EnergyBar").GetComponent<RectTransform>();
        energyBarTransform.sizeDelta = new Vector2(stepSize, energyBarTransform.rect.height);

        //update player UI image if needed
        const float energyBarMaxWidth = 280f;
        float energyPercent = energyBarTransform.rect.width / energyBarMaxWidth;

        if(energyPercent < .25f)
        {
            GameObject.Find("PlayerUIImage").GetComponent<Image>().sprite = Resources.Load("heads_0", typeof(Sprite)) as Sprite;
        }
        else if(energyPercent < .5f)
        {
            GameObject.Find("PlayerUIImage").GetComponent<Image>().sprite = Resources.Load("heads_1", typeof(Sprite)) as Sprite;
        }
        else if(energyPercent < .75f)
        {
            GameObject.Find("PlayerUIImage").GetComponent<Image>().sprite = Resources.Load("heads_2", typeof(Sprite)) as Sprite;
        }
        else
        {
            GameObject.Find("PlayerUIImage").GetComponent<Image>().sprite = Resources.Load("heads_3", typeof(Sprite)) as Sprite;
        }
    }

    public void FoodCollected(string foodName)
    {
        IncrementFoodCount(foodName);
        UpdateUI(foodName);   
    }
}

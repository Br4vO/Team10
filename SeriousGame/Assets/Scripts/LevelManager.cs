using UnityEngine;
using System.Collections.Generic;

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
}

public class LevelManager : MonoBehaviour {
    private Food foodTotal;
    private Food weekTotal;
    private Food dayTotal;

    private int currLevel;
    private List<Food> levelGoals;

    void Awake()
    {
        Application.targetFrameRate = 60;
    }

	// Use this for initialization
	void Start () 
	{
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
}

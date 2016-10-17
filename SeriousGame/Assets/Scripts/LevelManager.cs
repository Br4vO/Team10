using UnityEngine;
using System.Collections;

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
    }
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}

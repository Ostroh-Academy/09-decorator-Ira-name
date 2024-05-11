using System;
class Food
{
    protected string Name { get; set; }
    protected double Price { get; set; }
    public Food(string name, double price)
    {
        Name = name;
        Price = price;
    }

    public virtual string GetName()
    {
        return Name;
    }
    public virtual double GetPrice()
    {
        return Price;
    }
}
class FoodDecorator : Food
{
    protected Food DecoratedFood { get; set; }

    public FoodDecorator(Food decoratedFood) : base("", 0)
    {
        DecoratedFood = decoratedFood;
    }

    public override string GetName()
    {
        return DecoratedFood.GetName();
    }

    public override double GetPrice()
    {
        return DecoratedFood.GetPrice();
    }
}
class IngredientDecorator : FoodDecorator
{
    protected string IngredientName { get; set; }
    protected double IngredientPrice { get; set; }

    public IngredientDecorator(Food decoratedFood, string ingredientName, double ingredientPrice)
        : base(decoratedFood)
    {
        IngredientName = ingredientName;
        IngredientPrice = ingredientPrice;
    }

    public override string GetName()
    {
        return base.GetName() + ", " + IngredientName;
    }

    public override double GetPrice()
    {
        return base.GetPrice() + IngredientPrice;
    }
}

class Burger : Food
{
    public Burger() : base("Burger", 5.99)
    {
    }
}
class Cheese : Food
{
    public Cheese() : base("Cheese", 1.50)
    {
    }
}

class Program
{
    static void Main(string[] args)
    {
        Food burger = new Burger();
        Food burgerWithCheese = new IngredientDecorator(burger, "Cheese", 1.50);
        Console.WriteLine("You ordered: " + burgerWithCheese.GetName());
        Console.WriteLine("Total cost: $" + burgerWithCheese.GetPrice());
    }
}
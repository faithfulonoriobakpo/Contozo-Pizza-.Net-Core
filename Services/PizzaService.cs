using ContossoPizza.Models;
namespace ContossoPizza.Services;

public static class PizzaService {
    static int nextId = 3;
    static List<Pizza> Pizzas {get;}
    static PizzaService(){
        Pizzas = new List<Pizza> {
            new Pizza {Id = 1, Name = "Pepperoni", IsGlutenFree = true},
            new Pizza {Id = 2, Name = "Cheese", IsGlutenFree = false},
        };
    }
    public static List<Pizza> GetAll() => Pizzas;
    public static Pizza? Get(int id) => Pizzas.FirstOrDefault(p => p.Id == id);
    public static void Add(Pizza pizza){
        pizza.Id = nextId++;
        Pizzas.Add(pizza);
    }
    public static void Remove(int id){
        Pizza? pizza = Get(id);
        if(pizza == null) return;
        Pizzas.Remove(pizza);
    }
    public static void Update(Pizza pizza){
        int index = Pizzas.FindIndex(p => p.Id == pizza.Id);
        if(index == -1) return;
        Pizzas[index] = pizza;
    }
}
using ContossoPizza.Models;
using ContossoPizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContossoPizza.Controllers;

[ApiController]
[Route("[Controller]")]
public class PizzaController:ControllerBase {
    public PizzaController(){}

    [HttpGet]
    public ActionResult<List<Pizza>> GetAll() => PizzaService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Pizza> Get(int id) {
        Pizza? pizza = PizzaService.Get(id);
        if(pizza == null) return NotFound();
        return pizza;
    }

    [HttpPost]
    public IActionResult CreatePizza(Pizza pizza){
        PizzaService.Add(pizza);
        return CreatedAtAction(nameof(Get), new {id = pizza.Id}, pizza);
    }

    [HttpPut]
    public IActionResult UpdatePizza(Pizza pizza){
        Pizza? existingPizza = PizzaService.Get(pizza.Id);
        if(existingPizza == null) return NotFound();
        PizzaService.Update(pizza);
        return NoContent();
    }

    [HttpDelete]
    public IActionResult DeletePizza(int id){
        Pizza? pizza = PizzaService.Get(id);
        if(pizza == null) return NotFound();
        PizzaService.Remove(id);
        return NoContent();
    }
}
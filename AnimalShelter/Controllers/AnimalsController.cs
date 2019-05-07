using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AnimalShelter.Model;

namespace AnimalShelter.Controllers
{
  public class AnimalsController : Controller
  {
    [HttpGet("/animals")]
    public IActionResult Index()
    {
      List<Animal> animal = Animal.GetAll();
      return View(animal);
    }

    [HttpGet("/animals/:{id}")]
    public IActionResult Show(string Id)
    {
      return View(Animal.GetAnimal(Id));
    }

    [HttpPost("/animals/:{id}")]
    public IActionResult Destroy(string Id)
    {
      Animal.RemoveAnimal(Id);
      return RedirectToAction("Index");
    }

    [HttpGet("/animals/new")]
    public IActionResult New(string Id)
    {
      return View();
    }

    [HttpPost("/animals")]
    public ActionResult Create(string name, string breed, string id)
    {
      Animal.AddAnimal(name, breed, id);
      //RedirectToAction so they can't accidently post it again
      return RedirectToAction("Index");
    }
  }
}

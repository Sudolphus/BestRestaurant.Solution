using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using BestRestaurant.Models;

namespace BestRestaurant.Controllers
{
  public class RestaurantController : Controller
  {
    private readonly BestRestaurantContext _db;

    public RestaurantsController(BestRestaurantContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Restaurant> model = _db.Restaurants.Include(restaurants => restaurants.Cuisine).ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      ViewBag.CuisineId = new SelectList(_db.Cuisines, "CuisineId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Restaurant restaurant)
    {
      _db.Restaurants.Add(restaurant);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Restaurant restaurant = _db.Restaurants.FirstOrDefault(restaurants => restaurants.RestaurantId == id);
      return View(restaurant);
    }

    public ActionResult Edit(int id)
    {
      Restaurant restaurant = _db.Restaurants.FirstOrDefault(restaurants => restaurants.RestaurantId == id);
      ViewBag.CuisineId = new SelectList(_db.Cuisines, "CuisineId", "Name");
      return View(restaurant);
    }

    [HttpPost]
    public ActionResult Edit(Restaurant restaurant)
    {
      _db.Entry(restaurant).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Restaurant restaurant = _db.Restaurants.FirstOrDefault(restaurants => restaurants.RestaurantId == id);
      return View(restaurant);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Restaurant restaurant = _db.Restaurants.FirstOrDefault(restaurants => restaurants.RestaurantId == id);
      _db.Restaurants.Remove(restaurant);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
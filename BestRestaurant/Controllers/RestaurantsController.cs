using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using BestRestaurant.Models;

namespace BestRestaurant.Controllers
{
  public class RestaurantsController : Controller
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

    public ActionResult Search()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Search(string name, string cuisine, string city)
    {
      return RedirectToAction("Results", new { name = name, cuisine = cuisine, city = city });
    }

    public ActionResult Results(string name, string cuisine, string city)
    {
      IQueryable<Restaurant> query = _db.Restaurants.Include(restaurants => restaurants.Cuisine);
      if (name != "" && name != null)
      {
        Regex nameRx = new Regex(name, RegexOptions.IgnoreCase);
        query = query.Where(restaurants => nameRx.IsMatch(restaurants.Name));
      }
      if (cuisine != "" && cuisine != null)
      {
        Regex cuisineRx = new Regex(cuisine, RegexOptions.IgnoreCase);
        query = query.Where(restaurants => cuisineRx.IsMatch(restaurants.Cuisine.Name));
      }
      if (city != "" && city != null)
      {
        Regex cityRx = new Regex(city, RegexOptions.IgnoreCase);
        query = query.Where(restaurants => cityRx.IsMatch(restaurants.City));
      }
      List<Restaurant> model = new List<Restaurant>();
      try
      {
        model = query.ToList();
      }
      catch
      {
      }
      // List<Restaurant> model = _db.Restaurants.Include(restaurants => restaurants.Cuisine).Where(restaurants => nameRX.IsMatch(restaurants.Name)).ToList();
      return View(model);
    }
  }
}
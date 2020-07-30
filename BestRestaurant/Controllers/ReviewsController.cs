using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using BestRestaurant.Models;

namespace BestRestaurant.Controllers
{
  public class ReviewsController : Controller
  {
    private readonly BestRestaurantContext _db;
    public ReviewsController(BestRestaurantContext db)
    {
      _db = db;
    }
    public ActionResult Create(int id)
    {
      Restaurant restaurant = _db.Restaurants.FirstOrDefault(restaurants => restaurants.RestaurantId == id);
      ViewBag.Restaurant = restaurant;
      return View();
    }
    [HttpPost]
    public ActionResult Create(string reviewText, string restaurantId)
    {
      Restaurant restaurant = _db.Restaurants.FirstOrDefault(restaurants => restaurants.RestaurantId == int.Parse(restaurantId));
      Review review = new Review(reviewText);
      restaurant.Reviews.Add(review);
      _db.SaveChanges();
      return RedirectToAction("Details", "Restaurants", new { id = review.RestaurantId });
    }
  }
}
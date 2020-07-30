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
      ViewBag.RestaurantId = id;
      return View();
    }
    [HttpPost]
    public ActionResult Create(Review review)
    {
      _db.Reviews.Add(review);
      _db.SaveChanges();
      return RedirectToAction("Details", "Restaurants", new { id = review.RestaurantId });
    }
  }
}
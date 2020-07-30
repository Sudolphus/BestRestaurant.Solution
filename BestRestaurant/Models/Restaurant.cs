using System.Collections.Generic;

namespace BestRestaurant.Models
{
  public class Restaurant
  {
    public int RestaurantId { get; set; }
    public string Name { get; set; }
    public int CuisineId { get; set; }
    public string StreetAddress { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Website { get; set; }
    public string Phone { get; set;}
    public virtual Cuisine Cuisine { get; set; }
    public virtual ICollection<Review> Reviews { get; set; }
    public Restaurant()
    {
      this.Reviews = new HashSet<Review>();
    }
  }
}
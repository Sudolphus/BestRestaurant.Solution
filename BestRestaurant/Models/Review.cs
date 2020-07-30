namespace BestRestaurant.Models
{
  public class Review
  {
    public int ReviewId { get; set; }
    public string ReviewText { get; set; }
    public int RestaurantId { get; set; }
    public string ReviewerName { get; set; }
    public int ReviewScore { get; set; }
    public virtual Restaurant Restaurant { get; set; }

    public Review(string reviewText, string reviewerName, int reviewScore)
    {
      ReviewText = reviewText;
      ReviewerName = reviewerName;
      ReviewScore = reviewScore;
    }
  }
}
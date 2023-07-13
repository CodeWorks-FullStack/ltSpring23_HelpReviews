namespace HelpReviews.Models;

public class Report
{

  public int Id { get; set; }
  public int RestaurantId { get; set; }
  public string CreatorId { get; set; }

  public string Title { get; set; }
  public string Body { get; set; }

  public Restaurant Restaurant { get; set; }
  public Profile Creator { get; set; }

}


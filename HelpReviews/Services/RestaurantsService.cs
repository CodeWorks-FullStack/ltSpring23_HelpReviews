namespace HelpReviews.Services;

public class RestaurantsService
{

  private readonly RestaurantsRepo _repo;


  public List<Restaurant> GetAll()
  {
    List<Restaurant> restaurants = _repo.GetAll();
    return restaurants;
  }

  public Restaurant Create(Restaurant rData)
  {
    return _repo.Create(rData);
  }

  internal Restaurant GetOne(int id)
  {
    var restaurant = _repo.GetOne(id);

    restaurant.Exposure++;

    _repo.Update(restaurant);


    return restaurant;
  }

  internal List<Report> GetReportsByRestaurantId(int id)
  {
    return _repo.GetReportsByRestaurantId(id);
  }

  public RestaurantsService(RestaurantsRepo repo)
  {
    _repo = repo;
  }
}

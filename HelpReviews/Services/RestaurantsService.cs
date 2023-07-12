namespace HelpReviews.Services;

public class RestaurantsService
{

  private readonly RestaurantRepo _repo;


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
    return _repo.GetOne(id);
  }

  public RestaurantsService(RestaurantRepo repo)
  {
    _repo = repo;
  }
}
namespace HelpReviews.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RestaurantsController : ControllerBase
{

  private readonly RestaurantsService _rs;
  private readonly Auth0Provider _auth;

  public RestaurantsController(RestaurantsService rs, Auth0Provider auth)
  {
    _rs = rs;
    _auth = auth;
  }

  [HttpGet]
  public ActionResult<List<Restaurant>> GetAll()
  {
    try
    {
      List<Restaurant> restaurants = _rs.GetAll();
      return Ok(restaurants);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{id}")]
  public ActionResult<Restaurant> GetOne(int id)
  {
    try
    {
      Restaurant restaurant = _rs.GetOne(id);

      return Ok(restaurant);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{id}/reports")]
  public ActionResult<List<Report>> GetReportsByRestaurantId(int id)
  {
    try
    {
      List<Report> reports = _rs.GetReportsByRestaurantId(id);

      return Ok(reports);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }


  [Authorize]
  [HttpPost]
  async public Task<ActionResult<Restaurant>> Create([FromBody] Restaurant rData)
  {
    try
    {
      // EXPLICIT TYPED 
      Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
      rData.CreatorId = userInfo.Id;

      // IMPLICIT TYPED
      var restaurant = _rs.Create(rData);

      return Ok(restaurant);

    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

}


namespace HelpReviews.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ReportsController : ControllerBase
{
  private readonly ReportsService _rs;
  private readonly Auth0Provider _auth;

  public ReportsController(ReportsService rs, Auth0Provider auth)
  {
    _rs = rs;
    _auth = auth;
  }


  [HttpPost]
  async public Task<ActionResult<Report>> CreateReport([FromBody] Report reportData)
  {
    try
    {
      var userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
      reportData.CreatorId = userInfo.Id;
      Report report = _rs.Create(reportData);
      return Ok(report);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }


}


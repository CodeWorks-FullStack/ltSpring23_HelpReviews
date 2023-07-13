namespace HelpReviews.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
  private readonly AccountService _accountService;
  private readonly Auth0Provider _auth0Provider;
  private readonly ReportsService _rs;

  public AccountController(AccountService accountService, Auth0Provider auth0Provider, ReportsService rs)
  {
    _accountService = accountService;
    _auth0Provider = auth0Provider;
    _rs = rs;
  }

  [HttpGet]
  public async Task<ActionResult<Account>> Get()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      return Ok(_accountService.GetOrCreateProfile(userInfo));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }


  [HttpGet("reports")]
  async public Task<ActionResult<List<Report>>> GetMyReports()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      List<Report> myReports = _rs.GetReportsByCreatorId(userInfo.Id);

      return Ok(myReports);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }



}

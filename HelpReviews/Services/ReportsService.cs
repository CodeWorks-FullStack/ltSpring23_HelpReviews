namespace HelpReviews.Services;

public class ReportsService
{
  private readonly ReportsRepo _rr;

  public ReportsService(ReportsRepo rr)
  {
    _rr = rr;
  }

  internal List<Report> GetReportsByCreatorId(string id)
  {
    return _rr.GetReportsByCreatorId(id);
  }

  internal Report Create(Report reportData)
  {
    return _rr.CreateReport(reportData);
  }
}
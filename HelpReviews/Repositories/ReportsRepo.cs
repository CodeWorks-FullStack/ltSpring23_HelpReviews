namespace HelpReviews.Repositories;

public class ReportsRepo
{
  private readonly IDbConnection _db;

  public ReportsRepo(IDbConnection db)
  {
    _db = db;
  }

  internal Report CreateReport(Report reportData)
  {
    var sql = @"
      INSERT INTO reports(Title, Body, CreatorId, RestaurantId)
      VALUES(@Title, @Body, @CreatorId, @RestaurantId);

      SELECT * FROM reports WHERE id = LAST_INSERT_ID()
    ;";

    return _db.Query<Report>(sql, reportData).FirstOrDefault();
  }

  internal List<Report> GetReportsByCreatorId(string creatorId)
  {
    var sql = @"
      SELECT * FROM reports rep
      JOIN restaurants rest ON rest.id = rep.restaurantId
      WHERE rep.creatorId = @creatorId
    ;";

    return _db.Query<Report, Restaurant, Report>(sql, (rep, rest) =>
    {
      rep.Restaurant = rest;
      return rep;
    }, new { creatorId }).ToList();

  }



}
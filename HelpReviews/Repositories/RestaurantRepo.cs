namespace HelpReviews.Repositories;

public class RestaurantRepo
{

  private readonly IDbConnection _db;

  public RestaurantRepo(IDbConnection db)
  {
    _db = db;
  }

  internal List<Restaurant> GetAll()
  {
    string sql = @"
      SELECT * FROM restaurants
    ;";

    return _db.Query<Restaurant>(sql).ToList();

  }

  public Restaurant Create(Restaurant rData)
  {
    string sql = @"
      INSERT INTO restaurants(name, description, CaTegory, creatorId, imgUrl)
      VALUES(@Name, @Description, @Category, @CreatorId, @ImgUrl);

      SELECT * FROM restaurants WHERE id = LAST_INSERT_ID()
    ;";

    return _db.Query<Restaurant>(sql, rData).FirstOrDefault();
  }

  internal Restaurant GetOne(int id)
  {
    return _db.Query<Restaurant>("SELECT * FROM restaurants WHERE id = @id", new { id }).FirstOrDefault();
  }
}
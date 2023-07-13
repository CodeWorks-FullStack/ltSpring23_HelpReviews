namespace HelpReviews.Repositories;

public class RestaurantsRepo
{

  private readonly IDbConnection _db;

  public RestaurantsRepo(IDbConnection db)
  {
    _db = db;
  }

  internal List<Restaurant> GetAll()
  {
    // REVIEW MYSQL COUNTS
    string sql = @"
      SELECT 
        rest.*,
        COUNT(rep.id) AS ReportCount

      FROM restaurants rest
      
      LEFT JOIN reports rep ON rep.restaurantId = rest.id

      GROUP BY (rest.id)

    ;";




    /**!VIRUAL COUNT
    const BirdsSchema({...})

    BirdsSchema.virtual('spottedCount', {
      localField: '_id',
      foreignField: 'birdId',
      count: true,
      ref: 'Spotters'
    })
    **/



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

  internal List<Report> GetReportsByRestaurantId(int id)
  {
    var sql = @"
      SELECT * FROM reports rep
      JOIN accounts a ON rep.creatorId = a.id
      WHERE rep.restaurantId = @id
    ;";


    return _db.Query<Report, Profile, Report>(sql, (rep, a) =>
    {
      rep.Creator = a;
      return rep;
    }, new { id }).ToList();


  }

  internal void Update(Restaurant restaurant)
  {

    string sql = @"
      UPDATE restaurants
      SET
        exposure = @Exposure
      WHERE id = @Id
    ;";

    _db.Execute(sql, restaurant);


  }
}

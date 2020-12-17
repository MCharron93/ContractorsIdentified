using System;
using System.Data;
using ContractorsIdentified.Models;
using Dapper;

namespace ContractorsIdentified.Repositories
{
  public class ContractorRepository
  {
    private readonly IDbConnection _db;
    private readonly string populateCreator = "SELECT contractor.* FROM contractors contractor ON contractor.creatorId = profile.id";

    public ContractorRepository(IDbConnection db)
    {
      _db = db;
    }

    public Contractor GetByProfileId(Profile userInfo)
    {
      string sql = @"
      SELECT * FROM contractors WHERE 
      contractor.creatorId = @profile.Id;";
      return _db.QueryFirstOrDefault<Contractor>(sql);
    }

    public int CreateContractor(Contractor newContractor)
    {
      string sql = @"
INSERT INTO contractors
(name, wage, creatorId)
VALUES
(@Name, @Wage, @CreatorId);
SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newContractor);
    }
  }
}